using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    Dictionary<string, int> damage = new Dictionary<string, int>();
    private Weapon weapon;
    private int bullets;
    private string name;
    public Transform firePoint;
    public GameObject bulletPrefab;

    public int GetBullets()
    {
        return bullets;
    }
    private void Start () {
        weapon = GetComponent<Weapon>();
    }
	private void Update () {
		if(Input.GetMouseButtonDown(0) && weapon.isGun())
        {
            Shoot();
            CountBullets();
        }
        ChangeGun();
	}
    private void Shoot()
    {
        GameObject child = Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
        child.transform.parent = this.transform;
    }
    private void ChangeGun()
    {
        if (name != weapon.getName())
        {
            name = weapon.getName();
            bullets = weapon.getBullets();
        }
    }
    private void CountBullets()
    {
        
        bullets--;
        if(bullets==0)
        {
            weapon.WithoutGun();
        }
    }
    
}
