using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using System;

public class InkTestingScript : MonoBehaviour
{
	public static Action<string> SuspicionTagEvent;

	//Audio
	[SerializeField] private List<string> suspicionTags = new List<string>();

	public TextAsset inkJSON = null;
	public Story story;
	public Text textPrefab;
	public Button buttonPrefab;
	public GameObject panel;
	public GameObject HUDDialogue;

	public void StartStory(TextAsset _inkJSON)
	{
		Debug.Log(_inkJSON);
		inkJSON = _inkJSON;
		story = new Story(inkJSON.text);
		RefreshUI();
	}

	private void RefreshUI()
	{
		EraseUI();

		GameObject _panel = Instantiate(panel) as GameObject;
		_panel.transform.SetParent(HUDDialogue.transform, false);

		Text storyText = Instantiate(textPrefab) as Text;
		storyText.text = LoadStoryChunk();
		storyText.transform.SetParent(HUDDialogue.transform, false);

		if (story.currentChoices.Count > 0)
		{
			foreach (Choice choice in story.currentChoices)
			{
				Button choiceButton = Instantiate(buttonPrefab) as Button; 
				Text choiceText = buttonPrefab.GetComponentInChildren<Text>(); 
				choiceText.text = choice.text;                              
				choiceButton.transform.SetParent(_panel.transform, false);

				choiceButton.onClick.AddListener(delegate
				{
					ChooseStoryChoice(choice);
				});
			}
		}
		// If we've read all the content and there's no choices, the story is finished!
		else
		{
			Button choice = CreateChoiceView("End of Conversation.\nRestart?");
			choice.onClick.AddListener(delegate {

				//StartStory();
				EraseUI();
			});
		}
	}

	// Creates a button showing the choice text
	private Button CreateChoiceView(string text)
	{
		// Creates a panel from a prefab
		GameObject _panel = Instantiate(panel) as GameObject;
		_panel.transform.SetParent(HUDDialogue.transform, false);

		// Creates the button from a prefab
		Button choice = Instantiate(buttonPrefab) as Button;
		choice.transform.SetParent(_panel.transform, false);

		// Gets the text from the button prefab
		Text choiceText = choice.GetComponentInChildren<Text>();
		choiceText.text = text;

		// Make the button expand to fit the text
		//HorizontalLayoutGroup layoutGroup = choice.GetComponent<HorizontalLayoutGroup>();
		//layoutGroup.childForceExpandHeight = false;

		return choice;
	}

	// Erases UI
	private void EraseUI()
	{
		for (int i = 0; i < this.transform.childCount; i++)
		{
			Destroy(this.transform.GetChild(i).gameObject);
		}
	}

	private void ChooseStoryChoice(Choice choice)
	{
		story.ChooseChoiceIndex(choice.index);
		RefreshUI();
	}

	private string LoadStoryChunk()
	{
		string text = "";

		if(story.canContinue)
		{
			text = story.ContinueMaximally();
		}

		return text;
	}
}