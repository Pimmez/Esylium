using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using System;

public class DialogueManager : MonoBehaviour
{
	public static event Action<Story> OnCreateStory;

	private TextAsset inkJSONAsset = null;
	public Story story;

	// UI Prefabs
	[SerializeField] private Text textPrefab = null;
	[SerializeField] private Button buttonPrefab = null;
	[SerializeField] private GameObject panel = null;
	[SerializeField] private GameObject textPanel = null;
	[SerializeField] private GameObject HUDDialogue = null;
	private GameObject tempPanel;
	private GameObject tempTextPanel;


	private void Awake()
	{
		// Remove the default message
		//RemoveChildren();
		//StartStory();
	}

	// Creates a new Story object with the compiled story which we can then play!
	public void StartStory(TextAsset _inkJSONAsset)
	{
		inkJSONAsset = _inkJSONAsset;
		story = new Story(inkJSONAsset.text);
		if (OnCreateStory != null) OnCreateStory(story);
		RefreshView();
	}

	// This is the main function called every time the story changes. It does a few things:
	// Destroys all the old content and choices.
	// Continues over all the lines of text, then displays all the choices. If there are no choices, the story is finished!
	private void RefreshView()
	{
		// Remove all the UI on screen
		RemoveChildren();

		tempTextPanel = Instantiate(textPanel) as GameObject;
		tempTextPanel.transform.SetParent(HUDDialogue.transform, false);

		// Read all the content until we can't continue any more
		while (story.canContinue)
		{
			// Continue gets the next line of the story
			string text = story.Continue();
			// This removes any white space from the text.
			text = text.Trim();
			// Display the text on screen!
			CreateContentView(text);
		}

		// Display all the choices, if there are any!
		if (story.currentChoices.Count > 0)
		{
			for (int i = 0; i < story.currentChoices.Count; i++)
			{
				Choice choice = story.currentChoices[i];
				Button button = CreateChoiceView(choice.text.Trim());
				// Tell the button what to do when we press it
				button.onClick.AddListener(delegate {
					OnClickChoiceButton(choice);
				});
			}
		}
		// If we've read all the content and there's no choices, the story is finished!
		else
		{
			Button choice = CreateChoiceView("End of conversation.");
			choice.onClick.AddListener(delegate {
				RemoveChildren();
			});
		}
	}

	// When we click the choice button, tell the story to choose that choice!
	private void OnClickChoiceButton(Choice choice)
	{
		story.ChooseChoiceIndex(choice.index);
		RefreshView();
	}

	// Creates a textbox showing the the line of text
	private void CreateContentView(string text)
	{
		Text storyText = Instantiate(textPrefab) as Text;
		storyText.text = text;
		storyText.transform.SetParent(tempTextPanel.transform, false);

		tempPanel = Instantiate(panel) as GameObject;
		tempPanel.transform.SetParent(HUDDialogue.transform, false);
	}

	// Creates a button showing the choice text
	private Button CreateChoiceView(string text)
	{
		// Creates the button from a prefab
		Button choice = Instantiate(buttonPrefab) as Button;
		choice.transform.SetParent(tempPanel.transform, false);

		// Gets the text from the button prefab
		Text choiceText = choice.GetComponentInChildren<Text>();
		choiceText.text = text;

		// Make the button expand to fit the text
		//HorizontalLayoutGroup layoutGroup = choice.GetComponent<HorizontalLayoutGroup>();
		//layoutGroup.childForceExpandHeight = false;

		return choice;
	}

	// Destroys all the children of this gameobject (all the UI)
	private void RemoveChildren()
	{
		int childCount = HUDDialogue.transform.childCount;
		for (int i = childCount - 1; i >= 0; --i)
		{
			GameObject.Destroy(HUDDialogue.transform.GetChild(i).gameObject);
		}
	}
}