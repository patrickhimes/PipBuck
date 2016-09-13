using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SubMenuController : MonoBehaviour, ISelectHandler{

	public Animator submenuAnimator;
	public string animationTrigger;


	public void OnSelect(BaseEventData eventData)
	{
		//do your stuff when selected
		Button button = eventData.selectedObject.GetComponent<Button>();
		button.onClick.Invoke ();
		submenuAnimator.SetTrigger(animationTrigger);
		Debug.Log("OnSelect");
	}

}
