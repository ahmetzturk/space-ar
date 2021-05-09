using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float maxHealthPoints = 5;
        private HealthBar healthBar;
        private float currentHealthPoints;
        public bool isDead = false;
        void Start()
        {
            healthBar = GameObject.FindWithTag("Health Bar").GetComponent<HealthBar>();       
            currentHealthPoints = maxHealthPoints;
        }

        void Update()
        {
            if (currentHealthPoints == 0)
            {
                isDead = true;
                currentHealthPoints = maxHealthPoints;
            }
        }

        public void TakeDamage(float damage)
        {
            currentHealthPoints = Mathf.Max(0, currentHealthPoints - damage);
            healthBar.SetHealthBar(currentHealthPoints, maxHealthPoints);
        }
    }
}
