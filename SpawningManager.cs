using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : MonoBehaviour
{
	[SerializeField] private GameObject enemy_object;

	public event EventHandler OnSpacePressed;
	void Awake()
	{
		
	}

	void SpawnEntity(object sender, EventArgs e)
    {
		GameObject temp = Instantiate(enemy_object, new Vector3(-32.2f, 1.37f, 19f), enemy_object.transform.rotation) as GameObject;
	}

    void Start()
    {
		OnSpacePressed += SpawnEntity;
	}
	
    void Update()
    {
		if (Input.GetMouseButtonDown(0))
			OnSpacePressed?.Invoke(this, EventArgs.Empty);
	}
	
	void FixedUpdate()
	{
		
	}
}
