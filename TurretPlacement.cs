using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlacement : MonoBehaviour
{
	[SerializeField] private GameObject turret_object;
	private GameCore gc;

	public int cost = 100;

	RaycastHit hit;
	Camera cam;

	private event EventHandler OnMouseRightPressed;

	void Awake()
	{
		cam = GetComponent<Camera>();
		gc = cam.GetComponent<GameCore>();
	}

    void Start()
    {
		OnMouseRightPressed += OnMouseLeftPressed_Action;
    }
	
    void Update()
    {
		if (Input.GetMouseButtonDown(1))
			OnMouseRightPressed?.Invoke(this, EventArgs.Empty);
    }
	
	void FixedUpdate()
	{
		
	}

	void OnMouseLeftPressed_Action(object sender, EventArgs e)
    {
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out hit))
		{
			if (!hit.collider)
				return;

			if (!hit.collider.CompareTag("Tile"))
				return;

			hit.collider.gameObject.TryGetComponent<Renderer>(out var re);

			if (!re)
				return;

			Vector3 center = re.bounds.center;

			if (gc.GetMoney() >= cost)
            {
				gc.AddMoney(-cost);

				GameObject temp = Instantiate(turret_object, new Vector3(center.x, center.y + 0.2f, center.z), Quaternion.identity) as GameObject;
			}
		}
	}
}
