using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Towers
{
    public class SingleTargetTower : BaseTowerStats
    {
        BaseTowerStats instance;
        public string robotTag = "Robot";
        public Transform target;
        public Transform gunPart;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }

        // Update is called once per frame
        void Update()
        {
            if (target == null)
            {
                return;
            }
            else
            {
                target = null;
            }

            Vector3 direction = target.position - target.position;
        }
        public void ShootEnemy()
        {

        }
        void FindTarget()
        {
            GameObject[] robots = GameObject.FindGameObjectsWithTag(robotTag);
            float shortestDistance = Mathf.Infinity;// stores the shortest distancce to an enemy
            GameObject nearestEnemy = null;
            foreach (GameObject robot in robots)
            {
                float distanceToRobot = Vector3.Distance(transform.position, robot.transform.position);
                if (distanceToRobot < shortestDistance)
                {
                    shortestDistance = distanceToRobot;
                    nearestEnemy = robot;
                }
            }

            if (nearestEnemy != null && shortestDistance <= range)
            {
                target = nearestEnemy.transform;
            }
            
        }
        private void OnTriggerEnter(Collider other)
        {
            if (instance.targetInsight == true)
            {
                
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, range);
        }

    }
}

