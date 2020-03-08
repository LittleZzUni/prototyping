using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JasonStorey
{
    /// <summary>
    ///     Generates a number of points in a straight line
    /// </summary>
    public class PointGeneratorLineToTarget : APointGenerator<LineToTargetSettings>
    {
        /// <summary>
        ///     Constructs a line to target generator
        /// </summary>
        /// <param name="settings">Point Generation settings</param>
        public PointGeneratorLineToTarget(LineToTargetSettings settings) : base(settings)
        {
        }

        /// <summary>
        ///     Generates points in a straight line from a parent transform
        /// </summary>
        /// <param name="parent">Parent transform</param>
        /// <param name="target">Target transform</param>
        /// <param name="amount">number of points to generate</param>
        /// <returns></returns>
        public static IEnumerable<Vector3> GeneratePointToTarget(Transform parent, Transform target, int amount)
        {
            if (parent == null || target == null) return Enumerable.Empty<Vector3>();
            return GeneratePointToTarget(amount, parent.position, target.position);
        }

        /// <summary>
        ///     Generates points from an origin position in a direction
        /// </summary>
        /// <param name="amount">number of points</param>
        /// <param name="origin">origin starting position</param>
        /// <param name="target">target vector to act as the end point of the line</param>
        /// <returns></returns>
        public static IEnumerable<Vector3> GeneratePointToTarget(int amount, Vector3 origin, Vector3 target)
        {
            if (amount == 0)
                yield break;

            var direction = (target - origin).normalized;
            var distance = Vector3.Distance(origin, target);
            var seperationDistance = distance / (amount + 1);

            for (var i = 1; i < amount + 1; i++)
                yield return origin + direction * (i * seperationDistance);
        }

        protected override IEnumerable<Vector3> Generate(LineToTargetSettings settings)
        {
            if (settings == null) return Enumerable.Empty<Vector3>();
            return GeneratePointToTarget(settings.Parent, settings.Target, settings.Amount);
        }
    }

    /// <summary>
    ///     Settings for a line to target generator
    /// </summary>
    [Serializable]
    public class LineToTargetSettings : PointSettings
    {
        /// <summary>
        ///     Parent transform to generate points around
        /// </summary>
        [Header("Line to Target Settings")] [SerializeField] [Tooltip("Parent transform to generate points around")]
        public Transform Parent;

        /// <summary>
        ///     Target transform to generate points towards
        /// </summary>
        [SerializeField] [Tooltip("Target transform to generate points towards")]
        public Transform Target;
    }
}