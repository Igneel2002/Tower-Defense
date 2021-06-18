using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTowerStats : MonoBehaviour
{
    #region Variables
    public float fireRate = 1f;
    public float damage = 15f;
    public bool targetInsight = false;
    public float range = 15f;
    public bool railTrue = false;
    public LineRenderer beam;

    #endregion
}
