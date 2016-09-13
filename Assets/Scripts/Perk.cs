using UnityEngine;
using System.Collections;

public class Perk  {

	public Sprite Icon;
	public string Name, Description;

	public Perk(Sprite icon, string name, string description){
		Icon = icon;
		Name = name;
		Description = description;
	}
}
