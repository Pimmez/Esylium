using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NPCTest : MonoBehaviour
{
	public Dialogue dialogue;
	public Dialogue otherPersonDialogue = null;

	[SerializeField] private DialogueManager dialogueManager;
	[SerializeField] private TMP_Text inRangeText = null;
	[SerializeField] private GameObject HUDDialogue = null;
	[SerializeField] private Image NPCBust = null;
	[SerializeField] private GameObject questLog = null;
	[SerializeField] private Text NPCName = null;
	public string questText = null;

	private void Awake()
	{
		dialogueManager = HUDDialogue.GetComponent<DialogueManager>();
		dialogue.isTalkable = false;
	}


	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag(Tags.PLAYER) && dialogue.isTalkable == true)
		{
			inRangeText.enabled = true;
			if (Input.GetKeyDown(KeyCode.E))
			{
				HUDDialogue.SetActive(true);
				questLog.SetActive(false);
				BasicMovement.Instance.CanWalk = false;

				NPCBust.sprite = dialogue.bustSprite;
				NPCName.text = dialogue.name;
				dialogueManager.StartStory(dialogue.INKJSONFILE);

				otherPersonDialogue.isTalkable = true;
				QuestLog.instance.questlogText.text = questText;
				QuestLog.instance.UpdatedQuestLog();
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