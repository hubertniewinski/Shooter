using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirepointRotator : MonoBehaviour {
    public Transform player;

	private void Update () {
        Rotate();
	}
    private void Rotate()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
        player.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
