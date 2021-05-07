using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class Lesson : MonoBehaviour
    {
        [SerializeField] Camera _camera;
        private SpriteAnimatorController _coinAnimator;

        [SerializeField] private PlayerView _playerView;
        
        [SerializeField] private List<PlayerView> _coinsList;
        private CoinsManager _coinsManager;
        private CameraController _cameraMotor;

        void Awake()
        {
           
            SpriteAnimatorConfig coinConfig = Resources.Load<SpriteAnimatorConfig>("CoinAnimCfg");
            _coinAnimator = new SpriteAnimatorController(coinConfig);

            _cameraMotor = new CameraController(_playerView.transform, _camera.transform);

             _coinsManager = new CoinsManager(_playerView, _coinsList, _coinAnimator);
        }

        void Update()
        { 
            _coinAnimator.Update();
            _cameraMotor.Update();
        }
    }
}