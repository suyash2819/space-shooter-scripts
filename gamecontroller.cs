using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamecontroller : MonoBehaviour 
{
	public GameObject hazards;
	public Vector3 spawnvalue;
	public int hazardcount;
	public float spawnwait;
	public float startwait;
	public float wavewait;
	public Text scoretext;
	private int score;
	public Text restarttext;
	public GUIText gameovertext;
	private bool gameover;//track when the game is over
	private bool restart;//track when the game has to restart
	void Start()
	{
		gameover = false;
		restart = false;
		restarttext.text = "";//wll display nothing at the start;
		gameovertext.text = "";
		score = 0;
		Updatescore ();
		StartCoroutine (spawnwaves ());//to call coroutine we need to write like this.
	}
	void Update()//for restarting the game.
	{
		if (restart) 
		{
			if(Input.GetKeyDown(KeyCode.R))
					Application.LoadLevel(Application.loadedLevel);//this will restart the game
				
		}
	}

	IEnumerator spawnwaves()//as we ant our hazards to wait so we need to write the return as ienumerator(it is a co routine not function)
	{
		yield return new WaitForSeconds (startwait);//to make the hazards wait withour pausing the game.
		while(true)
		{
			for (int i=0;i<hazardcount;i++) 
			{
				Vector3 spawnposition = new Vector3 (Random.Range (-spawnvalue.x, spawnvalue.x), spawnvalue.y, spawnvalue.z);
				Quaternion spawnrotation = Quaternion.identity;
				Instantiate (hazards, spawnposition, spawnrotation);
				yield return new WaitForSeconds (spawnwait);//to make the hazards wait withour pausing the game.
			}
			yield return new WaitForSeconds (wavewait);//to make the hazards wait withour pausing the game.
			if (gameover) {
				restarttext.text = "Press 'R' to Restart";
				restart = true;
				break;
			}
		}
	}
	public void Addscore(int newscorevalue)//will called from the game from destroy by contact script when the hazard is destroyed
	{
		score += newscorevalue;
		Updatescore ();
	}
	void Updatescore()
	{
		scoretext.text = "Score : " + score.ToString();
	}
	public void Gameover()
	{
		gameovertext.text = "Game Over!";
		gameover = true;
	}
} 
