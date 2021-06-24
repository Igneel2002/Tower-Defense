using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MENU : MonoBehaviour
{
    public GameObject Death;
    public GameObject Begin;
    public GameObject Game;
    [SerializeField]
    private GameObject pause;
    public bool paus;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        Begin.SetActive(true);
        Death.SetActive(false);
        pause.SetActive(false);
        Game.SetActive(false);
        paus = false;
    }

    public void BEGIN()
    {
        Begin.SetActive(false);
        Time.timeScale = 1;
        Game.SetActive(true);
    }

    public void RESTART()
    {
        Death.SetActive(false);
        paus = true;
        Time.timeScale = 1;
    }

    public void RESUME()
    {
        pause.SetActive(false);
        Game.SetActive(true);
        Time.timeScale = 1;
        StartCoroutine(Delay2(0.1f));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            if (paus == true)
            {
                Time.timeScale = 0;
                pause.SetActive(true);
                Game.SetActive(false);
                StartCoroutine(Delay(0.1f));
            }

            if (paus == false)
            {
                Time.timeScale = 1;
                pause.SetActive(false);
                Game.SetActive(true);
                StartCoroutine(Delay2(0.1f));
            }
        }
    }

    public IEnumerator Delay(float _Delay)
    {
        // Return value and wait for real seconds
        yield return new WaitForSecondsRealtime(_Delay);
        // Make paus false
        paus = false;
    }

    public IEnumerator Delay2(float _Delay)
    {
        // Return value and wait for real seconds
        yield return new WaitForSecondsRealtime(_Delay);
        // Make paus false
        paus = true;
    }

    public void EXIT()
    {
        // If this is in unity editor
#if     UNITY_EDITOR
        // Close unity editor otherwise close application
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
