using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
    public class EnemiesConfigurator : MonoBehaviour
    {
        [Header("Simple AI")]
        [SerializeField] private PathfindingAIConfig _simplePatrolAIConfig;
        [SerializeField] private PlayerView _simplePatrolAIView;

        [Header("Stalker AI")]
        [SerializeField] private PathfindingAIConfig _stalkerAIConfig;
        [SerializeField] private PlayerView _stalkerAIView;
        [SerializeField] private Seeker _stalkerAISeeker;
        [SerializeField] private Transform _stalkerAITarget;

        [Header("Protector AI")]
        [SerializeField] private PlayerView _protectorAIView;
        [SerializeField] private AIDestinationSetter _protectorAIDestinationSetter;
        [SerializeField] private AIPatrolPath _protectorAIPatrolPath;
        [SerializeField] private LevelObjectTrigger _protectedZoneTrigger;
        [SerializeField] private Transform[] _protectorWaypoints;

        #region Fields

        private PathfindingSimplePatrolAi _simplePatrolAI;
        private PathfindingStalkerAi _stalkerAI;
        private ProtectorAI _protectorAI;
        private ProtectedZone _protectedZone;

        #endregion


        #region Unity methods

        private void Start()
        {
            _simplePatrolAI = new PathfindingSimplePatrolAi(_simplePatrolAIView, new PathfindingStalkerAiModel(_simplePatrolAIConfig));

            _stalkerAI = new PathfindingStalkerAi(_stalkerAIView, new PathfindingStalkerAiModel(_stalkerAIConfig), _stalkerAISeeker, _stalkerAITarget);
            InvokeRepeating(nameof(RecalculateAIPath), 0.0f, 1.0f);

            _protectorAI = new ProtectorAI(_protectorAIView, new PatrolAIModel(_protectorWaypoints), _protectorAIDestinationSetter, _protectorAIPatrolPath);
            _protectorAI.Init();

            _protectedZone = new ProtectedZone(_protectedZoneTrigger, new List<IProtector> { _protectorAI });
            _protectedZone.Init();
        }

        private void FixedUpdate()
        {
            if (_simplePatrolAI != null) _simplePatrolAI.FixedUpdate();
            if (_stalkerAI != null) _stalkerAI.FixedUpdate();
        }

        private void OnDestroy()
        {
            _protectorAI.Deinit();
            _protectedZone.Deinit();
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
