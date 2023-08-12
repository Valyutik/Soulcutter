using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Soulcutter.Scripts.UI.Joysticks
{
    public class Joystick : MonoBehaviour, IPointerDownHandler,
        IPointerUpHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public event Action<Vector2> OnDragEvent;
        public event Action OnBeginDragEvent, OnEndDragEvent;

        private float Horizontal => (snapX) ? SnapFloat(_input.x, AxisOptions.Horizontal) : _input.x;
        private float Vertical => (snapY) ? SnapFloat(_input.y, AxisOptions.Vertical) : _input.y;
        private Vector2 Direction => new(Horizontal, Vertical);
        public float HandleRange
        {
            set => handleRange = Mathf.Abs(value);
        }
        public float DeadZone
        {
            set => deadZone = Mathf.Abs(value);
        }

        [SerializeField] private float handleRange = 1;
        [SerializeField] private float deadZone;
        [SerializeField] private AxisOptions axisOptions = AxisOptions.Both;
        [SerializeField] private bool snapX;
        [SerializeField] private bool snapY;
        [SerializeField] protected RectTransform background;
        [SerializeField] private RectTransform handle;
        private RectTransform _baseRect;
        private Canvas _canvas;
        private Camera _camera;
        private Vector2 _input = Vector2.zero;

        public virtual void Initialize(Camera cam)
        {
            HandleRange = handleRange;
            DeadZone = deadZone;
            _camera = cam;
            
            _baseRect = GetComponent<RectTransform>();
            _canvas = GetComponentInParent<Canvas>();
            
            if (_canvas == null)
                Debug.LogError("The Joystick is not placed inside a canvas");

            var center = new Vector2(0.5f, 0.5f);
            background.pivot = center;
            handle.anchorMin = center;
            handle.anchorMax = center;
            handle.pivot = center;
            handle.anchoredPosition = Vector2.zero;
        }

        public void FixedUpdatePass()
        {
            OnDragEvent?.Invoke(Direction);
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            _camera = null;
            if (_canvas.renderMode == RenderMode.ScreenSpaceCamera)
                _camera = _canvas.worldCamera;
            var position = RectTransformUtility.WorldToScreenPoint(_camera, background.position);
            var radius = background.sizeDelta / 2;
            _input = (eventData.position - position) / (radius * _canvas.scaleFactor);
            FormatInput();
            HandleInput(_input.magnitude, _input.normalized, radius, _camera);
            handle.anchoredPosition = _input * radius * handleRange;
        }

        protected virtual void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
        {
            if (magnitude > deadZone)
            {
                if (magnitude > 1)
                    _input = normalised;
            }
            else
                _input = Vector2.zero;
        }

        private void FormatInput()
        {
            _input = axisOptions switch
            {
                AxisOptions.Horizontal => new Vector2(_input.x, 0f),
                AxisOptions.Vertical => new Vector2(0f, _input.y),
                _ => _input
            };
        }

        private float SnapFloat(float value, AxisOptions snapAxis)
        {
            if (value == 0)
                return value;

            var angle = Vector2.Angle(_input, Vector2.up);
            if (axisOptions == AxisOptions.Both)
            {
                return snapAxis switch
                {
                    AxisOptions.Horizontal when angle is < 22.5f or > 157.5f => 0,
                    AxisOptions.Horizontal => (value > 0) ? 1 : -1,
                    AxisOptions.Vertical when angle is > 67.5f and < 112.5f => 0,
                    AxisOptions.Vertical => (value > 0) ? 1 : -1,
                    _ => value
                };
            }
            return value switch
            {
                > 0 => 1,
                < 0 => -1,
                _ => 0
            };
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            _input = Vector2.zero;
            handle.anchoredPosition = Vector2.zero;
        }

        protected Vector2 ScreenPointToAnchoredPosition(Vector2 screenPosition)
        {
            if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(_baseRect, screenPosition, _camera,
                    out var localPoint)) return Vector2.zero;
            Vector2 sizeDelta;
            var pivotOffset = _baseRect.pivot * (sizeDelta = _baseRect.sizeDelta);
            return localPoint - (background.anchorMax * sizeDelta) + pivotOffset;

        }

        public void OnBeginDrag(PointerEventData eventData) => OnBeginDragEvent?.Invoke();
        public void OnEndDrag(PointerEventData eventData) => OnEndDragEvent?.Invoke();
        public void Inable() => gameObject.SetActive(true);

        public void Disable() => gameObject.SetActive(false);
    }

    public enum AxisOptions { Both, Horizontal, Vertical }
}