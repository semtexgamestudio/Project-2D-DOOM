using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject prefab;
    private PlayerMovement player;
    public Transform barrel;
    private bool isCooledDown = true;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {

        float click1 = Input.GetAxis("Fire1");
        if(click1 > 0 && isCooledDown)
        {
            GameObject bullet;
            bullet = Instantiate(prefab, barrel.position, barrel.rotation);
            isCooledDown = false;
            StartCoroutine(CoolDown());
        }
	}

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(0.1f);
        isCooledDown = true;
    }
}
