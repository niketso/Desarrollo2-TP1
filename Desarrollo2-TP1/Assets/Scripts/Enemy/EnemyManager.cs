using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    private static EnemyManager instance;

    public static EnemyManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EnemyManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("EnemyManager");
                    instance = go.AddComponent<EnemyManager>();
                }
            }
            return instance;
        }
    }

    [SerializeField] int activeEnemies;

    public int ActiveEnemies
    {
        get { return activeEnemies; }
        set { activeEnemies = value; }
    }
}
