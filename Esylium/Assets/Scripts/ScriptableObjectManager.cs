using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectManager : MonoBehaviour
{
	[SerializeField] private Dialogue dialogue;

	private void Awake()
	{
		dialogue.isTalkable = false;
		dialogue.canOpenGate = false;
	}
}