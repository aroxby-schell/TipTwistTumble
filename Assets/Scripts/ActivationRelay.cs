using UnityEngine;
using System.Collections;

public class ActivationRelay : MonoBehaviour
{
	public GameObject target;
	
	void OnEnable()
	{
		target.SetActive(true);
	}
}
