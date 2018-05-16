using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacosdeArena : MonoBehaviour
{
    [SerializeField]
    private int health = 180;
    [SerializeField]
    private GameObject saco;
    public void ApplyDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            saco.SetActive(false);
        }

    }
}
