using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _endPosition;
    
    [SerializeField] private float _speed = 5f;

    private void Update()
    {
        // TODO when player hops on the platform then start move
        MovePlatform();
    }


    // TODO make it it could go back
    private void MovePlatform()
    {
        float step = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _endPosition.position, step);
    }
}
