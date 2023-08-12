using Soulcutter.Scripts.UI.ActionButton;
using Soulcutter.Scripts.UI.Joysticks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour, IPointerDownHandler
{
    private Joystick _joystick;
    private ActionButton _actionButton;

    public void Initialize(Joystick joystick, ActionButton actionButton)
    {
        _joystick = joystick;
        _actionButton = actionButton;
    }

    public void ShowScreen()
    {
        _joystick.Disable();
        _actionButton.Disable();
        gameObject.SetActive(true);
    }
    
    public void ReloadScene()
    {
        SceneManager.LoadScene("Test Level");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ReloadScene();
    }
}
