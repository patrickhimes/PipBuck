using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using GenericData;

public class PlayerController : MonoBehaviour {

	public PlayerData playerData;

	private string fileNameKEY = "PlayerData";
	// Use this for initialization
	void Awake () {
		Load ();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.S))
		{
			Save();
		}
	}

	public void modifyStrength(int stat){
		playerData.Strength = stat;
	}

	public void Save(){
		Debug.Log("Saving Player Data...");
		FileIO.SavePDP (playerData,fileNameKEY);
	}
	public void Load(){
		//get player data from file, if available
		Debug.Log("Loading Player Data...");
		string json = (string)FileIO.LoadPDP (fileNameKEY);
		//Debug.Log (json);
		if (json != null) {
			Debug.Log("Player Data found.");
			//Debug.Log (playerData);
			JsonUtility.FromJsonOverwrite( json, playerData );
			//Debug.Log (playerData);
		} else {
			Debug.Log("No Player Data found.");
			playerData = new PlayerData ();
		}
	}

	public void AddSPECIAL( SPECIAL_SO s){
		playerData.AddSPECIAL (s);
	}
}

[Serializable]
public class PlayerData {

	[SerializeField]
	public List<PlayerTrait> perks = new List<PlayerTrait>();

	[SerializeField]
	public List<PlayerTrait> special = new List<PlayerTrait>();

	[SerializeField]
	public List<PlayerTrait> skills = new List<PlayerTrait>();

	[SerializeField]
	public int Strength, Perception, Endurance, Charisma, Intelligence, Agility, Luck,
	HP, AP, EXP, RADs, DAM_Head, DAM_Torso, DAM_FrontLeftLeg, DAM_FrontRightLeg, DAM_BackLeftLeg, DAM_BackRightLeg;

	[SerializeField]
	public string characterName;

	public void AddPerk( Perk_SO p){
		PlayerTrait addTrait = new PlayerTrait();
		addTrait.trait = p;
		perks.Add (addTrait);
		perks.Sort ();
	}

	public void AddSPECIAL( SPECIAL_SO s){
		PlayerTrait addTrait = new PlayerTrait();
		addTrait.trait = s;
		special.Add (addTrait);
		special.Sort ();
	}


	public void AddSkill( Skill_SO s){
		PlayerTrait addTrait = new PlayerTrait();
		addTrait.trait = s;
		skills.Add (addTrait);
		skills.Sort ();
	}

}


[Serializable]
public class PlayerTrait {
	[SerializeField]
	public Item trait;
	[SerializeField]
	public int value;

}