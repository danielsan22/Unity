using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{

    public float fireRate = 0;
    public float damage = 30;
    public LayerMask whatToHit;
    public Transform BulletTrailPrefab;
    //public GameObject fireball;


    float timeToFire = 0;
    Transform firePoint;
    // Use this for initialization
    void Awake()
    {
        firePoint = transform.FindChild("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("No firepoint");
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Shoot();
        if (fireRate == 0)
        {
            //if(Input.GetKeyDown(KeyCode.G))
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                //Instantiate(fireball, firePoint.position, firePoint.rotation);
            }

        }
        else
        {
            //if (Input.GetKeyDown(KeyCode.G) && Time.deltaTime>timeToFire)
            if (Input.GetButtonDown("Fire1") && Time.deltaTime > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
                //Instantiate(fireball, firePoint.position, firePoint.rotation);
            }
        }
    }

    void Shoot()
    {

        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector3 firePointPosition = new Vector3(firePoint.position.x, firePoint.position.y);
        Vector3 test1 = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
        Vector3 test2 = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, test2 = firePointPosition, 100, whatToHit);
        Effect();
        Debug.DrawLine(firePointPosition, (test1 - firePointPosition) * 100, Color.cyan);
        if (hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
            Debug.Log("We hit " + hit.collider.name + " and did " + damage + " damage");
        }
        //Debug.Log("Test");
    }

    void Effect()
    {

        Instantiate(BulletTrailPrefab, firePoint.position, firePoint.rotation);
    }
}
