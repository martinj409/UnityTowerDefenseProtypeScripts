using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IDamageable
{
	public void TakeDamage(int value);
	public void OnDeath(object sender, EventArgs e);
}

public class EnemyAIBehaviour : MonoBehaviour, IDamageable
{
	private event EventHandler Event_OnDeath;


	private NavMeshAgent agent;
	private Renderer re;
	private GameCore gc;

	Vector3 end_destination = new Vector3(29.7f, 1.67f, -17.6f);

	/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

	int health = 100;

	void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
		re = GetComponent<Renderer>();
		gc = GameObject.Find("Main Camera").GetComponent<GameCore>();
	}

    void Start()
    {
		Event_OnDeath += OnDeath;
    }
	
    void Update()
    {
		agent.SetDestination(end_destination);

		if (health <= 0)
			Event_OnDeath?.Invoke(this, EventArgs.Empty);

		if (health >= 70 && health < 100)
            re.material.color = Color.green;

        if (health >= 40 && health <= 69)
            re.material.color = Color.yellow;

        if (health >= 0 && health <= 39)
            re.material.color = Color.red;
    }

    void FixedUpdate()
	{
		
	}

	public void TakeDamage(int value)
    {
		if (health <= 0)
			return;

		health -= value;
    }

	public void OnDeath(object sender, EventArgs e)
    {
		gc?.AddMoney(50);

		Destroy(gameObject);
	}
}
