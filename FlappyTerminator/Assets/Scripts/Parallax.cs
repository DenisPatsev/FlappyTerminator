using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    [SerializeField] private RawImage _image;
    [SerializeField] private float _speed;

    private float _imagePositionX;

    private void Update()
    {
        _imagePositionX += _speed * Time.deltaTime;

        _image.uvRect = new Rect(_imagePositionX, 0, _image.uvRect.width, _image.uvRect.height);
    }
}
