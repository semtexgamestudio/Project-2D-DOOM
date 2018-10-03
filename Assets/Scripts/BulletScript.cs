using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float projectSpeed;

    private void Start()
    {
        transform.eulerAngles = new Vector3(transform.localRotation.x, transform.localRotation.y, GameObject.Find("Player").GetComponent<Shooting>().barrel.localRotation.z);
        StartCoroutine(CommitSelfDeletus());
    }

    private void Update()
    {
        transform.position += -transform.right;
    }

    IEnumerator CommitSelfDeletus()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
