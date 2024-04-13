using CodeBase.Config;
using TMPro;
using UnityEngine;

namespace CodeBase
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentLevel;
        
        //TODO плохой нейминг
        [SerializeField] private LevelConfig _levelConfig;
    }
}
