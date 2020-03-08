using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JasonStorey
{
    public abstract class APointGenerator<TSettings> : PointGenerator<TSettings>, PointGenerator
        where TSettings : PointSettings
    {
        /// <summary>
        ///     Constructs a point generator
        /// </summary>
        /// <param name="settings">The settings for generating the points</param>
        protected APointGenerator(TSettings settings)
        {
            Settings = settings;
        }

        /// <summary>
        ///     The generated circle points
        /// </summary>
        public Vector3[] Points { get; private set; }

        /// <summary>
        ///     Regenerate the points, recalculates positions
        /// </summary>
        public void Regenerate()
        {
            if (Settings == null)
            {
                Points = new Vector3[0];
                return;
            }

            Points = Generate(Settings).ToArray();
            Settings?.Generated?.Invoke();
        }

        /// <summary>
        ///     The settings to generate the points with
        /// </summary>
        public TSettings Settings { get; set; }

        protected abstract IEnumerable<Vector3> Generate(TSettings settings);
    }
}