using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private Weapon info;

    public float speed = 10f;
    public Rigidbody2D rb;
    
	private void Start () {
        info = (Weapon)GameObject.Find("Player").GetComponent<Weapon>();
    }

	private void Update () {
        rb.velocity = transform.right * speed;
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.tag=="PlayerBullet")
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.takeDamage(info.getDamage());
            }
        }
        if(gameObject.tag=="EnemyBullet")
        {
            PlayerHealth player = collision.GetComponent<PlayerHealth>();
            if(player!=null)
            {
                int rand = Random.Range(1,25);
                player.TakeDamage(rand);
            }
        }
        Destroy(gameObject);
    }
}
