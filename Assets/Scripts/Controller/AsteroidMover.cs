using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class AsteroidMover : MonoBehaviour
    {   
        [SerializeField] private float damage = 1f;
        private Transform spaceship;
        static private float speed = 0.6f;
        static private float elapsedTime;
        static private float multiplier = 1f;

        void Start()
        {
            spaceship = GameObject.FindWithTag("Spaceship").transform;
        }
       
        void Update()
        {
            transform.position += -spaceship.transform.forward * speed * Time.deltaTime;

            if (transform.position.z < spaceship.position.z - 1)
            {
                spaceship.GetComponent<Health>().TakeDamage(damage);
                Destroy(gameObject);
            }

            elapsedTime += Time.deltaTime;
            if (elapsedTime >= multiplier * 20f)
            {
                multiplier++;
                speed *= (30f / 29f);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Spaceship"))
            {
                other.GetComponent<Health>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
