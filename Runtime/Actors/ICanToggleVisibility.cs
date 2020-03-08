using System;

namespace JasonStorey
{
    public interface ICanToggleVisibility
    {
        void Show(Action onComplete);
        void Hide(Action onComplete);
        void TurnOff();
        void TurnOn();
        bool IsVisible { get; }
    }
}