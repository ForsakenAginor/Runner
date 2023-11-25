using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class Parallax : MonoBehaviour
{
    [SerializeField] private float _speed;

    private RawImage _image;
    private float _imagePositionX;
    private float _positionLimit = 1;

    private void Awake()
    {
        _image = GetComponent<RawImage>();
    }

    private void Update()
    {
        _imagePositionX += _speed * Time.deltaTime;

        if( _imagePositionX > _positionLimit)
            _imagePositionX = 0;

        _image.uvRect = new Rect(_imagePositionX, 0, _image.uvRect.width, _image.uvRect.height);
    }
}