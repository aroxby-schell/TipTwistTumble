using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour
{
	public Transform target;
	
	void Update()
	{
		transform.LookAt(target);
		
		/*
		if(target)
		{			
			Vector3 dir = (target.position - transform.position).normalized;
			Vector3 angles = Quaternion.FromToRotation(Vector3.forward, dir).eulerAngles;

			angles = Utils.Sloop(angles);
			transform.eulerAngles = angles;
		}
		*/
	}
}