using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;
    public float zoomIn = 105;

	public float speed;
    public float size;

    void Start()
    {
        size = Camera.main.fieldOfView = 110;
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y, -10), step);
    }

    public void Hit()
    {
        Debug.Log("Hit");
        StartCoroutine(HitAnim());
    }

    IEnumerator HitAnim()
    {
        Camera.main.fieldOfView = zoomIn;
        yield return new WaitForSeconds(0.1f);
        Camera.main.fieldOfView = size;
    }
}