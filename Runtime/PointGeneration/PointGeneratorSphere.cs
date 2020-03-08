using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JasonStorey
{
    /// <summary>
    ///     Generates a number of points along a circle
    /// </summary>
    public class PointGeneratorSphere : APointGenerator<SpherePointsSettings>
    {
        /// <summary>
        ///     Constructs a sphere point generator
        /// </summary>
        /// <param name="settings">Sphere Generation settings</param>
        public PointGeneratorSphere(SpherePointsSettings settings) : base(settings)
        {
        }

        /// <summary>
        ///     Generates points along a circle around a transform
        /// </summary>
        /// <param name="amount">Number of points to generate</param>
        /// <param name="parent">Parent transform to generate around</param>
        /// <param name="percent">Percentage of sphere to fill</param>
        /// <returns>The circle points</returns>
        public static IEnumerable<Vector3> GenerateSpherePoints(int amount, Transform parent, int percent = 100)
        {
            return GenerateSpherePoints(amount, parent.position, parent.localScale, parent.rotation, percent);
        }

        /// <summary>
        ///     Generates points along a sphere
        /// </summary>
        /// <param name="amount">Number of points to generate</param>
        /// <param name="origin">position to use as the origin</param>
        /// <param name="scale">The sphere scale vector</param>
        /// <param name="rotation">The rotation scale quaternion</param>
        /// <param name="percent">Percentage of sphere to fill</param>
        /// <returns>The circle points</returns>
        public static IEnumerable<Vector3> GenerateSpherePoints(int amount, Vector3 origin, Vector3 scale,
            Quaternion rotation, int percent = 100)
        {
            float am = amount;
            var f = percent / 100f;
            var i = Mathf.PI * (3 - Mathf.Sqrt(5)) * f;
            var o = 2 / am;
            for (var k = 0; k < am; k++)
            {
                var y = k * o - 1 + o / 2;
                var r = Mathf.Sqrt(1 - y * y);
                var phi = k * i;

                var theX = Mathf.Cos(phi) * (r * scale.x);
                var theY = y * scale.y;
                var theZ = Mathf.Sin(phi) * (r * scale.z);
                var result = new Vector3(theX, theY, theZ);

                var rotateVector = rotation * result;
                yield return origin + rotateVector;
            }
        }

        protected override IEnumerable<Vector3> Generate(SpherePointsSettings settings)
        {
            return Settings.Parent != null
                ? GenerateSpherePoints(Settings.Amount, Settings.Parent, Settings.Percentage).ToArray()
                : Enumerable.Empty<Vector3>();
        }
    }

    /// <summary>
    ///     Settings for a sphere point generator
    /// </summary>
    [Serializable]
    public class SpherePointsSettings : PointSettings
    {
        /// <summary>
        ///     Parent transform to generate points around
        /// </summary>
        [Header("Sphere Settings")] [SerializeField] [Tooltip("Parent transform to generate points around")]
        public Transform Parent;

        /// <summary>
        ///     Percentage of sphere to fill
        /// </summary>
        [SerializeField] [Range(-100, 100)] [Tooltip("Percentage of sphere to fill")]
        public int Percentage = 100;
    }
}