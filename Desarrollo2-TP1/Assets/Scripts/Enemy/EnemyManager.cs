using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private static EnemyManager instance;

    public static EnemyManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<EnemyManager>();

            return instance;
        }
    }

    [SerializeField]
    List<Enemy> activeEnemies;

    public List<Enemy> ActiveEnemies
    {
        get { return activeEnemies; }
    }

    private void Awake()
    {
        if (Instance != this)
            Debug.LogError("Duplicated EnemyManager", gameObject);
        else
            Debug.Log("EnemyManager Initialized", gameObject);
    }
}