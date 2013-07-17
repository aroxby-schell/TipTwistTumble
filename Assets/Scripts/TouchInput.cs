using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchInput
{
	public interface TouchReceiver
	{
		void OnTouchBegin(int touchID);
		void OnTouchStay(int touchID);
		void OnTouchEnd(int touchID);
	}
	
	public Vector2 GetTouchPosition(int touchID)
	{
		if(Application.platform!=RuntimePlatform.Android) return ScaleTouchPos( new Vector2(Input.mousePosition.x, Input.mousePosition.y) );
		
		for(int i = 0; i<Input.touches.Length; i++)
		{
			if(Input.touches[i].fingerId==touchID)
			{
				return ScaleTouchPos(Input.touches[i].position);
			}
		}
		
		throw new System.ArgumentOutOfRangeException("touchID", "No touch with touchID");
	}
	
	public int GetTouchCount()
	{
		if(Application.platform==RuntimePlatform.Android) return Input.touchCount;
		if(Input.GetMouseButton(1)) return 2;
		if(Input.GetMouseButton(0)) return 1;
		return 0;
	}
	
	public void Update(TouchReceiver receiver)
	{
		if(Application.platform==RuntimePlatform.Android) UpdateAndroid(receiver);
		else UpdateDesktop(receiver);
	}
	
	private void UpdateDesktop(TouchReceiver receiver)
	{
		for(int i = 0; i<2; i++)
		{
			if(Input.GetMouseButtonDown(i)) receiver.OnTouchBegin(i);
			if(Input.GetMouseButton(i)) receiver.OnTouchStay(i);
			if(Input.GetMouseButtonUp(i)) receiver.OnTouchEnd(i);
		}
	}
	
	private void UpdateAndroid(TouchReceiver receiver)
	{
		for(int i = 0; i<Input.touchCount; i++)
		{
			Touch t = Input.GetTouch(i);
			switch(t.phase)
			{
			case TouchPhase.Began:
				receiver.OnTouchBegin(t.fingerId);
				break;
			case TouchPhase.Moved:
			//case TouchPhase.Stationary:
				receiver.OnTouchStay(t.fingerId);
				break;
			case TouchPhase.Ended:
			case TouchPhase.Canceled:
				receiver.OnTouchEnd(t.fingerId);
				break;
			}
		}
	}
	
	private Vector2 ScaleTouchPos(Vector2 pos)
	{
		return new Vector2(pos.x/Screen.width, pos.y/Screen.height);
	}
	
	private void print(object msg)
	{
		Debug.Log(msg);
	}
}
