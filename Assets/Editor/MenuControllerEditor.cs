using UnityEngine;
using UnityEditor;
using System.Collections;
using System;
using System.Reflection;



[CustomEditor(typeof(MenuController))]
public class MenuControllerEditor : Editor {
	SerializedProperty menuIcon, menuDesc, parentButton, menuItemPrefab, contentPanel, player, menuItem,selectedList;
	public MenuController.OPTIONS op;
	private MenuController menuController;
	private PlayerController playerController;

	void OnEnable () {
		// Setup the SerializedProperties.
		menuIcon = serializedObject.FindProperty ("menuIcon");
		menuDesc = serializedObject.FindProperty ("menuDesc");
		parentButton = serializedObject.FindProperty ("parentButton");
		menuItemPrefab = serializedObject.FindProperty ("menuItemPrefab");
		contentPanel = serializedObject.FindProperty ("contentPanel");
		player = serializedObject.FindProperty ("player");
		menuItem = serializedObject.FindProperty ("menuItem");
		selectedList = serializedObject.FindProperty ("selectedList");

		menuController = (MenuController)target;
		playerController = menuController.player.GetComponent<PlayerController> ();

	}
	public override void OnInspectorGUI() {
		serializedObject.Update ();
		EditorGUILayout.PropertyField (menuIcon,true);
		EditorGUILayout.PropertyField (menuDesc,true);
		EditorGUILayout.PropertyField (parentButton,true);
		EditorGUILayout.PropertyField (menuItemPrefab,true);
		EditorGUILayout.PropertyField (contentPanel,true);
		EditorGUILayout.PropertyField (player,true);
		EditorGUILayout.PropertyField (selectedList,true);

		EditorGUILayout.PropertyField (menuItem,true);
		serializedObject.ApplyModifiedProperties ();
	}
}
