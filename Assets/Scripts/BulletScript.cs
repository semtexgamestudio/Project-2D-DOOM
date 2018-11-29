using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float projectSpeed;

    private void Start()
    {
           StartCoroutine(CommitSelfDeletus());
    }

    private void Update()
    {
        transform.position += -transform.up;
    }

    IEnumerator CommitSelfDeletus()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }

	public void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Crawler") {
			coll.gameObject.GetComponent<CrawlerScript> ().Hit ();
            Destroy(this.gameObject);
		}
	}
}
