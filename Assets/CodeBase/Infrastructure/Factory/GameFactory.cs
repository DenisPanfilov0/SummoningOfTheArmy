using CodeBase.Infrastructure.AssetManagement;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    internal class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;
        private int _maxLevel;
        private int _currentLevel;
        private GameObject _gridCells;
        private TextMeshProUGUI _questionField;

        public GameFactory(IAssets assets)
        {
            _assets = assets;
        }

        public GameObject CreateCanvas() => 
            Instantiate(AssetPath.CanvasPath);

        public GameObject CreateGrid(Transform at) => 
            Instantiate(AssetPath.GridPath, at);

        public GameObject CreateCanvasLobby() =>
            Instantiate(AssetPath.CanvasLobbyPath);
        
        public GameObject CreateCanvasGamePlay() =>
            Instantiate(AssetPath.CanvasGamePlayPath);

        public GameObject CreateDIContainer() => 
            Instantiate(AssetPath.DIContainerPath);


        private GameObject Instantiate(string prefabPath)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath);
            return gameObject;
        }

        private GameObject Instantiate(string prefabPath, Transform at)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath, at);
            return gameObject;
        }
    }
}