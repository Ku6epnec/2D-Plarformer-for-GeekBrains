using UnityEngine;

public class EnemiesConfigurators : MonoBehaviour
{
    [SerializeField] private AIConfig _simplePatrolAIConfig;
    [SerializeField] private PlayerView _simplePatrolAIView;

    #region Fields

    private SimplePatrolAI _simplePatrolAI;

    #endregion


    #region Unity methods

    private void Start()
    {
        _simplePatrolAI = new SimplePatrolAI(_simplePatrolAIView, new SimplePatrolAIModel(_simplePatrolAIConfig));
    }

    private void FixedUpdate()
    {
        if (_simplePatrolAI != null) _simplePatrolAI.FixedUpdate();
    }

    #endregion
}

