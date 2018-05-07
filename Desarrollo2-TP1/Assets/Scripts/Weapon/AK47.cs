using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : MonoBehaviour {

    private Animator anim;
    private AudioSource audioSource;
    public float range = 100f;
    [SerializeField]
    private int bulletsPerMag = 30;
    [SerializeField]
    private int totalBullets = 90;
    public int currentBullets;

    public Transform shootPoint;
    public ParticleSystem muzzleFlash;
    public AudioClip shootSound;

    public float fireRate= 0.1f;
    float fireTimer;
	void Start ()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        currentBullets = bulletsPerMag;      
	}
		
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            Fire();
        }

        if (fireTimer < fireRate)
            fireTimer += Time.deltaTime;
	}

    void FixedUpdate()
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);

       
    }

    private void Fire()
    {
        if (fireTimer < fireRate||currentBullets <= 0)
        {
            
            return;
        }
 
        RaycastHit hit;

        if (Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name + "found!");
        }

        anim.CrossFadeInFixedTime("Fire", 0.01f);
        muzzleFlash.Play();
        PlayShootSound();
        currentBullets--;
        fireTimer = 0.0f;

    }
    private void PlayShootSound()
    {
        audioSource.clip = shootSound;
        audioSource.Play();
    }
}
