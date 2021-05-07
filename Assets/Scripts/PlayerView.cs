using System;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public Transform _transform;
    public SpriteRenderer _spriteRenderer;
    public Collider2D _collider2D;
    public Rigidbody2D _rigidbody2D;

    public Action<PlayerView> OnLevelObjectContact { get; set; }

    void OnTriggerEnter2D(Collider2D collider)
    {
        var levelObject = collider.gameObject.GetComponent<PlayerView>();
        OnLevelObjectContact?.Invoke(levelObject);
    }

}
