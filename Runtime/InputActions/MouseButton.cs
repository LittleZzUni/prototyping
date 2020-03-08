using UnityEngine;

namespace JasonStorey
{
    public class MouseButton : InputAction
    {
        private int _buttonIndex;

        public void Set(int buttonIndex) => _buttonIndex = buttonIndex;
        
        public MouseButton() : this(0) { }
        public MouseButton(int buttonIndex) => _buttonIndex = buttonIndex;
        public bool Pressed => Input.GetMouseButtonDown(_buttonIndex);
        public bool Held => Input.GetMouseButton(_buttonIndex);
        public bool Released => Input.GetMouseButtonUp(_buttonIndex);
    }
}