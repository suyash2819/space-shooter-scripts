using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour {
	//we want it t move as the game start.
	public float speed;
	void Start()
	{
		GetComponent<Rigidbody> ().velocity = transform.forward * speed;
	}
}
