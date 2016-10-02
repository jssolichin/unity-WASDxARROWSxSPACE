using UnityEngine;
using System.Collections;

public class TitleScreenManager : MonoBehaviour {
	
	public AudioClip transitionSound;
	public string nextScene = "";
	bool clicked = false;
	
	static float switchSceneTime = float.PositiveInfinity;
	
	static string targetScene ="";
	
	// Use this for initialization
	void Start () {
		AudioSource.PlayClipAtPoint(transitionSound, new Vector3(0,0,0));
		clicked= false;
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.anyKeyDown)
		{
			if(!clicked){
				print ("add time");
				switchSceneTime = Time.time; 
			}
			clicked = true;
			
			if (transitionSound != null)
			{
				AudioSource.PlayClipAtPoint(transitionSound, new Vector3(0,0,0));
			}
			
		}
		
		if (Time.time > switchSceneTime)
		{
			switchSceneTime = float.PositiveInfinity;
			Application.LoadLevel("mainGame");
		}
	}
}
