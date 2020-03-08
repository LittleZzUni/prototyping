using UnityEngine;

namespace JasonStorey
{
    public class ScreenTouch : InputAction
    {
        public bool Pressed => TouchedAt(TouchPhase.Began);

        public bool Released => TouchedAt(TouchPhase.Ended);
        
        public bool Held => 
            HasTouch && 
            Input.touches[_touchIndex].phase == TouchPhase.Moved || 
            Input.touches[_touchIndex].phase == TouchPhase.Stationary;
        
        public void Set(int touchIndex) => _touchIndex = touchIndex;

        #region Plumbing

        bool TouchedAt(TouchPhase phase) => HasTouch && Input.touches[_touchIndex].phase == phase;

        private bool HasTouch => Input.touchCount > _touchIndex+1;

        public ScreenTouch() : this(0) { }
        public ScreenTouch(int touchIndex) => _touchIndex = touchIndex;
        
        private int _touchIndex;
        
        #endregion
    }
}