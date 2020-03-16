using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePoster : MonoBehaviour
{
	[SerializeField] private Dialogue dialogue = null;

	public void OnPosterClick()
	{
		gameObject.transform.position = new Vector3(-1.22f, 6.5f, 0);
		gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 1);
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.tag == Tags.PLAYER)
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				gameObject.transform.position = new Vector3(0, 0, 0);
				gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1);
			}
		}
	}
}