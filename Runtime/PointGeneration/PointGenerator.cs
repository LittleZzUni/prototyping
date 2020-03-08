using UnityEngine;

namespace JasonStorey
{
    /// <summary>
    ///     A Point generator.
    ///     Creates a number of vector positions
    /// </summary>
    public interface PointGenerator
    {
        /// <summary>
        ///     The generated points
        /// </summary>
        Vector3[] Points { get; }

        /// <summary>
        ///     Regenerate/Recalculate the point positions
        /// </summary>
        void Regenerate();
    }

    /// <summary>
    ///     An interface for a point generator to configure its settings
    /// </summary>
    /// <typeparam name="TSettings"></typeparam>
    public interface PointGenerator<TSettings> where TSettings : PointSettings
    {
        /// <summary>
        ///     The settings to generate the points with
        /// </summary>
        TSettings Settings { get; set; }
    }
}