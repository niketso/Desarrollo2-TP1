using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {
    [SerializeField] float lenght;
    [SerializeField] Transform muzzle;
    [SerializeField] float timer;
    RaycastHit hitInfo;
    float tiempo;

    private void Awake()
    {
        tiempo = timer;
    }
    private void Update()
    {
        Physics.Raycast(muzzle.position,muzzle.forward,  out hitInfo, lenght);
        Debug.DrawRay(muzzle.position, muzzle.forward);
       
        GameObject jug = GameObject.FindGameObjectWithTag("Player");
        AK47 ak = jug.GetComponentInChildren<AK47>();

        if (ak)
        {
            if (tiempo<= 0)
            {
                ak.TakeDamage(10);
                tiempo = timer;
            }
            else
            {
                tiempo -= Time.deltaTime;
            }
            //
            
        }
    }
   
}
