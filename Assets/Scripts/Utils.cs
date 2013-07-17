using UnityEngine;
using System.Collections;

public class Utils : MonoBehaviour
{
	public static void PreventSleep()
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	
	public static Vector3 Sloop(Vector3 v)
	{
		return new Vector3( Sloop(v.x), Sloop(v.y), Sloop(v.z) );
	}
	
	public static float Sloop(float f)
	{
		if(f>180f) return f-360f;
		if(f<-180f) return f+360f;
		return f;
	}
	
	public static Vector3 GetGravity()
	{
		Vector3 dev = Input.acceleration;
		Vector3 grav = new Vector3(dev.x, dev.y, -dev.z);
		return grav.normalized;
	}
	
	public static bool ShiftKey()
	{
		return (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift));
	}
	
	public static string VecString(Vector3 v)
	{
		return "("
				+ MyFormat(v.x) + ", "
				+ MyFormat(v.y) + ", "
				+ MyFormat(v.z)
				+")";
	}
	
	private static string MyFormat(float f)
	{
		string ret = f.ToString("F1");
		if(f>=0) ret = "+" + ret;
		return ret;
	}
}
