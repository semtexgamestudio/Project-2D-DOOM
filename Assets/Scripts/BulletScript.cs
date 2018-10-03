using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float projectSpeed;

    private void Start()
    {
        StartCoroutine(CommitSelfDeletus());
    }

    IEnumerator CommitSelfDeletus()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
