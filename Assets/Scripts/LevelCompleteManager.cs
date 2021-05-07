using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompleteManager : IDisposable
{

    private Text _text;
    
    private Vector3 _startPosition;
    private PlayerView _characterView;
    private List<PlayerView> _deathZones;
    private List<PlayerView> _winZones;

    public LevelCompleteManager(PlayerView characterView, List<PlayerView> deathZones, List<PlayerView> winZones, Text text)
    {
        _startPosition = characterView._transform.position;
        characterView.OnLevelObjectContact += OnLevelObjectContact;

        _characterView = characterView;
        _deathZones = deathZones;
        _winZones = winZones;
        _text = text;
}

    private void OnLevelObjectContact(PlayerView contactView)
    {
        if (_deathZones.Contains(contactView))
        {
            _characterView._transform.position = _startPosition;
        }

        if (_winZones.Contains(contactView))
        {
            _text.text = "Вы выйграли!";
            Time.timeScale = 0;
        }
    }

    public void Dispose()
    {
        _characterView.OnLevelObjectContact -= OnLevelObjectContact;
    }
}
