using UnityEngine;
using System.Collections;

public class winnerTrigger : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider thingWeHit)
	{
		if(thingWeHit.tag == "Player"){
			print ("WINNER");
			Application.LoadLevel("killScreen");
		}
	
	}
}
