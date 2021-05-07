using System;
using UnityEngine;

namespace Pathfinding
{
    public class PathfindingStalkerAi
    {
        #region Fields
        private readonly PlayerView _view;
        private readonly PathfindingStalkerAiModel _model;
        private readonly Seeker _seeker;
        private readonly Transform _target;
        #endregion

        #region Class life cycles

        public PathfindingStalkerAi(PlayerView view, PathfindingStalkerAiModel model, Seeker seeker, Transform target)
        {
            _view = view != null ? view : throw new ArgumentNullException(nameof(view));
            _model = model != null ? model : throw new ArgumentNullException(nameof(model));
            _seeker = seeker != null ? seeker : throw new ArgumentNullException(nameof(seeker));
            _target = target != null ? target : throw new ArgumentNullException(nameof(target));
        }

        #endregion

        #region Methods

        public void FixedUpdate()
        {
            var newVelocity = _model.CalculateVelocity(_view._transform.position) * Time.fixedDeltaTime;
            _view._rigidbody2D.velocity = newVelocity;
        }

        public void RecalculatePath()
        {
            if (_seeker.IsDone())
            {
                _seeker.StartPath(_view._rigidbody2D.position, _target.position, OnPathComplete);
            }
        }

        private void OnPathComplete(Path p)
        {
            if (p.error) return;
            _model.UpdatePath(p);
        }

        #endregion
    }
}


