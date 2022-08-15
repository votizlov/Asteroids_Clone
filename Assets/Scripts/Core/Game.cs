using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core
{
    public class Game
    {
        public Action<int> OnScoreChanged;
        private int points;

        public GameCore GameCore { get; set; }

        private static Game instance;

        private Game()
        {
            Application.targetFrameRate = 60;
        }

        public static Game Instance()
        {
            if (instance == null)
                instance = new Game();
            return instance;
        }

        public void ShowMainMenu()
        {
            if (GameCore.PlayerInstance != null)
                Object.Destroy(GameCore.PlayerInstance);
            GameCore.spawner.gameObject.SetActive(false);
            foreach (var enemy in GameCore.Enemies)
            {
                Object.Destroy(enemy);
            }
            
            GameCore.menuScreen.SetActive(true);
            
            //GameObject.Instantiate(GameContext.PlayerInstance, GameContext.);
        }

        public void ShowRestartScreen()
        {
        }

        public void RestartGame()
        {
            points = 0;
        }
    }
}