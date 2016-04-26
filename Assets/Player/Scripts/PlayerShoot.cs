using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{

    public float shootInterval;
    public float bulletSpeed = 100;
    public float bulletTimer;
    public float damage = 30;

    public GameObject bullet;
    public Transform firePoint;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        bulletTimer += Time.deltaTime;

        if (bulletTimer >= shootInterval && Input.GetKeyDown(KeyCode.G))
        {
            Vector2 direction = firePoint.transform.position;
            GameObject bulletClone;
            bulletClone = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation) as GameObject;
            bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

            bulletTimer = 0;
        }

    }
}

