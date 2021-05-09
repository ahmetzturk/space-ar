using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Score score;
        [SerializeField] private GameObject finishScreen = null;
        [SerializeField] private Text highScoreText = null;
        private GameObject spaceAR;
        private int highScore = 0;

        private void Start()
        {
            //PlayerPrefs.DeleteAll();
        }

        public int HighScore
        {
            get
            {   
                int prevHighScore = PlayerPrefs.GetInt("HighScore");               
                highScore = score.ScorePoints;

                if (highScore > prevHighScore)
                {
                    PlayerPrefs.SetInt("HighScore", highScore);
                }

                return PlayerPrefs.GetInt("HighScore");
            }
        }

        public void ShowHighScore()
        {
            highScoreText.text = "High Score: " + HighScore;
        }

        public void SaveHighScore()
        {
            if (!PlayerPrefs.HasKey("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score.ScorePoints);
                print(PlayerPrefs.GetInt("HighScore"));
            }
        }

        public void EndGame()
        {
            spaceAR = GameObject.FindWithTag("SpaceAR");

            GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");

            foreach (var asteroid in asteroids)
            {
                Destroy(asteroid);
            }

            foreach (var projectile in projectiles)
            {
                Destroy(projectile);
            }

            GetComponent<AudioSource>().Stop();

            spaceAR.SetActive(false);
            finishScreen.SetActive(true);
            SaveHighScore();
            ShowHighScore();
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
