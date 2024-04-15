using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateCanvas();
        
        GameObject CreateObject(string path, Transform at);

        GameObject CreateCanvasLobby();
        
        GameObject CreateCanvasGamePlay();
        
        GameObject CreateDIContainer();
    }
}