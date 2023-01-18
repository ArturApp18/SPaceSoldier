using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Game.Scripts
{
	public class PointerInput : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
	{
		public Action OnStartShooting;
		public Action OnEndShooting;

		public bool isPressed = false;
		
		public void OnPointerUp(PointerEventData eventData)
		{
			isPressed = false;
			OnEndShooting?.Invoke();
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			isPressed = true;
			OnStartShooting?.Invoke();
		}
	}
}