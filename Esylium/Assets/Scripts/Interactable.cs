using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	private void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.tag == Tags.PLAYER)
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				Debug.Log("Zoom Poster");
			}
		}
	}
}