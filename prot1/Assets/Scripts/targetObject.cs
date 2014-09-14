using UnityEngine;
using System.Collections;

public class targetObject : MonoBehaviour {

	public Transform t;
    public NavMeshAgent agent;
	
	// Use this for initialization
	void Start () {
		agent.destination = t.position;
	}
	
	// Update is called once per frame
	void Update () {
		agent.destination = t.position;
	}
}
