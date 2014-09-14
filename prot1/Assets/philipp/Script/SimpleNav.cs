﻿using UnityEngine;
using System.Collections;


[RequireComponent(typeof(NavMeshAgent))]
public class SimpleNav : MonoBehaviour 
{
	public Transform t;
	NavMeshAgent agent;
	
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		agent.destination = t.position;
    }
}
