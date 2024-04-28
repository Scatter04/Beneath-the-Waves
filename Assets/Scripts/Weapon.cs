using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //bullet shooting delay
    public bool isShooting, readytoShoot;
    bool allowReset = true;
    public float shootingDelay = 1f;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 25;
    public float bulletLife = 3f;
    public int weaponDamage;

    public void Awake()
    {
        readytoShoot = true;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isShooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (readytoShoot && isShooting )
        {
            FireWeapon();
        }
 
    }

    private void FireWeapon()
    {
        readytoShoot = false;

        
        //Instantiate the bullet
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);

        //setting the damage
        Bullet bull = bullet.GetComponent<Bullet>();
        bull.damage = weaponDamage;
        //shoot
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward.normalized * bulletSpeed, ForceMode.Impulse);

        //destroy the bullet aftyer bulletlife
        StartCoroutine(DestroyBullet(bullet, bulletLife));

        if (allowReset)
        {
            Invoke("ResetShot", shootingDelay);
            allowReset = false;
        }
    }

    private void ResetShot()
    {
        readytoShoot = true;
        allowReset = true;
    }

    private IEnumerator DestroyBullet(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
