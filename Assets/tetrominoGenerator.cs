using UnityEngine;
using System.Collections;

public class tetrominoGenerator : MonoBehaviour {

	public KeyCode shootKey = KeyCode.Space;
	public AudioClip shootSound;
	public AudioClip backgroundSound;
	public GameObject container;
	
	public GameObject[] tetrominos = new GameObject[6];
	
	Random r = new Random() ;
	GameObject nextTetromino;
	GameObject currentNext;
	
	// Use this for initialization
	void Start () {
		nextTetromino = tetrominos[Random.Range(0, tetrominos.Length)];
		AudioSource.PlayClipAtPoint(backgroundSound, new Vector3(0,0,0));
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(shootKey))
		{	
			Destroy (currentNext);
			//Spawn a new tetrominos
			GameObject newTetromino = (GameObject) Instantiate(nextTetromino);
			
			//Move it to the center of the cannon
			newTetromino.transform.position = this.transform.position;
			newTetromino.GetComponent<Rigidbody>().velocity = new Vector3(0,-10,0);
			
			//Set the control to new block
			var other = container.GetComponent("blockController");
			blockController blockThing = other.GetComponent<blockController>();
			if(blockThing != null){
				blockThing.setCurrent(newTetromino);
			}
				
			nextTetromino = tetrominos[Random.Range(0, tetrominos.Length)];
			GameObject que = (GameObject) Instantiate(nextTetromino);
			que.transform.position = new Vector3(6,6,108);
			que.transform.localScale *= 3;
			que.transform.eulerAngles = new Vector3(-90,15,0);
			currentNext = que;
			
			if (shootSound != null)
			{
				AudioSource.PlayClipAtPoint(shootSound, new Vector3(0,0,0));
			}
		}
	}
	
}
