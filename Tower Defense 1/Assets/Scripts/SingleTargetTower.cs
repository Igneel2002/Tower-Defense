using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Towers
{
    public class SingleTargetTower : BaseTowerStats
    {
        BaseTowerStats instance;
        public string robotTag = "Robot";
        private Transform target;
        public Transform gunPart;
        public float turnSpeed = 10f;
        private float fireCD = 0f;
        public GameObject ammoType;
        public Transform barrelPoint;

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
            InvokeRepeating("FindTarget", 0f, 0.5f);
        }

        // Update is called once per frame
        void Update()
        {
            if (target == null)
            {
                return;
            }
            

            Vector3 direction = target.position - transform.position;
            Quaternion lookRot = Quaternion.LookRotation(direction);
            Vector3 rot = Quaternion.Lerp(gunPart.rotation,lookRot,Time.deltaTime * turnSpeed).eulerAngles;
            gunPart.rotation = Quaternion.Euler(0f,rot.y,0f);

            if (fireCD <= 0f)
            {
                ShootEnemy();
                fireCD = 1f / instance.fireRate;
            }
            fireCD -= Time.deltaTime;
        }
        public void ShootEnemy()
        {
            //Debug.Log("Shot Fired");
            GameObject plasmaGO = (GameObject) Instantiate(ammoType, barrelPoint.position, barrelPoint.rotation);
            Plasma plasma = plasmaGO.GetComponent<Plasma>();
            if (plasma != null)
            {
                plasma.Pursue(target);
            }
        }
        void FindTarget()
        {
            GameObject[] robots = GameObject.FindGameObjectsWithTag(robotTag); // looks through gameobject with via Tag
            float shortestDistance = Mathf.Infinity;// stores the shortest distancce to an enemy
            GameObject nearestEnemy = null; // sets the varible to null
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
            else
            {
                target = null;
            }
            
        }
        

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, range); // When the object with this script is selected a wire sphere is drawn via the position of the object and the range 
        }

    }
}

