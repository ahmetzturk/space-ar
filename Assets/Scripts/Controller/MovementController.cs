using Core;
using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;
        [SerializeField] private float maxMovementDistance = 1f;
        [SerializeField] private GameObject explosion = null;
        [SerializeField] private MeshRenderer spaceshipMeshRenderer = null;
        private GameManager gameManager;
        private float rightX, leftX;

        public float MaxMovementDistance { get => maxMovementDistance; }

        void Start()
        {
            gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

            rightX = transform.position.x + maxMovementDistance;
            leftX = transform.position.x - maxMovementDistance;
        }

        void Update()
        {
            if (GetComponent<Health>().isDead)
            {
                GetComponent<Health>().isDead = false;
                StartCoroutine(EndGame(2));          
            }

            if (Input.GetMouseButton(0) && !transform.GetComponent<Shooter>().crosshair.isShooting)
            {
                Vector3 touchPosition = Input.mousePosition;

                if (touchPosition.x < Screen.width / 2)
                {
                    transform.position += -transform.right * speed * Time.deltaTime;
                }
                else
                {
                    transform.position += transform.right * speed * Time.deltaTime;
                }

                transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftX, rightX),
                    transform.position.y,
                    transform.position.z);
            }
        }

        IEnumerator EndGame(float waitTime)
        {
            spaceshipMeshRenderer.enabled = false;
            GameObject explosionObject = Instantiate(explosion, transform.position, transform.rotation);
            yield return new WaitForSeconds(waitTime);
            Destroy(explosionObject);
            gameManager.EndGame();
        }
    }
}
