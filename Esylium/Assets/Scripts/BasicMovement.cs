using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
	private static BasicMovement instance;
	public static BasicMovement Instance { get {return instance; } }
	

	[SerializeField] private Animator anim;
	[SerializeField] private float movementSpeed;
	[SerializeField] private GameObject player;

	public bool CanWalk { get { return canWalk; } set { canWalk = value; } }
	private bool canWalk = true;

	private void Awake()
	{
		if(instance != null && instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
		}

		anim = GetComponentInChildren<Animator>();
	}

	private void Update()
	{
		if(canWalk)
		{
			if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
			{
				Movement();
			}
			else
			{
				anim.SetBool("isWalking", false);
			}
		}
		else
		{
			anim.SetBool("isWalking", false);
			return;
		}
	}
        
	private void Movement()
	{
		anim.SetBool("isWalking" ,true);
		FlipCharacter();
		Vector3 _movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
		transform.position = transform.position + (_movement * movementSpeed) * Time.deltaTime;
	}

	private void FlipCharacter()
	{
		if (Input.GetAxis("Horizontal") > 0)
		{
			player.transform.localScale = new Vector3(-0.2f, 0.2f, 1);
		}
		else
		{
			player.transform.localScale = new Vector3(0.2f, 0.2f, 1);
		}
	}
}