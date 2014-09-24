using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public GameObject dustCloudPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) 
	{
		/// ignore creeps
		if (other.GetComponent<Creep>() != null)
			return;

		Instantiate(dustCloudPrefab, transform.position, transform.rotation);
		/// TODO: damage here
		Destroy(gameObject);
	}  

}
