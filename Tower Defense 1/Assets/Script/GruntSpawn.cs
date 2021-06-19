using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class GruntSpawn : MonoBehaviour
{
    List<Enemies> grunt = new List<Enemies>();
    public Enemies[] PrefabEnemy;
    public Text LifeCounter;
    public GameObject SP1;
    [SerializeField]
    private GameObject start;
    public static float LIFE = 100;
    int spawnthesemany = 5;
    // Start is called before the first frame update
    void Start()
    {
        //int x = Random.Range(0 ,10);

        //float y = Random.Range(40f, LIFE);
    }

    private void Awake()
    {
        // If doesn't exist
        //if (grunt == null)
        //{
        //    // Exist
        //    grunt = this;
        //}
        //else
        //{
        //    // Destroy if not working
        //    Destroy(this);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        for(int loop = grunt.Count -1; loop >= 0  ;loop--)
        {
            Enemies enemies = grunt[loop];
            
        }
        LifeCounter.text = "Life " + (int)LIFE;
    }

    
    public void StartRound()
    {
        StartCoroutine(Spawn(3f));
    }

    public IEnumerator Spawn(float _Spawn)
    {
        for (int loop = 0; loop < spawnthesemany; loop++)
        {
            // Create enemy
            Enemies spawnedGrunt = Instantiate(PrefabEnemy[Random.Range(0,PrefabEnemy.Length)], SP1.transform.position, Quaternion.identity);
            grunt.Add(spawnedGrunt);
            // Put enemy in correct position
            transform.position = SP1.transform.position;
            // Make button disapear
            start.SetActive(false);
            // Wait for specified time
            yield return new WaitForSeconds(_Spawn);
            // Make button appear
            start.SetActive(true);
        }
        spawnthesemany += 2;
    }
    
}
