using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class NPC : MonoBehaviour
{
	public Dialogue dialogue;
	[SerializeField] private TMP_Text inRangeText;
	private DialogueTrigger dialogueTrigger;
	//private AccesInk accesInk;
	[SerializeField] private GameObject HUDDialogue = null;


	private void Awake()
	{
		//accesInk = GetComponent<AccesInk>();
		//dialogueTrigger = GetComponent<DialogueTrigger>();
	}

	private void Start()
	{
		inRangeText.enabled = false;
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == Tags.PLAYER)
		{
			if(dialogue.isTalkable)
			{
				inRangeText.enabled = true;

				//Debug.Log("Let's talk");
				if (Input.GetKeyDown(KeyCode.E))
				{
					HUDDialogue.SetActive(true);
					//accesInk.StartStory();
					//dialogueTrigger.TriggerDialogue();
				}
			}
			else
			{
				//Debug.Log("can't talk");
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