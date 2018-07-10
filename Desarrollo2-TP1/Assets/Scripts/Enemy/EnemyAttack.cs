using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    Animator  anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        //anim.SetTrigger
    }
	
}
