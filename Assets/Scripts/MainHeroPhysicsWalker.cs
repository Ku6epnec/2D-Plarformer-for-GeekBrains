using UnityEngine;

public class MainHeroPhysicsWalker
{
    private const string _verticalAxisName = "Vertical";
    private const string _horizontalAxisName = "Horizontal";

    private const float _animationsSpeed = 10;
    private const float _walkSpeed = 150;
    private const float _jumpForse = 450;
    private const float _jumpThresh = 0.1f;
    private const float _flyThresh = 1f;
    private const float _movingThresh = 0.1f;

    private bool _doJump;
    private float _goSideWay = 0;

    private readonly PlayerView _view;
    private readonly SpriteAnimatorController _spriteAnimator;
    private readonly ContactsPoller _contactsPoller;

    public MainHeroPhysicsWalker(PlayerView view, SpriteAnimatorController
        spriteAnimator)
    {
        _view = view;
        _spriteAnimator = spriteAnimator;
        _contactsPoller = new ContactsPoller(_view._collider2D);
    }

    public void FixedUpdate()
    {
        _doJump = Input.GetAxis(_verticalAxisName) > 0;
        _goSideWay = Input.GetAxis(_horizontalAxisName);
        _contactsPoller.Update();

        var walks = Mathf.Abs(_goSideWay) > _movingThresh;

        if (walks) _view._spriteRenderer.flipX = _goSideWay < 0;
        var newVelocity = 0f;
        if (walks &&
            (_goSideWay > 0 || !_contactsPoller.HasLeftContacts) &&
            (_goSideWay < 0 || !_contactsPoller.HasRightContacts))
        {
            newVelocity = Time.fixedDeltaTime * _walkSpeed *
               (_goSideWay < 0 ? -1 : 1);
        }
        _view._rigidbody2D.velocity = _view._rigidbody2D.velocity.Change(
             x: newVelocity);
        if (_contactsPoller.IsGrounded && _doJump &&
              Mathf.Abs(_view._rigidbody2D.velocity.y) <= _jumpThresh)
        {
            _view._rigidbody2D.AddForce(Vector3.up * _jumpForse);
        }

        //animations
        if (_contactsPoller.IsGrounded)
        {
            var track = walks ? AnimState.Run : AnimState.Idle;
            _spriteAnimator.StartAnimation(_view._spriteRenderer, track, true,
                _animationsSpeed);
        }
        else if (Mathf.Abs(_view._rigidbody2D.velocity.y) > _flyThresh)
        {
            var track = AnimState.Jump;
            _spriteAnimator.StartAnimation(_view._spriteRenderer, track, true,
                _animationsSpeed);
        }
    }
}

