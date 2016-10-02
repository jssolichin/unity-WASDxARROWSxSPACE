using UnityEngine;
using System.Collections;

public class fasterDrop : MonoBehaviour {
	
	public int speed;
	// Use this for initialization
	void Start () {
		if(speed == null){
			this.GetComponent<Rigidbody>().velocity = new Vector3(0,-10,0);
		}
		else{
			this.GetComponent<Rigidbody>().velocity = new Vector3(0,-1*speed,0);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
