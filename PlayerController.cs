using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]//so that this class can be seen in the inspector.
public class Boundary //to make the player inspector more clean ie it occupies less space.
{
	
	public float xMin,xMax,zMin,zMax;

}
public class PlayerController : MonoBehaviour //indicates that it is inherting from monobehaviour.
{
	public float speed;
	public Boundary boundary;
	public float tilt;//so that it tilts when a player moves to right or left.
	public GameObject shot;
	public Transform shotspawn;//so that the position and rotation are there already ,we do not need to write differently for both.
	public float firerate;
	private float nextfire;

	void Update()
	{
		if (Input.GetButton("Fire1") && Time.time > nextfire)
		{
			nextfire = Time.time + firerate;
			//newProjectile = 
			Instantiate(shot, shotspawn.position, shotspawn.rotation);
			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play ();
		}
	}
	void FixedUpdate()
	{
		float movehorizontal = Input.GetAxis ("Horizontal");
		float movevertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (movehorizontal, 0.0f, movevertical);
		GetComponent<Rigidbody>().velocity = (movement*speed);//slow as input only gives value from 0 to 1 so we multiply by speed
		//this code will maitain the position of the player in the game so it does not go outside the frame or play area i.e it clamps.
		GetComponent<Rigidbody>().position=new Vector3
			(
				Mathf.Clamp(GetComponent<Rigidbody>().position.x,boundary.xMin,boundary.xMax),
				0.0f,//as it does not move up
				Mathf.Clamp(GetComponent<Rigidbody>().position.z,boundary.zMin,boundary.zMax)
			);
		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);//negative otherwise it would tilt in opposite direction to what we want.
	}
}
