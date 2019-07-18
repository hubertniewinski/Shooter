using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowGun : MonoBehaviour {
    
    private Weapon info;
    private Attack bulletInfo;
    public Text Bullets;
    public Image[] Weapons;

    private void Start () {
        info = (Weapon)GameObject.Find("Player").GetComponent<Weapon>();
        bulletInfo = (Attack)GameObject.Find("Player").GetComponent<Attack>();
        foreach (var gun in Weapons)
        {
            gun.enabled = false;
        }
    }
    private void Update () {
        SwitchUIGun();
        if(info.isGun())
        {
            ShowBullets();
        }
        else
        {
            Bullets.text = "";
        }
        
	}
    private void ShowBullets()
    {
        int bullets;
        bullets = bulletInfo.GetBullets();
        Bullets.text = bullets.ToString();
    }
    private void SwitchUIGun()
    {
        foreach (var gun in Weapons)
        {
            if (gun.name == info.getName())
            {
                gun.enabled = true;
            }
            else
            {
                gun.enabled = false;
            }
        }
    }
}
