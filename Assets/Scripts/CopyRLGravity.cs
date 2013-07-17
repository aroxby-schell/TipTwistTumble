using UnityEngine;
using System.Collections;

public class CopyRLGravity : MonoBehaviour
{
	public Transform localSpaceTransform;
	
	private float magnitude;
	private float polarity = 1f;
	
	void Awake()
	{
		magnitude = Physics.gravity.magnitude;
	}
	
	void Start()
	{
		Utils.PreventSleep();
	}

	void Update()
	{
		if(Application.platform==RuntimePlatform.Android)
		{
			FixGravity(Utils.GetGravity()*magnitude);
		}
		else
		{
			if(Input.GetKeyDown(KeyCode.Keypad8)) polarity = -1f;
			if(Input.GetKeyDown(KeyCode.Keypad5)) polarity = 0f;
			if(Input.GetKeyDown(KeyCode.Keypad2)) polarity = 1f;
			
			if(Input.GetKeyDown(KeyCode.LeftArrow)) SetGravity(Vector3.left);
			if(Input.GetKeyDown(KeyCode.RightArrow)) SetGravity(Vector3.right);
			
			if(Input.GetKeyDown(KeyCode.UpArrow))
			{
				if(Utils.ShiftKey())
				{
					polarity = -1f;
					SetGravity(Vector3.zero);
				}
				else SetGravity(Vector3.forward);
			}
			if(Input.GetKeyDown(KeyCode.DownArrow))
			{
				if(Utils.ShiftKey())
				{
					polarity = 1f;
					SetGravity(Vector3.zero);
				}
				else SetGravity(Vector3.back);
			}
		}
	}
	
	void SetGravity(Vector3 dir, bool mixWithDown = true)
	{
		const float strength = 0.75f;
		Vector3 grav = dir*strength;
		if(mixWithDown) grav += Vector3.down*polarity;
		FixGravity(grav.normalized * magnitude);
	}
	
	void FixGravity(Vector3 gravity)
	{
		if(localSpaceTransform)
		{
			float angle = Mathf.PI;
			localSpaceTransform.RotateAround(localSpaceTransform.up, angle);
			Physics.gravity = localSpaceTransform.InverseTransformDirection(gravity);
			localSpaceTransform.RotateAround(localSpaceTransform.up, -angle);
		}
		else Physics.gravity = gravity;
	}
}
