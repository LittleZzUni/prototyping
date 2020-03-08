using System;
using UnityEngine;

namespace JasonStorey
{
    public abstract class MonoActor : MonoBehaviour,Actor
    {
        public abstract void Show(Action onComplete);

        public abstract void Hide(Action onComplete);

        public abstract void TurnOff();

        public abstract void TurnOn();

        public abstract bool IsVisible { get; }
    }
}