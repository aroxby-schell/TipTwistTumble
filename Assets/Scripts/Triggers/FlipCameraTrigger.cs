using UnityEngine;
using System.Collections;

public class FlipCameraTrigger : MonoBehaviour
{
	public GameObject[] cameras;
	private int i = 0;
	
	void OnTriggerExit(Collider c)
	{
		if(c.name=="PlayerSphere")
		{
			cameras[i].SetActive(false);
			i++;
			i%=cameras.Length;
			cameras[i].SetActive(true);
		}
	}
}
