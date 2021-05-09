using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class ShootMover : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;
        [SerializeField] private float maxTimeToDestroy = 5f;
        private Score score;
        private float elapsedTime = 0;

        void Start()
        {
            score = GameObject.FindWithTag("Score").GetComponent<Score>();
        }
    
        void Update()
        {
            elapsedTime += Time.deltaTime;
            if(elapsedTime >= maxTimeToDestroy)
            {
                Destroy(gameObject);
            }
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                score.SetScorePoints();

                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}