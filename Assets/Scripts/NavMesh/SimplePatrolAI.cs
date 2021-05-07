using System;
using UnityEngine;

public class SimplePatrolAI
{
    #region Fields

    private readonly PlayerView _view;
    private readonly SimplePatrolAIModel _model;

    #endregion


    #region Class life cycles

    public SimplePatrolAI(PlayerView view, SimplePatrolAIModel model)
    {
        _view = view != null ? view : throw new ArgumentNullException(nameof(view));
        _model = model != null ? model : throw new ArgumentNullException(nameof(model));
    }

    public void FixedUpdate()
    {
        var newVelocity = _model.CalculateVelocity(_view._transform.position) * Time.fixedDeltaTime;
        _view._rigidbody2D.velocity = newVelocity;
    }

    #endregion
}

[Serializable]
public struct AIConfig
{
    public float speed;
    public float minSqrDistanceToTarget;
    public Transform[] waypoints;
}

