using UnityEngine;

namespace JasonStorey
{
    public class UnityButton : InputAction
    {
        public bool Pressed => Input.GetButtonDown(_btn);
        public bool Released => Input.GetButtonUp(_btn);
        
        public bool Held => Input.GetButton(_btn);

        public void Set(string btn) => _btn = btn;
        
        #region Plumbing
        public UnityButton(string btn) => _btn = btn;

        public UnityButton() : this("Fire1") { }
        private string _btn;
        #endregion
    }
}