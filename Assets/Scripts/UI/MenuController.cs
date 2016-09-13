using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class MenuController : MonoBehaviour {
	public Image menuIcon;
	public Text menuDesc;
	public Button parentButton;
	public GameObject menuItemPrefab, contentPanel;
	public GameObject player;
	public List<PlayerTrait> menuItem;
	public OPTIONS selectedList;
	private PlayerController playerController;
	private Button lastSelected;
	
	public enum OPTIONS { 
		PERKS = 0, 
		SPECIAL = 1,
		SKILLS = 2
	}

	public void Start(){
		//LoadMenu ();
	}

	public void OnEnable(){
		
		if (contentPanel.transform.childCount == 0) {
			//load menu items if they have not already been loaded
			LoadMenu ();
		}

		if (lastSelected == null) {
			//select first button in list
			foreach (Transform child in contentPanel.transform) {
				Debug.Log ("Select button " + child.gameObject.name + " (" + child.gameObject.GetInstanceID () + ")");
				Button firstButton = child.gameObject.GetComponent<Button> ();
				lastSelected = firstButton;
				break;
			}
			lastSelected.GetComponent<MenuItemController> ().UpdateMenuOnClick ();
		}
		// hack to highlight button
		StartCoroutine(SelectContinueButtonLater());
	}

	IEnumerator SelectContinueButtonLater()
	{
		// This is a hack to highlight a button 
		// .Select() does not highlight the 2nd time it's called against a button
		// no one has any fucking clue why this bug still exists.
		yield return null;
		EventSystem.current.SetSelectedGameObject(null);
		EventSystem.current.SetSelectedGameObject(lastSelected.gameObject);
	}

	public void LoadMenu(){
		//Debug.Log ("Loading items into Menu...");

		playerController = player.GetComponent<PlayerController> ();

		//clear any items under the content panel
		foreach(Transform child in contentPanel.transform) {
			
			Destroy (child.gameObject);
		}
		menuItem = GetMenuItems (selectedList);

		Button lastButton = parentButton;

		//add items to menu
		foreach(PlayerTrait playerTrait in menuItem){

			//instantiate perk and setup
			GameObject newItem = Instantiate(menuItemPrefab, menuItemPrefab.transform.position, menuItemPrefab.transform.rotation) as GameObject;
			newItem.name = playerTrait.trait.name;

			//Debug.Log ("Create button " + newItem.name + " (" + newItem.GetInstanceID() + ")");
			MenuItemController menuItemController = newItem.GetComponent <MenuItemController>();
			menuItemController.playerTrait = playerTrait;
			menuItemController.label.text = playerTrait.trait.name;

			menuItemController.menuIcon = menuIcon;
			menuItemController.menuDesc = menuDesc;

			RectTransform rectTrans = newItem.GetComponent<RectTransform>();
			rectTrans.localPosition = Vector3.zero;
			newItem.transform.SetParent (contentPanel.transform, false);
			newItem.transform.localScale = Vector3.one;

			if (lastButton != null) {
				//connect item to button above it

				Button childButton = newItem.GetComponent<Button> ();
				Navigation nav = lastButton.navigation;
				nav.selectOnDown = childButton;
				lastButton.navigation = nav;

				Navigation childNav = childButton.navigation;
				childNav.mode = Navigation.Mode.Explicit;
				childNav.selectOnUp = lastButton;
				childNav.selectOnRight = lastButton.navigation.selectOnRight;
				childNav.selectOnLeft = lastButton.navigation.selectOnLeft;
				childButton.navigation = childNav;

				lastButton = childButton;
			}
		}


	}

	public List<PlayerTrait> GetMenuItems( OPTIONS op){
		
		List<PlayerTrait> newList = new List<PlayerTrait>();
		switch (op) {
		case OPTIONS.PERKS:
			//Debug.Log ("Loading Perks");
			foreach (PlayerTrait perk in playerController.playerData.perks) {
				PlayerTrait addPerkAsItem = (PlayerTrait)perk;
				newList.Add (addPerkAsItem);
			}

			break;
		case OPTIONS.SPECIAL:
			//Debug.Log ("Loading SPECIAL");
			foreach (PlayerTrait special in playerController.playerData.special) {
				PlayerTrait addSpecialAsItem = (PlayerTrait)special;
				newList.Add (addSpecialAsItem);
			}
			break;
		case OPTIONS.SKILLS:
			//Debug.Log ("Loading SPECIAL");
			foreach (PlayerTrait skill in playerController.playerData.skills) {
				PlayerTrait addskillAsItem = (PlayerTrait)skill;
				newList.Add (addskillAsItem);
			}
			break;
		default:
			Debug.LogError ("Unrecognized Option");
			newList = null;
			break;
		}

		return newList;
	}

}
