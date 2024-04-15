using CodeBase.Config;
using UnityEngine;

public class EnemyReward : MonoBehaviour
{
    [SerializeField] private float _enemyReward;
    [SerializeField] private MainPlayerConfig _mainPlayer;

    public void Init(float enemyReward, MainPlayerConfig mainPlayer)
    {
        _enemyReward = enemyReward;
        _mainPlayer = mainPlayer;
    }
    
    private void OnDestroy()
    {
        _mainPlayer.IncreaseBalance(_enemyReward);
    }
}