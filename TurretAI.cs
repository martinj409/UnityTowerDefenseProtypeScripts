using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{
	Vector3 center;

	float next_time = 0f;

	float attack_dist = 4f;
	
	void Awake()
	{
		center = GetComponent<Renderer>().bounds.center;
	}

    void Start()
    {
		
	}
	
    void Update()
    {
		Collider[] cols = Physics.OverlapSphere(center, attack_dist);

		foreach (var col in cols)
		{
			if (col.CompareTag("Enemy"))
			{
				if (col.TryGetComponent<EnemyAIBehaviour>(out var behaviour))
				{
					if (next_time > 0.1f)
					{
						behaviour.TakeDamage(2);

						next_time = 0f;
					}

					next_time += Time.deltaTime;
				}
			}
		}
	}
	
	void FixedUpdate()
	{
		
	}
}
