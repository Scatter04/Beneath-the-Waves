using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour

{

    private BoxCollider gunTrigger;
    public float range = 20f;
    public float spread = 1f;
    public EnemyManager enemyManager;
    public ParticleSystem muzzleFlash;


    private float nextTimeToFire;
    public float fireRate;
    public float damage = 1f;

    public Animator anims;

    public LayerMask raycastLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new Vector3(spread, spread, range);
        gunTrigger.center = new Vector3(0, 0, 0.5f * range);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire)
        {
            Fire();
        }
    }

    void Fire()
    {
        anims.ResetTrigger("Firing");
        anims.SetTrigger("Firing");
        muzzleFlash.Play();
        foreach (var enemy in enemyManager.enemiesInTrigger) 
        {
            var dir = enemy.transform.position - transform.position;
            RaycastHit hit;
            if (UnityEngine.Physics.Raycast(transform.position, dir, out hit, range, raycastLayerMask))
            {
                if(hit.transform == enemy.transform)
                {
                    enemy.TakeDamage(damage);
                }
            }
        }
        nextTimeToFire = Time.time + fireRate;
    }

    private void OnTriggerEnter(Collider other)
    {
        // add enemy
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyManager.AddEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // remove enemy
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyManager.RemoveEnemy(enemy);
        }
    }

}
