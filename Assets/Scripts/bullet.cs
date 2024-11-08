using UnityEngine;

public class bullet : MonoBehaviour
{

    //Bullet attributes
    [Header("Bullet Attributes")]
    public float damage = 1;

    public float range = 99999; //How far the bullet can go

    public Vector3 startingPosition;


    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        //Destroy the bullet after 2 seconds
        Destroy(gameObject, 2);
    }
    // Update is called once per frame
    void Update()
    {
        CheckDistanceTraveled();
    }

    // Determine how far the bullet has travelled, destroy it if it has gone too far
    // Returns the distance the bullet has traveled as a float
    public float CheckDistanceTraveled()
    {
        float distance = Vector3.Distance(startingPosition, transform.position);
        if(distance >= range)
        {
            //Disable the bullet
            gameObject.SetActive(false);
            //Destroy the bullet
            Destroy(gameObject);
        }

        return Vector3.Distance(startingPosition, transform.position);
    }


    //on collision
    private void OnCollisionEnter(Collision collision)
    {
        //Disable the bullet
        gameObject.SetActive(false);
        //Destroy the bullet
        Destroy(gameObject);
    }

    public void Shoot(Vector3 direction, float bulletSpeed){
        //Add force to the bullet
        //Debug.Log("Shooting POW Speed: " + bulletSpeed + " Direction: " + direction); 
        Vector3 force = direction * bulletSpeed;
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(force, ForceMode.Impulse);
        //Debug.Log(rb.velocity);
    }

    //SetStats() sets the bullet stats
    public void SetStats(float damage, float range){
        this.damage = damage;
        this.range = range;
        //Debug.Log("Bullet Stats Set: Damage: " + damage + " Range: " + range);
    }

  

}
