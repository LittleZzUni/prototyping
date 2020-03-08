namespace JasonStorey 
{
    public interface InputAction
    {
        bool Pressed { get; }
        bool Held { get; }
        bool Released { get; }
    }
}