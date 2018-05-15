using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //private Animator anim1;
    [SerializeField]
    private int health = 100;
    [SerializeField]
    private GameObject enemy;


    /*void Update()
    {
        anim1 = GetComponent<Animator>();
    }*/
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
            //anim1.Play("Hit");
            OnDisable();
            OnDeath();
            enemy.SetActive(false);           
        }
    }

}