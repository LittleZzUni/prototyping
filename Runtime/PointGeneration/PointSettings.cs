using System;
using UnityEngine;
using UnityEngine.Events;

namespace JasonStorey
{
    /// <summary>
    ///     Settings for a point generator
    /// </summary>
    [Serializable]
    public class PointSettings
    {
        /// <summary>
        ///     Number of points to generate
        /// </summary>
        [Header("Number of Points")] [SerializeField] [Range(0, 1000)] [Tooltip("Number of points to generate")]
        public int Amount = 10;

        /// <summary>
        ///     Event fired on generation complete
        /// </summary>
        [Header("Events")] [SerializeField] public UnityEvent Generated;
    }
}