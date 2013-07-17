using UnityEngine;
using System.Collections;

public class FinishTrigger : MonoBehaviour
{
	public GameObject winText = null;
	
	void Update()
	{
		if(Application.isEditor)
		{
			if(Input.GetKeyDown(KeyCode.F2)) LevelManager.PreviousLevel();
			if(Input.GetKeyDown(KeyCode.F3)) NextLevel();
		}
	}
	
	void OnTriggerEnter(Collider c)
	{
		if(c.name=="PlayerSphere")
		{
			c.gameObject.SetActive(false);
			NextLevel();
		}
	}
	
	private void NextLevel()
	{
		if(!LevelManager.NextLevel())
		{
			if(winText!=null) winText.SetActive(true);
		}
	}
}
