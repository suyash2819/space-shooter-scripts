using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomrotator : MonoBehaviour {

	public float tumble;
	void Start()
	{
		GetComponent<Rigidbody> ().angularVelocity = Random.insideUnitSphere * tumble; //we get different random velocity everytime in play mode from center of the sphere.
	}

}
