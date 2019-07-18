using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpriteController : MonoBehaviour {
    
    private GameObject[] Enemies;
    public Sprite[] sprites;

    private void Start ()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(var Enemy in Enemies)
        {
            int RandNum = Random.Range(0, 27);
            Enemy.GetComponent<SpriteRenderer>().sprite = sprites[RandNum];
        }
		
	}
}
