using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGameManager : MonoBehaviour
{
    private static EnemyGameManager instance;

    public static EnemyGameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EnemyGameManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("EnemyGameManager");
                    instance = go.AddComponent<EnemyGameManager>();
                }

                DontDestroyOnLoad(instance.gameObject);
            }

            return instance;
        }
    }

    [SerializeField]
    int totalKills;

    public int TotalKills
    {
        get { return totalKills; }
        set { totalKills = value; }
    }

    private void Awake()
    {
        if (Instance != this)
            Destroy(gameObject);
    }
}