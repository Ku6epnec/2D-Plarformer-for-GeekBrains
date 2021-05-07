using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class God : MonoBehaviour
{

    [SerializeField] private SpriteAnimatorConfig playerConfig;
    [SerializeField] private PlayerView _playerView;

    [SerializeField] private PinkyView _pinkyView;
    [SerializeField] private SpriteAnimatorConfig pinkyConfig;
    private PinkyWalker pinkyWalker;

    [SerializeField] private PlayerView _waterView;
    [SerializeField] private SpriteAnimatorConfig waterConfig;
    private WaterAnimation waterAnimation;

    [SerializeField] private MainHeroPhysicsWalker mainHeroPhysicsWalker;

    [SerializeField] private LevelCompleteManager levelCompleteManager;

    [SerializeField] private CannonView cannonView;

    [SerializeField] private BulletView _bulletView;

    [SerializeField] private Transform bulletsEmitterTransform;

    private BulletsEmitter bulletsEmitter;

    [SerializeField] private Text _text;


    [SerializeField] private List<PlayerView> _wins;
    [SerializeField] private List<PlayerView> _loose;

    private SpriteAnimatorController _playerAnimatorController;

    private SpriteAnimatorController _pinkyAnimatorController;

    private SpriteAnimatorController _waterAnimatorController;

    private AimingMuzzle aimingMuzzle;
    private Bullet _bullet;

    private int _animationSpeed = 10;

    /*[SerializeField] private PlayerView _patrolView;
    public AIConfig aIConfig;
    private SimplePatrolAIModel simplePatrolAIModel;
    private EnemiesConfigurators enemiesConfigurator;
    private SimplePatrolAI simplePatrolAI;*/


    private void Awake()
    {        
        levelCompleteManager = new LevelCompleteManager(_playerView, _loose, _wins, _text);

        playerConfig = Resources.Load<SpriteAnimatorConfig>("AnimPlayerCfg");
        _playerAnimatorController = new SpriteAnimatorController(playerConfig);
        _playerAnimatorController.StartAnimation(_playerView._spriteRenderer, AnimState.Run, true, _animationSpeed);
        mainHeroPhysicsWalker = new MainHeroPhysicsWalker(_playerView, _playerAnimatorController);


        pinkyConfig = Resources.Load<SpriteAnimatorConfig>("AnimPinkyCfg");
        _pinkyAnimatorController = new SpriteAnimatorController(pinkyConfig);
        _pinkyAnimatorController.StartAnimation(_pinkyView._spriteRenderer, AnimState.Idle, true, _animationSpeed);
        pinkyWalker = new PinkyWalker(_pinkyView, _pinkyAnimatorController);

        waterConfig = Resources.Load<SpriteAnimatorConfig>("AnimWaterCfg");
        _waterAnimatorController = new SpriteAnimatorController(waterConfig);
        _waterAnimatorController.StartAnimation(_waterView._spriteRenderer, AnimState.Run, true, _animationSpeed);
        waterAnimation = new WaterAnimation(_waterView, _waterAnimatorController);


        aimingMuzzle = new AimingMuzzle(cannonView._muzzleTransform, cannonView._aimTransform);

        bulletsEmitter = new BulletsEmitter(cannonView._bullets, bulletsEmitterTransform);

        /*simplePatrolAIModel = new SimplePatrolAIModel(aIConfig);
        simplePatrolAI = new SimplePatrolAI(_patrolView, simplePatrolAIModel);*/

    }

    private void Update()
    {
        _playerAnimatorController.Update();

        _pinkyAnimatorController.Update();
        pinkyWalker.Update();

        _waterAnimatorController.Update();
        waterAnimation.Update();

        aimingMuzzle.Update();
        bulletsEmitter.Update();

    }

    private void FixedUpdate()
    {
        mainHeroPhysicsWalker.FixedUpdate();
    }

}
