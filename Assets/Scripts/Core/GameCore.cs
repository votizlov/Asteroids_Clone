using System.Collections.Generic;
using Objects;
using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    public class GameCore : MonoBehaviour
    {
        public Player playerPrefab;

        public GameObject menuScreen;
        public GameObject gameScreen;
        public GameObject restartScreen;
        public ObjectsSpawner spawner;
        public GameObject PlayerInstance;
        public List<GameObject> Enemies;
        public UnityEvent OnShowMenu;
        public UnityEvent OnRestartGame;
        void Awake()
        {
            Application.targetFrameRate = 60;
            Game.Instance().GameCore = this;
            Game.Instance().ShowMainMenu();
        }

        public void StartGame()
        {
            Game.Instance().RestartGame();
        }
    }
}
