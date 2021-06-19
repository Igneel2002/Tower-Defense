using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MENU : MonoBehaviour
{
    [SerializeField]
    private GameObject start;
    [SerializeField]
    private GameObject pause;
    public bool paus;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        start.SetActive(true);
        paus = false;
    }

    public void START()
    {
        start.SetActive(false);
        paus = true;
    }

    public void RESUME()
    {
        pause.SetActive(false);
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
                StartCoroutine(Delay(0.1f));
            }

            if (paus == false)
            {
                Time.timeScale = 1;
                pause.SetActive(false);
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
