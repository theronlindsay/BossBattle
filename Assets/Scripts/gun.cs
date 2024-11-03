using UnityEngine;

public class gun : MonoBehaviour {
    //gun attributes
    [Header("Gun Attributes")]
    public float damage;

    public float range; //How far the bullet can go
    public float fireRate;
    public float impactForce;

    public int bullets = 10;
    public int reloadBullets;
    public float bulletSpeed;
    public GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;

    private bool canShoot = true;
    private float nextTimeToFire = 0;

    void Start()
    {
        reloadBullets = bullets;
    }

    // update is called once per frame (Pretty Much just a timer)
    void Update()
    {
        if (Time.time >= nextTimeToFire)
        {
            canShoot = true;
        }
    }

    //Reload
    public void Reload()
    {
        bullets = reloadBullets;
    }

    public void Shoot()
    {
        //Check if the gun can shoot
        if (!canShoot)
        {
            //Debug.Log("Can't shoot yet");
            return;
        }
        //Set the next time to fire
        nextTimeToFire = Time.time + 1f / fireRate;
        //Debug.Log("Shoot");
        //Instantiate the bullet at the launch point
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        //Show the bullet spawn point and trajectory
        Debug.DrawRay(transform.position, transform.forward * range, Color.red, 2f);

        


        //Get the bullet script
        bullet bulletScript = bullet.GetComponent<bullet>();
        //Set the bullet damage
        bulletScript.SetStats(damage, range);
        //Add force to the bullet
        bulletScript.Shoot(transform.forward, bulletSpeed);
        //reset the canShoot variable
        canShoot = false;
    }

}
