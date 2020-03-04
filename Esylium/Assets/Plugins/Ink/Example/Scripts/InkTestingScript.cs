using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;

public class InkTestingScript : MonoBehaviour
{
	public TextAsset inkJSON;
	private Story story;
	public Text textPrefab;
	public Button buttonPrefab;

	private void Start() //dit moet van buitenaf aangeroepen kunnen worden via NPC's.
	{
		story = new Story(inkJSON.text); 
		RefreshUI(); 
	}

	private void RefreshUI()
	{
		EraseUI();

		Text storyText = Instantiate(textPrefab) as Text; //Koppel text aan dialogue text.
		storyText.text = LoadStoryChunk();
		storyText.transform.SetParent(this.transform, false);

		foreach (Choice choice in story.currentChoices)
		{
			Button choiceButton = Instantiate(buttonPrefab) as Button; //Check of de button via instaniate op een locatie kan krijgen.
			Text choiceText = buttonPrefab.GetComponentInChildren<Text>(); //Kijk of je zonder canvas verticallayoutgroup kan werken.
			choiceText.text = choice.text;								//Check of je meerdere buttons onderelkaar kan instaniaten wanneer nodig.
			choiceButton.transform.SetParent(this.transform, false);

			choiceButton.onClick.AddListener(delegate
			{
				ChooseStoryChoice(choice);
			});
		}
	}

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