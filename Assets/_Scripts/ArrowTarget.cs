﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTarget : MonoBehaviour {
	public Transform _target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (_target);		
	}
}