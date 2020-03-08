using UnityEngine;

namespace JasonStorey 
{
	public class EulerMover : Mover
    {
	    public float Mass = 0.5f;

	    public Vector3 Acceleration;
	    private Vector3 _velocity;
	    public Vector3 Forces;
	    public void UpdateVelocity()
	    {
	        Acceleration = Forces;
            Acceleration = Vector3.ClampMagnitude(Forces, MaxForce);
	        Acceleration /= Mass;

            _velocity += Acceleration * Time.deltaTime;
	        _velocity = Vector3.ClampMagnitude(_velocity, MaxSpeed);
	    }


	    public override Vector3 Velocity => _velocity;


        private void OnValidate()
        {
	        if (Mass < 0.1f) Mass = 0.1f;
        }


        public bool RotateToForce = false;
        void Update ()
		{
		    CalculateForces();
            UpdateSteering();
            UpdateVelocity();
		    ApplyForces();
		    if(RotateToForce)
				UpdateRotation();
		    ClearForces();
		}

        private void ApplyForces()
        {

            transform.position += _velocity * Time.deltaTime;
        }

        private void UpdateRotation()
        {
            if (_velocity != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(_velocity);
        }

	    public Vector3 Steering;
	    private void UpdateSteering()
	    {
	       Steering = CalculateForces() - _velocity;
	       Steering = Vector3.ClampMagnitude(Steering, MaxForce);
	       Forces = Steering;
            
	    }

        public void ClearForces()
        {
            _incomingForces = Forces = Vector3.zero;
        }

	    private Vector3 CalculateForces()
	    {
	       return WithMagnitude(_incomingForces, MaxSpeed);
	    }




	    private Vector3 _incomingForces;

        public override void AddSteeringForce(Vector3 force)
        {
            _incomingForces += force;
        }

        public override void AddExternalForce(Vector3 force)
        {
            
        }
    }
}