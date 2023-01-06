using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform _followTarget;
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        Vector3 offset = new Vector3(0, 2, -5);
        transform.position = (_followTarget.position + offset) * _speed;
        transform.LookAt(_followTarget);
    }
}
