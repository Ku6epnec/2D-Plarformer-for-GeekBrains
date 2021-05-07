using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class CameraController
    {
        private float X;
        private float Y;
        private float OffsetX = 1.5f;
        private float OffsetY = 1.5f;
        private int CamSpeed = 300;
        private Transform _playerTransform;
        private Transform _mCamTransform;

        public CameraController(Transform _player, Transform _camera)
        {
            _playerTransform = _player;
            _mCamTransform = _camera;
        }

        public void Update()
        {
            X = _playerTransform.position.x;
            Y = _playerTransform.position.y;

            _mCamTransform.transform.position = Vector3.Lerp(_mCamTransform.transform.position,
                                                   new Vector3(X + OffsetX, Y + OffsetY, _mCamTransform.transform.position.z),
                                                   Time.deltaTime * CamSpeed);
        }
    }
}

