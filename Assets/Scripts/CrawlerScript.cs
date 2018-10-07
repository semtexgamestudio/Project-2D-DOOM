using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class CrawlerScript : MonoBehaviour {

	public Transform sightStart, sightEnd, posLeft, posRight;

	public bool spotted, isLeft = false;
	public SpriteRenderer spriteRenderer;
	public Rigidbody2D rb;

	public float enemySpeed, enemySpotted;
	private Transform player;

	float step;

	void Start(){
		spriteRenderer = transform.GetComponent<SpriteRenderer> ();
		player = GameObject.Find ("Player").GetComponent<Transform>();
		rb = transform.GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void LateUpdate () {
		Raycasting ();
		if (spotted) {
			AttackBehaviour ();
		} else {
			IdleBehaviour ();
		}
	}

	void Raycasting(){
		Debug.DrawLine (sightStart.position, sightEnd.position, Color.green);
		spotted = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Player"));
	}

	void IdleBehaviour(){


		step = enemySpeed * Time.deltaTime;
		if (isLeft) {
			spriteRenderer.flipX = false;
			transform.position = Vector2.MoveTowards(transform.position, posLeft.position, step);
		} else {
			spriteRenderer.flipX = true;
			transform.position = Vector2.MoveTowards(transform.position, posRight.position, step);
		}
	}

	void AttackBehaviour(){
		step = enemySpotted * Time.deltaTime;
		transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), step);
	}

	public void Hit(){
		
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.name == posLeft.name) {
			isLeft = false;
		} else if (coll.gameObject.name == posRight.name) {
			isLeft = true;
		}
	}
}
