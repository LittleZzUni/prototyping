namespace JasonStorey
{
    public class NoInputAction : InputAction
    {
        public bool Pressed => false;
        public bool Held => false;
        public bool Released => false;

        #region Singleton

        public static NoInputAction Instance => _instance ?? (_instance = new NoInputAction());
        private static NoInputAction _instance;

        #endregion
    }
}