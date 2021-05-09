using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private Text score;
        private int scorePoints = 0;
        public int ScorePoints { get => scorePoints; set => scorePoints = value; }

        void Start()
        {

        }

        void Update()
        {

        }

        public void SetScorePoints()
        {
            scorePoints++;
            score.text = "Score: " + scorePoints;
        }
    }
}
