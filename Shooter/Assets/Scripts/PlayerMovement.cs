using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 2f;
    public Transform controller;

	private void Update () {
        Move();
	}
    private void Move()
    {
        float moveVertical;
        float moveHorizontal;
        moveVertical = Input.GetAxis("Vertical");
        moveHorizontal = Input.GetAxis("Horizontal");
        controller.Translate(new Vector3(moveHorizontal * Time.deltaTime * speed, moveVertical * Time.deltaTime * speed, 0)); 
    }
}
