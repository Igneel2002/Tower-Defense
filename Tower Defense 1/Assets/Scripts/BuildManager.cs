using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager bmInstance;
    private GameObject generateTurret;
    public GameObject singleTargetTurret;
    public void Awake()
    {
        if(bmInstance != null)
        {
            return;
        }
        bmInstance = this;
    }
    private void Start()
    {
        generateTurret = singleTargetTurret;
    }
    public GameObject GenerateTurret()
    {
        return generateTurret;
    }
}
