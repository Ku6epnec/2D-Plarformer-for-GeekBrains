using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
    public class PathfindingEnemiesConfigurators : MonoBehaviour
    {
        [Header("Simple AI")]
        [SerializeField] private PathfindingAIConfig _simplePatrolAIConfig;
        [SerializeField] private PlayerView _simplePatrolAIView;

        [Header("Stalker AI")]
        [SerializeField] private PathfindingAIConfig _stalkerAIConfig;
        [SerializeField] private PlayerView _stalkerAIView;
        [SerializeField] private Seeker _stalkerAISeeker;
        [SerializeField] private Transform _stalkerAITarget;

        #region Fields

        private PathfindingSimplePatrolAi _simplePatrolAI;
        private PathfindingStalkerAi _stalkerAI;

        #endregion


        #region Unity methods

        private void Start()
        {
            _simplePatrolAI = new PathfindingSimplePatrolAi(_simplePatrolAIView, new PathfindingStalkerAiModel(_simplePatrolAIConfig));

            _stalkerAI = new PathfindingStalkerAi(_stalkerAIView, new PathfindingStalkerAiModel(_stalkerAIConfig), _stalkerAISeeker, _stalkerAITarget);
            InvokeRepeating(nameof(RecalculateAIPath), 0.0f, 1.0f);
        }

        private void FixedUpdate()
        {
            if (_simplePatrolAI != null) _simplePatrolAI.FixedUpdate();
            if (_stalkerAI != null) _stalkerAI.FixedUpdate();
        }

        #endregion

        #region Methods

        private void RecalculateAIPath()
        {
            _stalkerAI.RecalculatePath();
        }

        #endregion
    }

}