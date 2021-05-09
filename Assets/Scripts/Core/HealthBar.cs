using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private RectTransform healthBar;
        void Start()
        {

        }

        void Update()
        {

        }

        public void SetHealthBar(float currentHealthPoints, float maxHealthPoints)
        {
            healthBar.localScale = new Vector3(currentHealthPoints / maxHealthPoints, 1, 1);
        }
    }
}
