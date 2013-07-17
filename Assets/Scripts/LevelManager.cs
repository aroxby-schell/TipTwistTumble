using UnityEngine;

public class LevelManager
{
	public static void RestartLevel()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
	
	public static bool NextLevel()
	{
		int level = Application.loadedLevel+1;
		//Debug.Log("Loading " + level + "/" + (Application.levelCount-1));
		if(level>(Application.levelCount-1)) return false;
		Application.LoadLevel(level);
		return true;
	}
	
	public static bool PreviousLevel()
	{
		int level = Application.loadedLevel-1;
		if(level<0) return false;
		Application.LoadLevel(level);
		return true;
	}
}
