using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    private float health = 100;
    public Image hp;
    public Image End;
	private void Update () {
        hp.fillAmount = health / 100;
    }
    private void Die()
    {
        //GAMEOVER
        SceneManager.LoadScene(2);

    }
    public float GetHealth()
    {
        return health;
    }
    public void Heal(float number)
    {
        if(health+number>=100)
        {
            health = 100;
        }
        else
        {
            health += number;
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health<=0)
        {
            Die();
            
        }
    }
    

}

