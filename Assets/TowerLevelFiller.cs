using CodeBase;
using CodeBase.Config;
using CodeBase.Game;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.State;
using UnityEngine;
using UnityEngine.UI;

public class TowerLevelFiller : MonoBehaviour
{
    [SerializeField] private LevelCollection _levelCollection;

    [SerializeField] private GameObject _levelPrefab;

    [SerializeField] private Transform _contentParent;

    [SerializeField] private LevelConfig _currentLevel;

    [SerializeField] private GameStateMachine _stateMachine;

    private void Start()
    {
        FillLevelTower();
    }

    public void Init(GameStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    private void FillLevelTower()
    {
        foreach (var config in _levelCollection.LevelConfigs)
        {
            GameObject level = Instantiate(_levelPrefab, _contentParent);
            level.GetComponent<Level>().Init(config);
            level.GetComponent<Button>().onClick.AddListener(() => SelectLevel(config));
        }
    }

    private void SelectLevel(LevelConfig level)
    {
        _currentLevel = level;
        FindObjectOfType<DIContainer>().Init(null, null, level);
        _stateMachine.Enter<LoadLevelState, string>(Constants.GameplaySceneName);
    }
}
