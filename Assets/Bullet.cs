using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed;
    private Transform place;
    private Transform[] _places;
    private int _placeNumber;

    void Start()
    {
        _places = new Transform[place.childCount];

        for (int i = 0; i < place.childCount; i++)
            _places[i] = place.GetChild(i).GetComponent<Transform>();
    }

    public void Update()
    {
        var target = _places[_placeNumber];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position) GetNextPlace();
    }

    public Vector3 GetNextPlace()
    {
        _placeNumber++;

        if (_placeNumber == _places.Length)
            _placeNumber = 0;

        var bulletVector = _places[_placeNumber].transform.position;
        transform.forward = bulletVector - transform.position;

        return bulletVector;
    }
}