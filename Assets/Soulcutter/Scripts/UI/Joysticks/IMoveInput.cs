using System;
using UnityEngine;

namespace Soulcutter.Scripts.UI.Joysticks
{
    public interface IMoveInput
    {
        public event Action<Vector2> OnDragEvent;
        public event Action OnBeginDragEvent, OnEndDragEvent;
    }
}