using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCTest : MonoBehaviour
{
	public Dialogue dialogue;
	[SerializeField] private DialogueManager dialogueManager;
	[SerializeField] private TMP_Text inRangeText = null;
	[SerializeField] private GameObject HUDDialogue = null;

	private void Awake()
	{
		dialogueManager = HUDDialogue.GetComponent<DialogueManager>();
	}


	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == Tags.PLAYER)
		{
			inRangeText.enabled = true;
			if (Input.GetKeyDown(KeyCode.E))
			{
				HUDDialogue.SetActive(true);
				dialogueManager.StartStory(dialogue.INKJSONFILE);
			}
			else
			{
				return;
			}
		}
	}


	private void OnTriggerExit2D(Collider2D collision)
	{
		{
			inRangeText.enabled = false;
			return;
		}
	}
}