using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroybytime : MonoBehaviour {

	public float lifetime;
	void Start()
	{
		Destroy (gameObject, lifetime);//like a ticking timebomb it destroys after the lifetime
	}

}
