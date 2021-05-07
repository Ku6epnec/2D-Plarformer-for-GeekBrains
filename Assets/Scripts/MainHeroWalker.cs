using UnityEngine;

public class MainHeroWalker
{
    private const float _walkSpeed = 3f;
    private const float _animationsSpeed = 10f;
    private const float _animationsJumpSpeed = 1f;
    private const float _jumpStartSpeed = 8f;
    private const float _movingThresh = 0.1f;
    private const float _flyThresh = 1f;
    private const float _flyFreezePoint = 5f;
    private const float _groundLevel = 0.5f;
    private const float _g = -10f;

    //private const float _jumpForce = 5f;

    private Vector3 _leftScale = new Vector3(-1, 1, 1);
    private Vector3 _rightScale = new Vector3(1, 1, 1);

    private bool _freeze = false;
    private float _yVelocity;
    private bool _doJump;
    private float _xAxisInput;

    private PlayerView _view;
    private SpriteAnimatorController _spriteAnimator;

    public MainHeroWalker(PlayerView view, SpriteAnimatorController spriteAnimator)
    {
        _view = view;
        _spriteAnimator = spriteAnimator;
    }

    public void Update()
    {
        _doJump = Input.GetAxis("Vertical") > 0;
        _xAxisInput = Input.GetAxis("Horizontal");
        var goSideWay = Mathf.Abs(_xAxisInput) > _movingThresh;

        if (IsGrounded())
        {
            _freeze = false;

            if (goSideWay) GoSideWay();
            _spriteAnimator.StartAnimation(_view._spriteRenderer, goSideWay ? AnimState.Run : AnimState.Idle, true, _animationsSpeed);

            if (_doJump && _yVelocity == 0)
            {
                _yVelocity = _jumpStartSpeed;
            }
            else if (_yVelocity < 0)
            {
                _yVelocity = 0;
            }
        }
        else
        {
            if (goSideWay) GoSideWay();
            if (Mathf.Abs(_yVelocity) > _flyThresh && Mathf.Abs(_yVelocity) < _flyFreezePoint || _freeze)
            {
                _freeze = true;
                _spriteAnimator.StartAnimation(_view._spriteRenderer, AnimState.Fly, true, _animationsJumpSpeed);
            }
            else if (Mathf.Abs(_yVelocity) > _flyFreezePoint && !_freeze)
            {
                _freeze = false;
                _spriteAnimator.StartAnimation(_view._spriteRenderer, AnimState.Jump, true, _animationsSpeed);
            }

            _yVelocity += _g * Time.deltaTime;
            _view._transform.position += Vector3.up * (Time.deltaTime * _yVelocity);
            //_view._rigidbody2D.AddForce(Vector3.up * _jumpForce);
        }
    }

    private void GoSideWay()
    {
        _view._transform.position += Vector3.right * (Time.deltaTime * _walkSpeed * (_xAxisInput < 0 ? -1 : 1));
        _view._transform.localScale = (_xAxisInput < 0 ? _leftScale : _rightScale);
    }

    public bool IsGrounded()
    {
        return _view._transform.position.y <= _groundLevel + float.Epsilon && _yVelocity <= 0;
    }
}
