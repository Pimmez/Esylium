using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
	[SerializeField] private GameObject HUDDialogue;
	[SerializeField] private TMP_Text nameText;
	[SerializeField] private TMP_Text dialogueText;

	private Queue<string> sentences = new Queue<string>();

	public void StartDialogue(Dialogue _dialogue)
	{
		HUDDialogue.SetActive(true);

		Debug.Log("Starting Conversation With " + _dialogue.name);

		nameText.text = _dialogue.name;

		sentences.Clear();

		foreach (string sentence in _dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if(sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		dialogueText.text = sentence;
	}

	private void EndDialogue()
	{
		HUDDialogue.SetActive(false);
	}
}