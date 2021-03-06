﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int power;
    public float speed = 20f;
    public float Basedamage = 10f;
    public Rigidbody2D rb;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (LayerMask.LayerToName(other.gameObject.layer) == "EnemyShip")
        {
            other.GetComponentInParent<EnemyShip>().DamageEnemy(power * Basedamage);
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
            this.gameObject.SetActive(false);

        }
        else if (LayerMask.LayerToName(other.gameObject.layer) == "EnemyBullet")
        {
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
            this.gameObject.SetActive(false);
        }
        else if (LayerMask.LayerToName(other.gameObject.layer) == "Boss" && other.gameObject.GetComponent<Boss>().canBeHit)
        {
            other.GetComponentInParent<Boss>().DamageBoss(power * Basedamage);
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
            this.gameObject.SetActive(false);
        }
        else if (LayerMask.LayerToName(other.gameObject.layer) == "DrEggmanBoss")
        {
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
            this.gameObject.SetActive(false);
        }

    }

    public void setPower(int power)
    {
        this.power = power;
    }

}
