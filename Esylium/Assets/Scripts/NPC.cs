using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NPC : MonoBehaviour
{
	private DialogueTrigger dialogueTrigger;

	private void Awake()
	{
		dialogueTrigger = FindObjectOfType<DialogueTrigger>();
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == Tags.PLAYER)
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				dialogueTrigger.TriggerDialogue();
			}
		}
	}
}