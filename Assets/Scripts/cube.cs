﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour {

    public Transform dirt;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < 20; i++)
        {
            float x, y, z;
            x = Random.Range(1f, 15f);
            y = Random.Range(3f, 10f);
            z = Random.Range(-5f, 10f);
            Transform c = Instantiate(dirt);
            c.tag = "cube";
            c.parent = transform;
            c.localPosition = new Vector3(x,y,z);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
