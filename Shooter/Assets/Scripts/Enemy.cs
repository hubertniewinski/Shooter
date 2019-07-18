using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private float health = 100;
    private float damage = 10;
    private float destination = 1.5f;
    private float timeLeft;
    private float shootRepeatRate;
    private float distance;
    private Vector2 movement;
    private Transform Position;
    private Transform Player;
    private Rigidbody2D rb;
    

    public GameObject[] Drops;
    public GameObject bullet;
    public Transform firePoint;
    public float accelerationTime = 2f;
    public float maxSpeed = 1f;
    public int DropChance = 20;

    private void Start()
    {
        shootRepeatRate = Random.Range(1f, 2f);
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Attack", 0f, shootRepeatRate);

    }
    private void Update () {
        NavigatePlayer();
        IdleMove();
	}
    private void FixedUpdate()
    {
        rb.AddForce(movement * maxSpeed);
    }
    private void NavigatePlayer()
    {
        Player = GameObject.Find("Player").transform;
     
        var dir = Player.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    private void IdleMove()
    {
        distance = Vector2.Distance(transform.position, Player.position);
        if(distance<5f)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                timeLeft += accelerationTime;
            }
        }
        
    }
    private void Die()
    {
        Position = GetComponent<Transform>();
        Drop();
    }
    
    private void Attack()
    {
        if(distance<5f)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
        
    }
    private void Drop()
    {
        int number = Random.Range(0, 101);
        if (number<=DropChance)
        {
            int numbertwo = Random.Range(0, 2);
            if(numbertwo==0)
            {
                int numberthree = Random.Range(1, 4);
                Instantiate(Drops[numberthree], Position.position, Position.rotation);
            }
            else
            {
                Instantiate(Drops[0], Position.position, Position.rotation);
            }
        }
        Destroy(gameObject);
    }
    public void takeDamage(int Health)
    {
        health -= Health;
        if (health <= 0)
        {
            Die();
        }
    }
}
