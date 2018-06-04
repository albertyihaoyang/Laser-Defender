using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFormation : MonoBehaviour {
    public GameObject projectile;
    public float projectileSpeed = 8;
    public float health = 150;
    public float shotsPerSeconds = 0.5f;

    private void Update()
    {
        float probability = Time.deltaTime * shotsPerSeconds;
        if (Random.value < probability)
        {
            Fire();
        }
    }

    private void Fire()
    {
        Vector3 startPos = transform.position + new Vector3(0, -1, 0);
        GameObject missile = Instantiate(projectile, startPos, Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }

    void OnTriggerEnter2D(Collider2D col){
        Projectile missile = col.gameObject.GetComponent<Projectile>();
        if (missile){
            health -= missile.GetDamage();
            missile.Hit();
            if (health <= 0){
                Destroy(gameObject);
            }
        }
    }
}
