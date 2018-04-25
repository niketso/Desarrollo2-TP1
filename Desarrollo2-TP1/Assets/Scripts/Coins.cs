using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] int score;

    private void OnTriggerEnter()
    {
        ScoreManager.Instance.Score += score;
        Destroy(gameObject);
    }

}
