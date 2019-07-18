using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiText : MonoBehaviour {
    public static int Enemies;
    public Text NumberOfEnemies;
    private void Start()
    {
        Enemies = 50;
    }
    private void Update () {
        CountEnemies();
	}
    public void CountEnemies()
    {
        if(Enemies==0)
        {
            SceneManager.LoadScene(2);
        }
        Enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        NumberOfEnemies.text = Enemies.ToString();
    }
}
