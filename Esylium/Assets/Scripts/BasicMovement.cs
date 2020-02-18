using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{

	[SerializeField] private float movementSpeed;

	private void Update()
	{
		Movement();
	}
        

	private void Movement()
	{
		Vector3 _movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);


		transform.position = transform.position + (_movement * movementSpeed) * Time.deltaTime;
	}
}