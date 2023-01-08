using UnityEngine;
using UnityEngine.EventSystems;

namespace _Game.Scripts
{
    public class JoyStickInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private float _offset;

        [SerializeField] private RectTransform _background;

        public RectTransform _handle;

        public Vector2 InputDir { get; set; }

        private void Start()
        {
            InputDir = Vector2.zero;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            InputDir = Vector2.zero;
            _handle.anchoredPosition = Vector2.zero;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 position;

            float bgSizeX = _background.sizeDelta.x;
            float bgSizeY = _background.sizeDelta.y;

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_background, eventData.position,
                    eventData.pressEventCamera, out position))
            {
                position.x /= bgSizeX;
                position.y /= bgSizeY;

                InputDir = new Vector2(position.x, position.y);
                InputDir = InputDir.magnitude > 1 ? InputDir.normalized : InputDir;

                _handle.anchoredPosition =
                    new Vector2(InputDir.x * (bgSizeX / _offset), InputDir.y * (bgSizeY / _offset));
            }
        }
    }
}