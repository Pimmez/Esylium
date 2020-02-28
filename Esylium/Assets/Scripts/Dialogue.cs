using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Dialogue : ScriptableObject
{
	public string name;

	[TextArea(3, 10)]
	public List<string> sentences = new List<string>(); 
}