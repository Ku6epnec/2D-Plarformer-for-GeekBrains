using UnityEngine;

class PhysicsBullet
{
    private BulletView _view;

    public PhysicsBullet(BulletView view)
    {
        _view = view;
        _view.SetVisible(false);
    }

    public void Throw(Vector3 position, Vector3 velocity)
    {
        _view.SetVisible(false);
        _view._transform.position = position;
        _view._rigidbody2D.velocity = Vector2.zero;
        _view._rigidbody2D.angularVelocity = 0;
        _view._rigidbody2D.AddForce(velocity, ForceMode2D.Impulse);
        _view.SetVisible(true);
    }
}
