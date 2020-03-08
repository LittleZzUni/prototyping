using UnityEngine;

namespace JasonStorey
{
    public class UnityKey : InputAction
    {
        public bool Pressed => Input.GetKeyDown(_key);
        public bool Held => Input.GetKey(_key);
        public bool Released => Input.GetKeyUp(_key);

        public void Set(KeyCode key) => _key = key;

        #region Plumbing
        
        public UnityKey() : this(KeyCode.Space) { }
        public UnityKey(KeyCode key) => _key = key;
        private KeyCode _key;
        
        #endregion
    }
}