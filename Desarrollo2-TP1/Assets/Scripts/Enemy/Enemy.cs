using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int health = 100;
    [SerializeField]
    private GameObject enemy;

    private void OnEnable()
    {
        EnemyManager.Instance.ActiveEnemies.Add(this);
        
    }

    void OnDisable()
    {

        if (EnemyManager.Instance != null)
            EnemyManager.Instance.ActiveEnemies.Remove(this);
                
    }

    void OnDeath()
    {
        EnemyGameManager.Instance.TotalKills++;        
    }

    public void ApplyDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
           OnDisable();
            OnDeath();
            enemy.SetActive(false);
            Debug.Log("hola");
        }
    }
}