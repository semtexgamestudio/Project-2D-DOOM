using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour {

    public GameObject player;

    public Vector3 offset;
    public float zoomIn;

	public float speed;
    public float size;

    void Start()
    {
        size = Camera.main.fieldOfView;
        zoomIn = size - 5;
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y, -50), step);
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