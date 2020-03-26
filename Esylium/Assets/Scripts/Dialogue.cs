using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Dialogue : ScriptableObject
{
	public string name;
	public TextAsset INKJSONFILE;
	public Sprite bustSprite;
	public bool isTalkable;
}