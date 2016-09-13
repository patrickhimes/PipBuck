using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UsePlayerData : MonoBehaviour {

	public PlayerData playerValue;
	public Text displayField;

	
	// Update is called once per frame
	void Update () {
	 
		if (playerValue != null) {
			displayField.text = playerValue.ToString();
		}
	}
}
