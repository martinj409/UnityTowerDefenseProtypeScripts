using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
	private float sensitivity = 4f;
	private float speed = 16f;

	private float yaw = 0f;
	private float pitch = 0f;

	void Awake()
	{
		
	}

    void Start()
    {
		Cursor.lockState = CursorLockMode.Locked;
    }
	
    void Update()
    {
		
    }
	
	void FixedUpdate()
	{
		yaw += sensitivity * Input.GetAxis("Mouse X");
		pitch -= sensitivity * Input.GetAxis("Mouse Y");

		pitch = Mathf.Clamp(pitch, -89f, 89f);

		transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

		transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.fixedDeltaTime, 0f, 0f));
		transform.Translate(new Vector3(0f, 0f, Input.GetAxisRaw("Vertical") * speed * Time.fixedDeltaTime));
	}

	void OnGUI()
	{
		GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 10, 10), "");
	}
}
