using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class Grunt_Spawn : MonoBehaviour
{
    public Grunt grunt;
    public GameObject PrefabEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!grunt.agent.pathPending && grunt.agent.remainingDistance == 0)
        {
            StartCoroutine(Delay(2f));
        }

    }

    private IEnumerator Delay(float _Delay)
    {
        Destroy(gameObject);

        grunt.LIFE -= 2;


        GameObject Creation = Instantiate(PrefabEnemy, grunt.SP1.transform.position, Quaternion.identity);

        //Instantiate(Creation);

        transform.position = grunt.SP1.transform.position;

        grunt.agent.SetDestination(grunt.SeventhPoint.Position);

        yield return new WaitForSeconds(_Delay);
    }
}
