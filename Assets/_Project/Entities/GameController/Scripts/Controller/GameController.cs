﻿using UnityEngine;
using System.Collections;
using Assets.Scripts;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MetaphoricalSheep.UnityTools.Audio;
using TwoBirds.GameEngine.Controllers;

namespace SpaceShooter.Entities.Scripts.Controller
{
    public class GameController : AbstractGameController
    {
        private const float easeDuration = 0.3f;

        public GameObject[] Hazards;
        public Vector3 SpawnValues;
        public int HazardCount;

        public Text ScoreText;
        public Text restartText;
        public Text gameOverText;
        public Text pauseText;
        public Canvas _settingsMenu;

        public static PlayerStats PlayerStats = new PlayerStats();

        public float SpawnWait;
        public float StartWait;
        public float WaveWait;

        public static bool isPaused;
        public static bool IsGameOver;

        public static System.Action<int> GameOverEvent;
        public static System.Action PauseEvent;
        public static System.Action ResumeEvent;

        private int score;
        private bool restart;
        private AudioSource gameMusic;
        private bool _isMenuOpen;

        public void Start()
        {
            Setup();
            StartCoroutine(SpawnWaves());
        }

        public void Update()
        {
            HandleRestartKey();
            HandlePauseKey();
            HandleMenuKey();
        }

        public void AddScore(int score)
        {
            this.score += score;
            UpdateScore();
        }

        public void GameOver()
        {
            IsGameOver = true;
            gameOverText.text = "Game Over!";
            gameMusic.EasePitch(3f, 0.45f);
            GameOverEvent?.Invoke(score);
        }

        public void OnGameResumed()
        {
            ResumeGame();
            PauseEvent?.Invoke();
            _isMenuOpen = false;
            _settingsMenu.enabled = false;
        }

        private IEnumerator SpawnWaves()
        {
            yield return new WaitForSeconds(StartWait);

            while (true)
            {
                for (int i = 0; i < HazardCount; i++)
                {
                    GameObject hazard = Hazards[Random.Range(0, Hazards.Length)];
                    Vector3 spawnPosition = new Vector3(Random.Range(-SpawnValues.x, SpawnValues.x), SpawnValues.y, SpawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard, spawnPosition, spawnRotation);

                    yield return new WaitForSeconds(SpawnWait);
                }

                yield return new WaitForSeconds(WaveWait);

                if (IsGameOver)
                {
                    string key = "'R'".Highlight();
                    restartText.text = $"Press {key} to Restart";
                    restart = true;
                    break;
                }
            }
        }

        private void UpdateScore()
        {
            ScoreText.text = $"Score: {score.ToString().Highlight()}";
        }

        private void Setup()
        {
            restartText.text = "";
            gameOverText.text = "";
            pauseText.text = "";
            gameMusic = GetComponent<AudioSource>();
            UpdateScore();
            ResumeGame();
        }

        private void HandleMenuKey()
        {
            if (!Input.GetKeyDown(KeyCode.Escape))
            {
                return;
            }

            if (_isMenuOpen)
            {
                _settingsMenu.enabled = false;
                _isMenuOpen = false;
                ResumeGame();
                PauseEvent?.Invoke();
                return;
            }

            _settingsMenu.enabled = true;
            _isMenuOpen = true;
            PauseGame();
            PauseEvent?.Invoke();
        }

        private void HandleRestartKey()
        {
            if (restart)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    gameMusic.EasePitch(3f, 1f);

                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }

        private void HandlePauseKey()
        {
            if (Input.GetKeyDown(KeyCode.P) && !_isMenuOpen)
            {
                OnPauseKey();
            }
        }

        private void OnPauseKey()
        {
            if (isPaused)
            {
                ResumeGame();
                return;
            }

            PauseGame();
            PauseEvent?.Invoke();
        }

        private void PauseGame()
        {
            Time.timeScale = 0;
            isPaused = true;
            string key = "'P'".Highlight();
            pauseText.text = $"Press {key} to Resume";
            gameMusic.Fade(easeDuration, 0.1f);
            PauseEvent?.Invoke();
        }

        private void ResumeGame()
        {
            Time.timeScale = 1.0f;
            isPaused = false;
            string key = "'P'".Highlight();
            pauseText.text = $"Press {key} to Pause";
            gameMusic.FadeIn(easeDuration, 0.3f);
            ResumeEvent?.Invoke();
        }
    }
}
