using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SelectOnHighlight : MonoBehaviour , ISelectHandler{

	public void OnSelect(BaseEventData eventData)
	{
		//do your stuff when selected
		Button button = eventData.selectedObject.GetComponent<Button>();
		button.onClick.Invoke ();
	}

}
