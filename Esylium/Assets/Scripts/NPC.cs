using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NPC : MonoBehaviour
{
	public static Action ActivateDialogueEvent;

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == Tags.PLAYER)
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				if (ActivateDialogueEvent != null)
				{
					ActivateDialogueEvent();
				}
			}
		}
	}
}