using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public float jumpSpeed;
    public GameObject go;

    public BoxCollider2D boxcoll;

    private bool isGrounded = true;

	// Use this for initialization
	void Start () {
        boxcoll = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        // float jump = Input.GetAxis("Jump") * jumpSpeed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + x, transform.position.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            transform.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, jumpSpeed, 0), ForceMode2D.Impulse);
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, -jumpSpeed - 15, 0), ForceMode2D.Impulse);
            isGrounded = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isGrounded = true;
        }
    }
}
