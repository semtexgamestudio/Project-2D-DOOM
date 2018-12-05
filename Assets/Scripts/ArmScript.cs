using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmScript : MonoBehaviour {

    private int armrot = 0;
    public int armspeed = 25;

    Transform target;
    int strength = 5;

    public SpriteRenderer gun;
	
	// Update is called once per frame
	void Update () {
        //rotation
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if(angle >= 100)
        {
            gun.flipX = true;
        } else
        {
            gun.flipX = false;
        }
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
