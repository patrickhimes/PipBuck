using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class PipBoyControls : MonoBehaviour {

	public Animator menuAnimator;
	public Animator pipboyAnimator;
	public GameObject scrollKnob;
	public float knobRotation,knobSpeed;

	public AudioClip lightOnSFX,lightOffSFX,selectSFX;

	private Quaternion knobDesRot = Quaternion.identity;
	private bool lightIsOn = false;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		//get userinput
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			TriggerScrollKnob (-1f);
		}

		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			TriggerScrollKnob (1f);
		}
		if (Input.GetKeyDown (KeyCode.Return)) {
			TriggerSelectButton ();
		}

		if (Input.GetKeyDown (KeyCode.Tab)) {
			TriggerFlashlight ();
		}

		if (Input.GetKeyDown (KeyCode.E)) {
			TriggerPowerOn ();
		}

	}

	void FixedUpdate(){
		//update scripted animations
		Scrollknob();
	}


	public void TriggerScrollKnob(float dir){

		//Build quaternions for knob rotation
		knobDesRot = knobDesRot* Quaternion.Euler(knobRotation*dir,0f,0f);
		
	}
	void Scrollknob(){
		//animate knob
		if (knobDesRot != Quaternion.identity) {
			scrollKnob.transform.localRotation = Quaternion.Slerp (scrollKnob.transform.localRotation, knobDesRot,  (Time.deltaTime * knobSpeed));
		}
	}

	void TriggerSelectButton( ){
		GetComponent<AudioSource> ().PlayOneShot (selectSFX);
		pipboyAnimator.SetTrigger ("SelectButton");
	}
	void TriggerFlashlight( ){
		if (lightIsOn) {
			GetComponent<AudioSource> ().PlayOneShot (lightOffSFX);
			pipboyAnimator.SetTrigger ("LightOff");
		} else {
			GetComponent<AudioSource> ().PlayOneShot (lightOnSFX);
			pipboyAnimator.SetTrigger ("LightOn");
		}
		lightIsOn = !lightIsOn;
	}

	void TriggerPowerOn( ){
		
	}
}
