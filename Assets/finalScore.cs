using UnityEngine;
using System.Collections;

public class finalScore : MonoBehaviour {
	public AudioClip transitionSound;
	public string nextScene = "";
	
	static float switchSceneTime = float.PositiveInfinity;
	
	// Use this for initialization
	void Start () {
		AudioSource.PlayClipAtPoint(transitionSound, new Vector3(0,0,0));
		var scorex =3;
		var scoreBoard = GameObject.Find("score");
		if(scoreBoard !=null){
			scorex = scoreBoard.GetComponent<scoreBoard>().score;
			Destroy(scoreBoard);
		}
		GetComponent<GUIText>().text = scorex +"";
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKeyDown)
		{
			Application.LoadLevel(nextScene);
			
		}
	}
}
