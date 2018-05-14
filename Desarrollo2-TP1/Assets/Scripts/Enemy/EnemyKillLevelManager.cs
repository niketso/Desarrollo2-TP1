using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyKillLevelManager : MonoBehaviour
{
    [SerializeField]
    string nextScene;

    void Update()
    {
        if (EnemyManager.Instance.ActiveEnemies.Count <= 0)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
