using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follower : MonoBehaviour {


    [SerializeField] Transform target;
    [SerializeField] float speed;
    [SerializeField] float distanceMin;                                                  
    [SerializeField] float distanceMax;
    private NavMeshAgent nma;
    void Awake()
    {
        nma = GetComponent<NavMeshAgent>();
    }                                                                                    
    void Update()                                                                        
    {
        // Vector3 diff = target.position - transform.position;                            
        // Vector3 dir = diff.normalized;                                                  
        // float dist = diff.magnitude;                                                    
        //                                                                                 
        // /*if (dist < distanceMin)                                                       
        // {                                                                               
        //     transform.position -= dir * speed * Time.deltaTime;                         
        //}*/                                                                              
        //                                                                                 
        //// if (dist > distanceMax)                                                       
        // //{                                                                             
        //     transform.position += dir * speed * Time.deltaTime;
        //// }
        nma.SetDestination(target.position);
    }
}
