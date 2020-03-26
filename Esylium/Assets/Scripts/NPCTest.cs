using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NPCTest : MonoBehaviour
{
	public Dialogue dialogue;
	[SerializeField] private DialogueManager dialogueManager;
	[SerializeField] private TMP_Text inRangeText = null;
	[SerializeField] private GameObject HUDDialogue = null;
	[SerializeField] private Image NPCBust = null;
	[SerializeField] private Text NPCName = null;

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
				NPCBust.sprite = dialogue.bustSprite;
				NPCName.text = dialogue.name;

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