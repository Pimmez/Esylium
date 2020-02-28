using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
	public Dialogue dialogue;

	private void TriggerDialogue()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}

	private void OnEnable()
	{
		NPC.ActivateDialogueEvent += TriggerDialogue;
	}

	private void OnDisable()
	{
		NPC.ActivateDialogueEvent -= TriggerDialogue;
	}
}