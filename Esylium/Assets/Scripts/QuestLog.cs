using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestLog : MonoBehaviour
{
	public static QuestLog instance;
	public Animator anim;

	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}

		anim = gameObject.GetComponentInChildren<Animator>();
	}

	public Text questlogText;

	public void UpdatedQuestLog()
	{
		anim.SetTrigger("Activate");
	}
}