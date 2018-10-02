﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float projectSpeed;

    private void Start()
    {
        StartCoroutine(CommitSelfDeletus());
    }

    // Update is called once per frame
    void Update () {
        
	}

    IEnumerator CommitSelfDeletus()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
