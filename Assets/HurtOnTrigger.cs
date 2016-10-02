using UnityEngine;
using System.Collections;

public class HurtOnTrigger : MonoBehaviour {
	
	public GameObject ignoredObject;
	public GameObject container;
	public GameObject character;
	public GameObject red;
	
	bool landed = false;
	
	// Use this for initialization
	void Start () {
		container = GameObject.Find("container");
		character = GameObject.Find("character");
		red = GameObject.Find("red-screen-overlay");
	}
	
	// Update is called once per framex
	void Update () {
	}
	
	 void OnCollisionStay(Collision collision) 
	{
		foreach (ContactPoint p in collision.contacts)
		{
			if(p.normal.y > 0 )
			{
				landed = true;
			}
		}
	}
	
	void OnCollisionEnter(Collision collision) {
        ContactPoint contact = collision.contacts[0];
		if(!landed && contact.otherCollider.gameObject == character){
			character.BroadcastMessage("Hurt", SendMessageOptions.DontRequireReceiver);
			red.BroadcastMessage("Hurt", SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
		
    }
	
	void OnTriggerEnter(Collider thingWeHit)
	{

	
	}
}
