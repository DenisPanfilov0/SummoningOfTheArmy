using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateCanvas();
        
        GameObject CreateGrid(Transform at);

        GameObject CreateCanvasLobby();
        
        GameObject CreateDIContainer();
    }
}