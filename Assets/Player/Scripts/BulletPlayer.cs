using UnityEngine;
using System.Collections;

public class BulletPlayer : MonoBehaviour {

    public int dmg = 10;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && col.CompareTag("Enemy"))
        {
            col.SendMessageUpwards("Damage", dmg);
            Destroy(gameObject);
        }
        Destroy(gameObject, 10);

    }
}
