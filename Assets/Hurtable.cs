using UnityEngine;
using System.Collections;

public class Hurtable : MonoBehaviour {
	
	public int hp = 3;
	public AudioClip transitionSound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Hurt()
	{
		AudioSource.PlayClipAtPoint(transitionSound, new Vector3(0,0,0));
		
		hp--;
		
		switch(hp){
			case 2:
				Destroy(GameObject.Find ("hp3"));
				break;
			case 1:
				Destroy(GameObject.Find ("hp2"));
				break;
			case 0:
				Destroy(GameObject.Find ("hp1"));
				break;
		}
		if (hp <= 0)
		{
			Destroy(this.gameObject);
			var scoreBoard = GameObject.Find("score");
			if(scoreBoard !=null){
				scoreBoard.GetComponent<scoreBoard>().score = 0;
				Application.LoadLevel("killScreen");
			}
		}
	}
}
