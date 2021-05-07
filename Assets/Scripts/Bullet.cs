using UnityEngine;

public class Bullet
{

    private Vector3 _velocity;

    private BulletView _view;

    public Bullet(BulletView view)
    {
        _view = view;
        Active(false);
    }

    public void Throw(Vector3 position, Vector3 velocity)
    {
        Active(true);
        SetVelocity(velocity);
        _view._transform.position = position;
        _view._rigidbody2D.velocity = Vector2.zero;
        _view._rigidbody2D.angularVelocity = 0;
        _view._rigidbody2D.AddForce(velocity, ForceMode2D.Impulse);
        Active(true);
    }

    private void SetVelocity(Vector3 velocity)
    {
        _velocity = velocity;
        var angle = Vector3.Angle(Vector3.left, _velocity);
        var axis = Vector3.Cross(Vector3.left, _velocity);
        _view._transform.rotation = Quaternion.AngleAxis(angle, axis); 
    }

    public void Active(bool val)
    {
        _view._trail.enabled = val;
        _view.gameObject.SetActive(val);
    }
}