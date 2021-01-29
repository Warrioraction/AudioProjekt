using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float backgroundSize;

    private Transform _cameraTransform;
    private Transform[] _layers;
    private Vector3 _previousCamPosition;
    private float viewZone = 10;
    private int _leftIndex;
    private int _rightIndex;

    public void Start()
    {
        if (Camera.main != null) 
            _cameraTransform = Camera.main.transform;
        _layers = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _layers[i] = transform.GetChild(i);
        }

        _leftIndex = 0;
        _rightIndex = _layers.Length - 1;
    }

    private void Update()
    {
        if (_cameraTransform.position.x < (_layers[_leftIndex].transform.position.x + viewZone))
            ScrollLeft();
        
        else if (_cameraTransform.position.x > (_layers[_rightIndex].transform.position.x - viewZone))
            ScrollRight();
        
    }

    private void ScrollLeft()
    {
        int lastRight = _rightIndex;
        _layers[_rightIndex].position = Vector3.right * (_layers[_leftIndex].position.x - backgroundSize);
        _leftIndex = _rightIndex;
        _rightIndex--;
        if (_rightIndex < 0)
            _rightIndex = _layers.Length - 1;
    }

    private void ScrollRight()
    {
        int lastLeft = _leftIndex;
        _layers[_leftIndex].position = Vector3.right * (_layers[_rightIndex].position.x + backgroundSize);
        _rightIndex = _leftIndex;
        _leftIndex++;
        if (_leftIndex == _layers.Length)
            _leftIndex = 0;
    }
}
