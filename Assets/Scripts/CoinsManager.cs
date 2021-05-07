using System;
using System.Collections.Generic;
using UnityEngine;

public class CoinsManager : IDisposable
{
    private const float _animationsSpeed = 10;

    private PlayerView _characterView;
    private SpriteAnimatorController _spriteAnimator;
    private List<PlayerView> _coinViews;

    public CoinsManager(PlayerView characterView, List<PlayerView> coinViews, SpriteAnimatorController spriteAnimator)
    {
        _characterView = characterView;
        _spriteAnimator = spriteAnimator;
        _coinViews = coinViews;
        _characterView.OnLevelObjectContact += OnLevelObjectContact;

        foreach (var coinView in coinViews)
        {
            _spriteAnimator.StartAnimation(coinView._spriteRenderer, AnimState.Run, true, _animationsSpeed);
        }
    }

    private void OnLevelObjectContact(PlayerView contactView)
    {
        if (_coinViews.Contains(contactView))
        {
            _spriteAnimator.StopAnimation(contactView._spriteRenderer);
            GameObject.Destroy(contactView.gameObject);
        }
    }

    public void Dispose()
    {
        _characterView.OnLevelObjectContact -= OnLevelObjectContact;
    }
}

