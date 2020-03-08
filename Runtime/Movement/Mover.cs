using System;
using UnityEngine;

namespace JasonStorey
{
    public abstract class Mover : MonoBehaviour
    {
        public float MaxForce { get; set; }

        public float MaxSpeed { get; set; }
		
        public virtual Vector3 Velocity
        {
            get;
            set;
        }

        protected Vector3 WithMagnitude(Vector3 incomingForces, float maxSpeed) => Vector3.ClampMagnitude(incomingForces, maxSpeed);

        public virtual void AddSteeringForce(Vector3 force)
        {
            
        }
        
        public virtual void AddExternalForce(Vector3 force)
        {
            
        }
        
        
        
    }
}