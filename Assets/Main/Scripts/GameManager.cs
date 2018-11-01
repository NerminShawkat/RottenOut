using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float velocityIncreaseRate = 0.1f;
    public float velocityMultiplier = 1;
    [SerializeField]
    GameObject gameOverText;
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
    private void Update()
    {
        print(Basket.MissedFruits);
        if (Basket.MissedFruits >= 5)
        {
            gameOverText.SetActive(true);
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(1);
    }
}
