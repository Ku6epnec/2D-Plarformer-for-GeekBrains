using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController
{
    private Transform _camera;
    private Transform _back;
    private Transform _middle;
    private Transform _foreground;

    private Vector3 _cameraStartPosition;
    private Vector3 _foregroundStartPosition;
    private Vector3 _middleStartPosition;
    private Vector3 _backStartPosition;
    private Vector3 _groundStartPosition;

    private float _speed;
    private const float _coef = 0.3f;

    /// <summary>
    /// ƒолжны быть закешированные ссылки т.к. при инициализации конструктора мы по факту вызываем GetComponent
    /// </summary>
    /// <param name="camera"></param>
    /// <param name="foreground"></param>
    /// <param name="middle"></param>
    /// <param name="back"></param>
    public ParallaxController(Transform camera, Transform foreground, Transform middle, Transform back)
    {
        _camera = camera;

        _foreground = foreground;
        _middle = middle;
        _back = back;

        _cameraStartPosition = _camera.position;
        _foregroundStartPosition = _foreground.position;
        _middleStartPosition = _middle.position;
        _backStartPosition = _back.position;
    }


    public void Update()
    {
        _back.position = _backStartPosition + (_camera.position - _cameraStartPosition) * _coef;
        _middle.position = _middleStartPosition + (_camera.position - _cameraStartPosition) * (_coef * 2);
        _foreground.position = _foregroundStartPosition + (_camera.position - _cameraStartPosition) * (_coef * 3);
    }

}