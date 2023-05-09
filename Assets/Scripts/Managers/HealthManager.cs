using System;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance;

    public GameObject prefab;
    public Transform healthBarParentPos;
    public int size;

    private List<GameObject> healthList;  
    private int healthCount;
    private Transform currentParentPos;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject.transform.root.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        healthList = new List<GameObject>();
    }

    private void Start()
    {
        healthCount = size;        

        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(prefab, healthBarParentPos);
            healthList.Add(obj);
        }
    }

    private void Update()
    {
        if (healthCount == 0)
        {
            ResetHealth();
        }        
    }

    public void DecrementHealth()
    {
        for (int i = size - 1; i >= 0; i--)
        {
            if (healthList[i].activeInHierarchy)
            {
                healthList[i].SetActive(false);
                healthCount--;
                return;
            }
        }
    }

    public void ResetHealth()
    {
        for (int i = 0; i < size; i++)
        {
            healthList[i].SetActive(true);  
        }

        healthCount = size;
    }

}
