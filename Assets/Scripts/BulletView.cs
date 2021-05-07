using UnityEngine;

public class BulletView: MonoBehaviour
{
    [SerializeField]
    public TrailRenderer _trail;

    public Transform _transform;
    public SpriteRenderer _spriteRenderer;
    public Collider2D _collider2D;
    public Rigidbody2D _rigidbody2D;

    public void SetVisible(bool visible)
    {
        if (_trail) _trail.enabled = visible;
        if (_trail) _trail.Clear();
        _spriteRenderer.enabled = visible;
    }
}