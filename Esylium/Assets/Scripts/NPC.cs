using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NPC : MonoBehaviour
{
	private DialogueTrigger dialogueTrigger;
	public Dialogue dialogue;

	private void Awake()
	{
		dialogueTrigger = GetComponent<DialogueTrigger>();
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == Tags.PLAYER)
		{
			if(dialogue.isTalkable)
			{
				Debug.Log("Let's talk");
				if (Input.GetKeyDown(KeyCode.E))
				{
					dialogueTrigger.TriggerDialogue();
				}
			}
			else
			{
				Debug.Log("can't talk");
				return;
			}
			
		}
	}
}