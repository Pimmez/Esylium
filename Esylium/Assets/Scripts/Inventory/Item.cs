using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
	new public string title = "New Item";
	public Sprite icon = null;
	public string description;


	public virtual void Use()
	{
		// Use the Item.
		// Something might happen.
		Debug.Log("Using " + title);
	}
}