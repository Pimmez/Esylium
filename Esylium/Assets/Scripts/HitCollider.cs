using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour
{
	[SerializeField] private int sceneIndex;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == Tags.PLAYER)
		{
			SceneLoader.instance.SwitchToScene(sceneIndex);
		}
	}
}