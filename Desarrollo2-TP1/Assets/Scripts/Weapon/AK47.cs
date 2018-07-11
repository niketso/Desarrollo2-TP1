using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AK47 : MonoBehaviour {


    private Animator anim;
    private AudioSource audioSource;
    public float range = 100f;
    [SerializeField]
    private int bulletsPerMag = 30;
    [SerializeField]
    private int totalBullets = 90;
    public int currentBullets;
    public Text ammoText;
    public Text lifeText;
    public Transform shootPoint;
    public ParticleSystem muzzleFlash;
    public AudioClip shootSound;
    [SerializeField]
    float pjHealth;

    public float fireRate= 0.1f;
    public int damage =20;
    float fireTimer;
    private bool isReloading;
    
	void Start ()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        currentBullets = bulletsPerMag;
        UpdateAmmoText();
        UpdatehpText();
	}
		
	void Update () {

        if (Input.GetButton("Fire1"))
        {
            if (currentBullets > 0)
                Fire();
            else
                DoReload();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentBullets < bulletsPerMag && totalBullets > 0)
                DoReload();
        }

        if (fireTimer < fireRate)
            fireTimer += Time.deltaTime;

        if((totalBullets <= 0 && currentBullets <= 0)||pjHealth == 0)
        {
            SceneManager.LoadScene("Loose");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        UpdatehpText();
    }

    void FixedUpdate()
     {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);

        isReloading = info.IsName("Reload");

     }

    private void Fire()
     {
        if (fireTimer < fireRate||currentBullets <= 0 || isReloading)
        {
            
            return;
        }
 
        RaycastHit hit;

        if (Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, range)) { }
                       
        anim.CrossFadeInFixedTime("Fire", 0.01f);
        muzzleFlash.Play();
        PlayShootSound();

        currentBullets--;
        UpdateAmmoText();
        fireTimer = 0.0f;
        if (hit.transform.GetComponent<Enemy>())
        {
            hit.transform.GetComponent<Enemy>().ApplyDamage(30);
        }

        if (hit.transform.GetComponent<SacosdeArena>())
        {
            hit.transform.GetComponent<SacosdeArena>().ApplyDamage(30);
        }

    }

    public void Reload()
     {
        if (totalBullets <= 0)
        {
            return;
        }
        int bulletsToLoad = bulletsPerMag - currentBullets;

        int bulletsToUse = (totalBullets >= bulletsToLoad) ? bulletsToLoad:totalBullets;

        totalBullets -= bulletsToUse;
        currentBullets += bulletsToUse;
        UpdateAmmoText();
    }

    private void DoReload()
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);

        if (info.IsName("Reload"))
        {
            return;
        }
        anim.CrossFadeInFixedTime("Reload", 0.01f);
    }
    private void PlayShootSound()
    {
        audioSource.clip = shootSound;
        audioSource.Play();
    }
    private void UpdateAmmoText()
    {
        ammoText.text = currentBullets + " / " + totalBullets;
    }
    public void TakeDamage(int damage)
    {
        pjHealth -= damage;
        

    }
    private void UpdatehpText()
    {
        lifeText.text = " " + pjHealth;
    }
}

