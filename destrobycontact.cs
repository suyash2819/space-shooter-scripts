using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destrobycontact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerexplosion;
	public int scorevalue;
	private gamecontroller game;
	void Start()
	{
		GameObject gamecontrollerObject = GameObject.FindWithTag ("GameController");
		if (gamecontrollerObject != null) 
		{
			game = gamecontrollerObject.GetComponent <gamecontroller> ();
		}
		if (game == null) 
		{
			Debug.Log("cannot find'gamecontroller' script");
		}
	}
	void OnTriggerEnter(Collider other) {
		if (other.tag == "boundary") {
			return;//ends the exectution of the function but it again returns to unity code so it wont destroy the asteroid 
		}
		Instantiate(explosion, transform.position, transform.rotation);//instantiate the explosion at the exact same position as the asteroid.
		if(other.tag=="Player")
		{
			Instantiate(playerexplosion, other.transform.position, other.transform.rotation);//instantiate(what ti inatantiate,where to instantiate)
			game.Gameover();
		}
		game.Addscore (scorevalue);
		Destroy(other.gameObject);//order of destroying dosen't matter ,here it destroys the laser.
		Destroy (gameObject);//destroys the asteroid itself.
	}
}
