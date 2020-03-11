using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
	public Item item;
	[SerializeField] private float interactionRange = 2f;

	private void Update()
	{
		CheckNearObjects();
	}

	private void CheckNearObjects()
	{
		Collider[] objects = Physics.OverlapSphere(transform.position, interactionRange);

		foreach (Collider col in objects)
		{
			if (col.tag == Tags.PLAYER)
			{
				PickUp();
			}
		}
	}

	private void PickUp()
	{
		Debug.Log("Picked Up " + item.title);
		Inventory.instance.Add(item);
		Destroy(gameObject);
	}
}