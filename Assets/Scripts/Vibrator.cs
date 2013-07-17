using UnityEngine;
using System;
using System.Collections;

public class Vibrator
{
	private IntPtr objectID =  new IntPtr(0);
	private IntPtr methodID = new IntPtr(0);
	private jvalue[] param = new jvalue[1];
	
	public Vibrator()
	{
		if(Application.platform!=RuntimePlatform.Android) return;
		AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
		AndroidJavaObject vibratorService = activity.Call<AndroidJavaObject>("getSystemService", "vibrator");
		
		objectID = vibratorService.GetRawObject();
		methodID = AndroidJNIHelper.GetMethodID( vibratorService.GetRawClass(), "vibrate" );
	}
	
	
	public void Vibrate(float length)
	{
		if(Application.platform==RuntimePlatform.Android)
		{
			param[0].j = (long)(length*1000.0f);
			AndroidJNI.CallVoidMethod(objectID, methodID, param);
		}
		//Everytime you call Handheld.Vibrate() it prints a message to the console, ugh...
		else if(!Application.isEditor)
		{
			//DO NOT REMOVE, USED TO GET VIBRATE PERMISSION
			Handheld.Vibrate();
		}
	}
	
	private static void print(object o)
	{
		UnityEngine.Debug.Log(o);
	}
}
