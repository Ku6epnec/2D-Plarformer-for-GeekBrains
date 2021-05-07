using UnityEngine;

namespace Level
{
    public class LevelCreator : MonoBehaviour
    {
        [SerializeField]
        private GenerateLevelView _generateLevelView;

        private AutoGeneratorLevelController _generatorLevelController;

        private void Awake()
        {
            _generatorLevelController = new AutoGeneratorLevelController(_generateLevelView);
            _generatorLevelController.Awake();
        }
    }
}