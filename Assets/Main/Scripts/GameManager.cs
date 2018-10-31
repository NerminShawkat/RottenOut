using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float velocityIncreaseRate = 0.1f;
    public float velocityMultiplier = 1;
    #region Singleton
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    void Start()
    {
        InvokeRepeating("IncreaseRate", 0, 10);
    }

    public void IncreaseRate()
    {
        if (velocityMultiplier <= 3)
            velocityMultiplier += velocityIncreaseRate;
    }
}
