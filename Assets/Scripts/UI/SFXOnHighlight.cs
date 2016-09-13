using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class SFXOnHighlight : MonoBehaviour , ISelectHandler{

	public AudioClip selectSFX;
	public void OnSelect(BaseEventData eventData)
	{
		if (selectSFX != null) {
			GetComponent<AudioSource> ().PlayOneShot (selectSFX);
		}
	}

}