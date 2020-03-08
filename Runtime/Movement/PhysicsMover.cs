using UnityEngine;
namespace JasonStorey 
{
    [RequireComponent(typeof(Rigidbody))]
	public class PhysicsMover : Mover
	{
	    private Rigidbody _rb;
	    public Vector3 Forces;

	    public override Vector3 Velocity => _rb.velocity;
        
	    void Awake()
	    {
	        _rb = GetComponent<Rigidbody>();
	    }

	    public bool NegateGravity;
        
		void FixedUpdate ()
		{
		    UpdateSteering();
		    ApplyForces();
		    ClearForces();
		}

	    void ApplyForces()
	    {
	        if (NegateGravity)
	            _rb.AddForce(Vector3.up * Physics.gravity.magnitude);


	        _rb.AddForce(_externalForces);
            _rb.AddForce(Steering);
        }

	    void ClearForces()
	    {
	        _incomingForces = Forces = _externalForces = Vector3.zero;
	    }



	    public Vector3 Steering;
	    private void UpdateSteering()
	    {
	        Steering = CalculateForces() - _rb.velocity;
	        Steering = Vector3.ClampMagnitude(Steering, MaxForce);
	        Forces = Steering;
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

	    private Vector3 _externalForces;
	    public override void AddExternalForce(Vector3 force)
	    {
	        _externalForces += force;

	    }

	}
}