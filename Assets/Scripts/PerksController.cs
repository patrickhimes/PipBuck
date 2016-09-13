using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class PerksController : MonoBehaviour {
	public GameObject ContentPanel;
	public GameObject listItemPrefab;
	public PlayerController player;



	void Start () {

		// 1. Get the data to be displayed

		/*Perks = new ArrayList (){
			new Perk(PerkImages[0],
				"Cherchez La Filly",
				""),
			new Perk(PerkImages[1],
				"Horse Sense",
				""),
			new Perk(PerkImages[2],
				"Bookworm",
				"You pay much closer attention to the smaller details when reading.\nYou gain 50% more skill points when reading books."),
			new Perk(PerkImages[3],
				"Egghead",
				"You will add +2 skill points each time you gain a new experience level."),
			new Perk(PerkImages[4],
				"Gunslinger",
				"While using a mouth-held or levitated firearm, your chance to hit in S.A.T.S. increases by 25%."),
			new Perk(PerkImages[5],
				"Mighty Telekenesis",
				"You triple the mass that you can levitate with your unicorn magic."),
			new Perk(PerkImages[6],
				"Organizer",
				"You are efficient at arranging your inventory in general. This makes it much easier to carry that little extra you’ve always needed. Items with a weight of two or less are considered to weigh half as much for you."),
			new Perk(PerkImages[7],
				"Light Trot",
				"You are agile, lucky and always careful; or maybe you have just mastered the art of self-levitation. Either way, you never set off enemy mines or floor-based traps."),
			new Perk(PerkImages[8],
				"Math Wrath",
				"You are able to optimize your PipBuck’s targeting spell logic. S.A.T.S. is now 20% cooler."),
			new Perk(PerkImages[9],
				"Stable Shot",
				"Your attacks are smooth, graceful and precise. You have a higher chance to score a critical hit on an opponent in combat, equivalent to 5 extra points of Luck."),
			new Perk(PerkImages[10],
				"Silent Gallop",
				"You have mastered silent movement, allowing you to move quickly and still remain quiet. You can Sneak at full speed with no penalties."),
			new Perk(PerkImages[11],
				"Sniper Pony",
				"Your chance to hit an enemy’s head in S.A.T.S. is increased by 25%."),
			new Perk(PerkImages[12],
				"Counter Canter",
				"Your fancy hoofwork (or agile flying if you are a pegasus pony) keeps you out of harm’s way. Opponents suffer a -5 to combat skills when attacking you."),
			new Perk(PerkImages[13],
				"The Magic of Friendship",
				"When your HP or the HP of any member of your party drops below 30%, all members of your party (including yourself) gain much greater resistance to damage.")
		};*/

		// 2. Iterate through the data, 
		//	  instantiate prefab, 
		//	  set the data, 
		//	  add it to panel
		foreach(PlayerTrait playerTrait in player.playerData.perks){

			GameObject newPerk = Instantiate(listItemPrefab, listItemPrefab.transform.position, listItemPrefab.transform.rotation) as GameObject;
			newPerk.name = playerTrait.trait.name;
			Text perkText = newPerk.GetComponent<Text>();
			perkText.text = playerTrait.trait.name;
			RectTransform rectTrans = newPerk.GetComponent<RectTransform>();
			rectTrans.localPosition = Vector3.zero;
			newPerk.transform.SetParent (ContentPanel.transform, false);
			newPerk.transform.localScale = Vector3.one;

		}
	}	
}
