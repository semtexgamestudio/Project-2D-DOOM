using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject prefab;
    public Transform barrel;
    public GameManager gm;
    public int attackLaunch = 5;
    public bool isAttack;

    private bool isCooledDown = true;
    private PlayerMovement player;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        gm = GameObject.Find("_GM").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {

        float click1 = Input.GetAxis("Fire1");
        if(click1 > 0 && isCooledDown && !gm.isMelee)
        {
            GameObject bullet;
            bullet = Instantiate(prefab, barrel.position, barrel.rotation);
            isCooledDown = false;
            StartCoroutine(CoolDown());
        } else if (click1 > 0 && isCooledDown && gm.isMelee)
        {
            isAttack = true;
            Vector2 teleport;
            if (player.GetComponent<Animator>().GetBool("LeftMove"))
            {
                teleport = new Vector2(player.transform.position.x - attackLaunch, player.transform.position.y);
            } else {
                teleport = new Vector2(player.transform.position.x + attackLaunch, player.transform.position.y);
            }
            
            float step = attackLaunch/2 * Time.deltaTime;
            player.transform.position = Vector2.MoveTowards(player.transform.position, new Vector2(teleport.x, player.transform.position.y), step);
            isCooledDown = false;
            StartCoroutine(AttackOver());
        }

    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(0.5f);
        isCooledDown = true;
    }

    IEnumerator AttackOver()
    {
        yield return new WaitForSeconds(0.5f);
        isAttack = false;
        yield return new WaitForSeconds(1.5f);
        isCooledDown = true;
    }
}
