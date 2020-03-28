using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSound : MonoBehaviour
{

	public AudioClip audioClip;

	private	Button button { get { return GetComponent<Button>(); } }
	private AudioSource audioSource { get { return GetComponent<AudioSource>(); } }
    
	private void Start()
    {
		gameObject.AddComponent<AudioSource>();
		audioSource.clip = audioClip;
		audioSource.playOnAwake = false;

		button.onClick.AddListener(() => PlaySound());
    }

    private void PlaySound()
	{
		audioSource.PlayOneShot(audioClip);
	}
}