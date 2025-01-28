using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.UI.Button;

public class ButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	[SerializeField]
        private ButtonClickedEvent downButton = new ButtonClickedEvent();
	[SerializeField]
        private ButtonClickedEvent upButton = new ButtonClickedEvent();
	
	public void OnPointerDown(PointerEventData eventData)
	{
		downButton?.Invoke();
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		upButton?.Invoke();
	}
}
