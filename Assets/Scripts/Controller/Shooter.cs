using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private GameObject projectile = null;
        [SerializeField] private Transform shootPoint = null;
        [SerializeField] private float shootFrequency = 1f;
        [HideInInspector] public Crosshair crosshair;
        private float lastShootTime;

        void Start()
        {
            lastShootTime = shootFrequency;
            crosshair = GameObject.FindWithTag("Crosshair").GetComponent<Crosshair>();
        }

        void Update()
        {
            if (crosshair.isShooting)
            {
                lastShootTime += Time.deltaTime;

                if (lastShootTime >= shootFrequency)
                {
                    Instantiate(projectile, shootPoint.position, shootPoint.rotation);
                    GetComponent<AudioSource>().Play();
                    lastShootTime = 0;
                }
            }
        }
    }
}
