using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAnimation : MonoBehaviour
{
    private const float _animationsSpeed = 10f;
    private PlayerView _view;
    private SpriteAnimatorController _spriteAnimator;

    public WaterAnimation(PlayerView view, SpriteAnimatorController spriteAnimator)
    {
        _view = view;
        _spriteAnimator = spriteAnimator;
    }

    public void Update()
    {
        _spriteAnimator.StartAnimation(_view._spriteRenderer, AnimState.Run, true, _animationsSpeed);
    }
}
