using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SuspicionSystem : MonoBehaviour
{
	public int SliderValue { get { return sliderValue; } set { sliderValue = value; } }
	[SerializeField] private int sliderValue;

	[SerializeField] private Slider slider;
	[SerializeField] private float delta = 1f;

	private bool canChange = false;

	private void Update()
	{			
		if (canChange)
		{
			slider.value = Mathf.Lerp(slider.value, sliderValue, delta * Time.deltaTime);
			//slider.value = Mathf.MoveTowards(slider.value, sliderValue, delta * Time.deltaTime);

			//Slidervalue will count in miliseconds on and on without reaching his destination. After a certain point we will lock it to an even number.
			if(slider.value >= (sliderValue - 0.001))
			{
				slider.value = sliderValue;
				canChange = false;
			}
		}
	}

	private void RaiseSuspicionSlider(string _suspicionTag)
	{
		canChange = true;
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