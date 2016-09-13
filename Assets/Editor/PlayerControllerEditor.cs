using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(PlayerController))]
public class PlayerControllerEditor : Editor {
	SerializedProperty playerData;
	Object tempSpecialSO;

	void OnEnable () {
		// Setup the SerializedProperties.
		playerData = serializedObject.FindProperty ("playerData");
	}
	public override void OnInspectorGUI() {
		serializedObject.Update ();

		EditorGUILayout.PropertyField (playerData,true);
		EditorGUILayout.Space();

		EditorGUILayout.BeginHorizontal();
		tempSpecialSO = EditorGUILayout.ObjectField(tempSpecialSO, typeof(SPECIAL_SO), false);
		EditorGUILayout.EndHorizontal();


		if(GUILayout.Button("Add SPECIAL"))
		{
			PlayerController playerController = (PlayerController)target;		
			playerController.AddSPECIAL((SPECIAL_SO)tempSpecialSO);
		}
		serializedObject.ApplyModifiedProperties ();
	}
}
