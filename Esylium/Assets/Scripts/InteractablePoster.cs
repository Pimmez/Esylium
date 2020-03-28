using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePoster : MonoBehaviour
{
	[SerializeField] private Dialogue dialogue = null;
	[SerializeField] private GameObject posterImage;
	[SerializeField] private GameObject inRangeText = null;

	public void OnPosterClick()
	{
		posterImage.SetActive(false);
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag(Tags.PLAYER))
		{
			inRangeText.SetActive(true);

			if (Input.GetKeyDown(KeyCode.E))
			{
				//BasicMovement.Instance.CanWalk = false;
				posterImage.SetActive(true);
				dialogue.isTalkable = true;

				QuestLog.instance.questlogText.text = "- Talk to Jake near the booth.";
				QuestLog.instance.UpdatedQuestLog();
			}
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		{
			inRangeText.SetActive(false);
			return;
		}
	}
}