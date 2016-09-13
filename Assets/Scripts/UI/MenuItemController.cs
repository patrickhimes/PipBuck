using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Reflection;
using UnityEditor;

[RequireComponent (typeof (AudioSource))]
public class MenuItemController : MonoBehaviour {

	public PlayerTrait playerTrait;
	public Text label, value; 
	public Image menuIcon;
	public Text menuDesc;
	public AudioClip selectSFX;
	private PlayerController playerController;

	/* This function is no longer needed, but a valuable lesson on how to retrieve a class's value by field name
	 * 
	 * string GetPlayerData () {
		if (playerController == null) {
			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			playerController = player.GetComponent<PlayerController> ();
		}
		PlayerData playerData = playerController.playerData;
		int thisValue = (int)playerData.GetType().GetField(item.name).GetValue(playerData);
		//Debug.Log ("found" + thisValue.ToString());

		return thisValue.ToString();
	}*/

	public void Start(){

		if (value != null) {
			value.text = playerTrait.value.ToString();
			Debug.Log ("set " + playerTrait.trait.name + " to " + playerTrait.value.ToString());
		}
	}

	public void UpdateMenuOnClick () {
			

		GetComponent<AudioSource> ().PlayOneShot (selectSFX);
		menuIcon.sprite = playerTrait.trait.icon;
		menuDesc.text = playerTrait.trait.description;

	}
}
