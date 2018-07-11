using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour {
    Animator  anim;
    [SerializeField]
    float dist;
    [SerializeField]
    Transform target;
    [SerializeField]
    float timer;
    Vector3 prevP;
    private NavMeshAgent nma;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
        prevP = transform.position;
        nma = GetComponent<NavMeshAgent>();
        
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.1f)
        {
            float speed = Vector3.Magnitude(transform.position - prevP)* 10f / nma.speed;
            anim.SetFloat("Speed",speed);
            timer = 0;
            prevP = transform.position;
        }
        if (Vector3.Magnitude((target.position - transform.position)) < dist)
        {
           
            anim.SetTrigger("Attack");
            
            
        }
       

    }
    
    private void OnTriggerEnter(Collider other)
    {


        GameObject jug = GameObject.FindGameObjectWithTag("Player");
        AK47 ak = jug.GetComponentInChildren<AK47>();

        if (ak)
        {
            ak.TakeDamage(20);
        }
    }

}
