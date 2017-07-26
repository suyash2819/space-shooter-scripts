using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroybyboundary : MonoBehaviour {
	void OnTriggerExit(Collider other)//when it leaves the boundary it wil get destroyed.
	{
		// Destroy everything that leaves the trigger
		Destroy(other.gameObject);
	}
}
