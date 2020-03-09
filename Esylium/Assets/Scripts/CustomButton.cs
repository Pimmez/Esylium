using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomButton : MonoBehaviour
{
	public GameObject definedButton;
	public UnityEvent OnClick = new UnityEvent();

	// Use this for initialization
	void Start()
	{
		definedButton = this.gameObject;
	}

	// Update is called once per frame
	void Update()
	{
		Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

		if (Input.GetMouseButtonDown(0))
		{
			if (hit.collider != null)
			{
				Debug.Log(hit.collider.name);
				OnClick.Invoke();
			}
		}
	}
}