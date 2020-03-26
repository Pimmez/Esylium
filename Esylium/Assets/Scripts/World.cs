using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : SceneController
{
	public Transform player;
	[SerializeField] private Transform frontdoorPosition;

	// Use this for initialization
	public override void Start()
	{
		base.Start();

		if (prevScene == "Interior")
		{
			player.position = frontdoorPosition.position;
		}
	}
}