using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class AsteroidSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] asteroids = null;
        [SerializeField] private MovementController spaceship = null;
        [SerializeField] private float timeForNextSpawn = 3f;
        private float spaceshipX;
        private float elapsedTime;
        private float multiplier = 1;

        void Start()
        {
            spaceshipX = spaceship.transform.position.x;
            StartCoroutine(SpawnAsteroid(timeForNextSpawn));
        }

        void Update()
        {
            elapsedTime += Time.deltaTime;
            if(elapsedTime >= multiplier * 20f)
            {
                multiplier++;
                timeForNextSpawn *= (29f/30f);
            }
        }

        private IEnumerator SpawnAsteroid(float waitTime)
        {
            int randomIndex = Random.Range(0, asteroids.Length);
            float randomX = Random.Range(spaceshipX - (spaceship.MaxMovementDistance / 2f),
                spaceshipX + (spaceship.MaxMovementDistance / 2f));

            Instantiate(asteroids[randomIndex], new Vector3(randomX, spaceship.transform.position.y, transform.position.z), transform.rotation);
            yield return new WaitForSeconds(waitTime);           
            StartCoroutine(SpawnAsteroid(timeForNextSpawn));
        }
    }
}
