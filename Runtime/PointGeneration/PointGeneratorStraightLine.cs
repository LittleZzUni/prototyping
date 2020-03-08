using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JasonStorey
{
    /// <summary>
    ///     Generates a number of points in a straight line
    /// </summary>
    public class PointGeneratorStraightLine : APointGenerator<StraightLinePointSettings>
    {
        /// <summary>
        ///     Constructs a straight line point generator
        /// </summary>
        /// <param name="settings">Point Generation settings</param>
        public PointGeneratorStraightLine(StraightLinePointSettings settings) : base(settings)
        {
        }

        /// <summary>
        ///     Generates points in a straight line from a parent transform
        /// </summary>
        /// <param name="parent">Parent transform</param>
        /// <param name="amount">number of points to generate</param>
        /// <returns></returns>
        public static IEnumerable<Vector3> GenerateLinePoints(Transform parent, int amount)
        {
            if (parent == null) return Enumerable.Empty<Vector3>();
            return GenerateLinePoints(amount, parent.position, parent.forward, parent.localScale.z);
        }

        /// <summary>
        ///     Generates points from an origin position in a direction
        /// </summary>
        /// <param name="amount">number of points</param>
        /// <param name="origin">origin starting position</param>
        /// <param name="direction">direction vector for points to follow</param>
        /// <param name="seperationDistance">distance between each point</param>
        /// <returns></returns>
        public static IEnumerable<Vector3> GenerateLinePoints(int amount, Vector3 origin, Vector3 direction,
            float seperationDistance)
        {
            for (var i = 0; i < amount; i++)
                yield return origin + direction * (i * seperationDistance);
        }

        protected override IEnumerable<Vector3> Generate(StraightLinePointSettings settings)
        {
            if (settings == null) return Enumerable.Empty<Vector3>();
            return GenerateLinePoints(settings.Parent, settings.Amount);
        }
    }

    /// <summary>
    ///     Settings for a straight line point generator
    /// </summary>
    [Serializable]
    public class StraightLinePointSettings : PointSettings
    {
        /// <summary>
        ///     Parent transform to generate points around
        /// </summary>
        [Header("Straight Line Settings")] [SerializeField] [Tooltip("Parent transform to generate points around")]
        public Transform Parent;
    }
}