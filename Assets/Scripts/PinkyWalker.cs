using UnityEngine;

public class PinkyWalker
{
    private const float _animationsSpeed = 10f;
    private PinkyView _view;
    private SpriteAnimatorController _spriteAnimator;

    public PinkyWalker(PinkyView view, SpriteAnimatorController spriteAnimator)
    {
        _view = view;
        _spriteAnimator = spriteAnimator;
    }

    public void Update()
    {
        _spriteAnimator.StartAnimation(_view._spriteRenderer, AnimState.Idle, true, _animationsSpeed);
    }
}
