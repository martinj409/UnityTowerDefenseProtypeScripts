using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameCore : MonoBehaviour
{
	[SerializeField] private int money = 300;

	GameObject MoneyCounter;
	TextMeshProUGUI txp;

	void Awake()
	{
		
	}

    void Start()
    {
		MoneyCounter = GameObject.Find("MoneyCounter");
		txp = MoneyCounter.GetComponent<TextMeshProUGUI>();
    }
	
    void Update()
    {
		txp.SetText($"{money}$");
    }
	
	void FixedUpdate()
	{
		
	}

	public void AddMoney(int value)
    {
		money += value;
    }

	public int GetMoney()
    {
		return money;
    }
}
