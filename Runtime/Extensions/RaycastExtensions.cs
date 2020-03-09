using UnityEngine;

namespace JasonStorey 
{
    public static class RaycastExtensions
    {
        public static Ray ToRay(this Transform t) => new Ray(t.position,t.forward);
        //public static RayProvider ToRay(this Transform t) => new TransformLookRay(t);
    }
}