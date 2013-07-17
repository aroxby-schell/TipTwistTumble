using UnityEngine;
using System.Collections;

public class LevelSphereTrigger : MonoBehaviour
{
	Vibrator vibe;
	
	void Start()
	{
		vibe = new Vibrator();
	}
	
	void OnTriggerExit(Collider c)
	{
		if(c.name=="PlayerSphere")
		{
			vibe.Vibrate(0.5f);
			LevelManager.RestartLevel();
		}
	}
}
