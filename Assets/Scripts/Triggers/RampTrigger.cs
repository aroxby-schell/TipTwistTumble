using UnityEngine;
using System.Collections;

public class RampTrigger : MonoBehaviour
{
	public Transform directionMarker;
	private float Velocity = 0.25f;
	
	void OnTriggerEnter(Collider c)
	{
		if(c.name=="PlayerSphere")
		{
			c.rigidbody.velocity = directionMarker.forward * -(Velocity * c.rigidbody.mass);
		}
	}
}
