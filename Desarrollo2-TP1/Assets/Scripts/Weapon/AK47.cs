using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : MonoBehaviour {
    public float range = 100f;
    public int bulletsPerMag = 30;
    public int bulletsLeft;

    public Transform shootPoint;

    public float fireRate= 0.1f;
    float fireTimer;
	void Start () {
		
	}
	
	
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            Fire();
        }

        if (fireTimer < fireRate)
            fireTimer += Time.deltaTime;
	}

    private void Fire()
    {
        if (fireTimer < fireRate)
        {
            return;
        }

        RaycastHit hit;
        if (Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name + "founf!");
        }

        fireTimer = 0.0f;

    }
}
