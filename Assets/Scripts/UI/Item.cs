using UnityEngine;
using System;
using System.Collections;

[System.Serializable]
public class Item : ScriptableObject  , IComparable<Item> {

	public string name, description;
	public Sprite icon;
	public int value;

	public int CompareTo(Item other)
	{
		if(other == null)
		{
			return 1;
		}

		//Return the difference in value.
		return value - other.value;
	}
}