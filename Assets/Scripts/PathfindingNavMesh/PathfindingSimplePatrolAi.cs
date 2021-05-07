using System;
using UnityEngine;

namespace Pathfinding
{
    public class PathfindingSimplePatrolAi
    {
        #region Fields

        private readonly PlayerView _view;
        private readonly PathfindingStalkerAiModel _model;

        #endregion


        #region Class life cycles

        public PathfindingSimplePatrolAi(PlayerView view, PathfindingStalkerAiModel model)
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
    public struct PathfindingAIConfig
    {
        public float speed;
        public float minSqrDistanceToTarget;
        public Transform[] waypoints;
    }
}

