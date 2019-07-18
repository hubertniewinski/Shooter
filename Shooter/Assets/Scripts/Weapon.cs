using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    private string weapon = "";
    private AddWeapon WeaponInfo;
    private List<AddWeapon> weapons;
    private AddWeapon actual;

    public Sprite Idle;
    public Sprite Usp;
    public Sprite Ak47;
    public Sprite Glock;
    public Sprite Hold;
    public GameObject GunSight;
    
    private void Start()
    {
        
        weapons = new List<AddWeapon>();
        weapons.Add(new AddWeapon() { Name = "Glock", Type = "gun", Damage = 50, Bullets = 10 });
        weapons.Add(new AddWeapon() { Name = "Ak47", Type = "gun", Damage = 25, Bullets = 30 });
        weapons.Add(new AddWeapon() { Name = "Usp", Type = "gun", Damage = 35, Bullets = 15 });
    }
    private void Update() {
        GunSightVisibility();
        changeSprite();
    }

    public string getName()
    {
        return GetActualWeapon().Name;
    }
    public int getDamage()
    {
        return GetActualWeapon().Damage;
    }
    public int getBullets()
    {
        return GetActualWeapon().Bullets;
    }
    public void WithoutGun()
    {
        weapon = "";
    }
    public AddWeapon GetActualWeapon()
    {
        actual = new AddWeapon();
        foreach (var item in weapons)
        {
            if (item.Name == weapon)
            {
                actual = item;
                return item;
            }
        }
        return actual;
    }
    public bool isGun()
    {
        string type = GetActualWeapon().Type;
        if (type == "gun")
            return true;
        else
            return false;   
    }
    private void GunSightVisibility()
    {
        if (isGun())
        {
            GunSight.SetActive(true);
        }
        else
        {
            GunSight.SetActive(false);
        }
    }
    private void changeSprite()
    { 
        switch(weapon)
        {
            case "":
                GetComponent<SpriteRenderer>().sprite = Idle;
                break;
            case "Usp":
                GetComponent<SpriteRenderer>().sprite = Usp;
                break;
            case "Ak47":
                GetComponent<SpriteRenderer>().sprite = Ak47;
                break;
            case "Glock":
                GetComponent<SpriteRenderer>().sprite = Glock;
                break;
            case "hold":
                GetComponent<SpriteRenderer>().sprite = Hold;
                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Equip(collision);
    }

    private void Equip(Collision2D collision)
    {
        string collisionName = collision.gameObject.name;

        if (collisionName.StartsWith("weapon"))
        {
            if (collisionName.Contains("gun"))
            {
                weapon = "Glock";
            }
            if (collisionName.Contains("machine"))
            {
                weapon = "Ak47";
            }
            if (collisionName.Contains("silencer"))
            {
                weapon = "Usp";
            }

            Destroy(collision.gameObject);
        }
        if(collisionName.Contains("heart"))
        {
            Destroy(collision.gameObject);
            PlayerHealth hp = GetComponent<PlayerHealth>();
            hp.Heal(30);
        }
    }
  
    
}
public class AddWeapon : Weapon
{
    public string Name
    { get; set; }
    public string Type
    { get; set; }
    public int Damage
    { get; set; }
    public int Bullets
    { get; set; }
}
