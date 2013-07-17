using UnityEngine;
using System.Collections;

public class SlowTrigger : MonoBehaviour
{
	private bool hasFired = false;
	private Vector3 dir;
	
	void OnTriggerEnter(Collider c)
	{
		if(!hasFired && c.name=="PlayerSphere")
		{
			Vector3 dir = Vector3.up + Vector3.right * 0.5f;
			dir = dir.normalized * Physics.gravity.magnitude;
			c.rigidbody.velocity = dir;
		}
	}
}
