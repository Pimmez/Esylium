using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SuspicionSystem : MonoBehaviour
{
	[SerializeField] private int sliderValue;
	[SerializeField] private Slider slider;

	private void RaiseSuspicionSlider(string _suspicionTag)
	{
		slider.value = sliderValue;
	}

	private void OnEnable()
	{
		DialogueManager.SuspicionTagEvent += RaiseSuspicionSlider;		
	}

	private void OnDisable()
	{
		DialogueManager.SuspicionTagEvent -= RaiseSuspicionSlider;
	}
}