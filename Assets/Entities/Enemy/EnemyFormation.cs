﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFormation : MonoBehaviour {
    public GameObject projectile;
    public float projectileSpeed = 8;
    public float health = 150;
    public float shotsPerSeconds = 0.5f;

    public int scoreValue = 150;
    private ScoreKeeper scoreKeeper;

    public AudioClip fireSound;
    public AudioClip deathSound;

    void Start()
    {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

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
        GameObject missile = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }

    void OnTriggerEnter2D(Collider2D col){
        Projectile missile = col.gameObject.GetComponent<Projectile>();
        if (missile){
            health -= missile.GetDamage();
            missile.Hit();
            if (health <= 0){
                Die();
            }

        }
    }

    void Die(){
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        Destroy(gameObject);
        scoreKeeper.Score(scoreValue);
    }
}
