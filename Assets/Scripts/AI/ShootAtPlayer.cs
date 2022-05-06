using UnityEngine;

public class ShootAtPlayer : MonoBehaviour
{
    PlayerInZone playerInZone;
    bool inRange;

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 5f;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public Camera enemyCam;

    private float nextTimeToFire = 0f;

    void Awake()
    {
        playerInZone = GameObject.FindGameObjectWithTag("Enemy Collider").GetComponent<PlayerInZone>();

        inRange = playerInZone.playerInArea;
    }

    // Update is called once per frame
    void Update()
    {
        inRange = playerInZone.playerInArea;
        if (inRange == true && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(enemyCam.transform.position, enemyCam.transform.forward, out hit, range))
        {
            Damage target = hit.transform.GetComponent<Damage>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 3f);
        }
    }
}
