using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JasonStorey
{
    /// <summary>
    ///     Generates a number of points along a circle
    /// </summary>
    public class PointGeneratorCircle : APointGenerator<CirclePointsSettings>
    {
        /// <summary>
        ///     Constructs a Circle Point Generator
        /// </summary>
        /// <param name="settings">The circle generator settings</param>
        public PointGeneratorCircle(CirclePointsSettings settings) : base(settings)
        {
        }

        /// <summary>
        ///     Generates points along a circle around a transform
        /// </summary>
        /// <param name="amount">Number of points to generate</param>
        /// <param name="parent">Parent transform to generate around</param>
        /// <param name="percent">Percentage of circle to fill</param>
        /// <returns>The circle points</returns>
        public static IEnumerable<Vector3> GenerateCirclePoints(int amount, Transform parent, int percent = 100)
        {
            return GenerateCirclePoints(amount, parent.position, parent.localScale, parent.rotation, percent);
        }

        /// <summary>
        ///     Generates points along a circle
        /// </summary>
        /// <param name="amount">Number of points to generate</param>
        /// <param name="origin">position to use as the origin</param>
        /// <param name="scale">The circle scale vector</param>
        /// <param name="rotation">The rotation scale quaternion</param>
        /// <param name="percent">Percentage of circle to fill</param>
        /// <returns>The circle points</returns>
        public static IEnumerable<Vector3> GenerateCirclePoints(int amount, Vector3 origin, Vector3 scale,
            Quaternion rotation, int percent = 100)
        {
            for (var i = 0; i < amount; i++)
            {
                var f = percent / 100f * 2;
                var pointNum = i * 1.0f / amount;
                var angle = pointNum * Mathf.PI * f;
                var rx = Mathf.Sin(angle) * scale.x;
                var ry = Mathf.Cos(angle) * scale.y;

                var result = new Vector3(rx, ry) * scale.z;
                var rotateVector = rotation * result;
                yield return origin + rotateVector;
            }
        }

        protected override IEnumerable<Vector3> Generate(CirclePointsSettings settings)
        {
            return settings.Parent != null
                ? GenerateCirclePoints(settings.Amount, settings.Parent, settings.Percentage).ToArray()
                : new Vector3[settings.Amount];
        }
    }

    /// <summary>
    ///     Settings for a circle point generator
    /// </summary>
    [Serializable]
    public class CirclePointsSettings : PointSettings
    {
        /// <summary>
        ///     Parent transform to generate points around
        /// </summary>
        [Header("Circle Settings")] [SerializeField] [Tooltip("Parent transform to generate points around")]
        public Transform Parent;

        /// <summary>
        ///     Percentage of circle to fill
        /// </summary>
        [SerializeField] [Range(-100, 100)] [Tooltip("Percentage of circle to fill")]
        public int Percentage = 100;
    }
}