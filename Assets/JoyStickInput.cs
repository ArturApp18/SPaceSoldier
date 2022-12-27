using System;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class JoyStickInput : MonoBehaviour
{
    [SerializeField] private GameObject _handle;

    [SerializeField] private float _moveRadius;

    [SerializeField] private Vector3 _basePosition;

    private void Start()
    {
        _basePosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            MoveButton();
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            BackToBasePosition();
        }
    }

    private void BackToBasePosition()
    {
        _handle.transform.position = _basePosition;
    }

    private void MoveButton()
    {
        Vector3 mousePos = Input.mousePosition;

        Vector3 offset = mousePos - transform.position;

        offset = new Vector3(offset.x, offset.y, 0f);

        _handle.transform.position = transform.position + Vector3.ClampMagnitude(offset, _moveRadius);
        
    }
}