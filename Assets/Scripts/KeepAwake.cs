using UnityEngine;
using System.Collections;

public class KeepAwake : MonoBehaviour
{
	void FixedUpdate()
	{
		rigidbody.WakeUp();
	}
}
