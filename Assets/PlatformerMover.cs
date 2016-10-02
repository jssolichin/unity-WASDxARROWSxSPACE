/*
 
 */

using UnityEngine;
using System.Collections;

public class PlatformerMover : MonoBehaviour, Mover {
			public GameObject character;
			public GameObject generator;
	public GameObject red;
	float moveSpeed = 5; 
	float jumpHeight = 10;
	bool jumpOk = false;
	public AudioClip transitionSound;
	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
		this.GetComponent<Collider>().material = (PhysicMaterial) Resources.Load("PhysicsMaterials/slippery");
		AudioSource.PlayClipAtPoint(transitionSound, new Vector3(0,0,0));
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		Vector3 moveVelo = this.GetComponent<Rigidbody>().velocity;
		moveVelo.x = 0;
		if (Input.GetKey(KeyCode.A)) //if the up arrow is pressed
		{
			
			
			//Move the object forward
			// Some kind of serious explanation is needed here
			moveVelo +=  new Vector3(-moveSpeed,0,0);//, ForceMode.VelocityChange);
			//this.transform.right = new Vector3(-1,0,0);
			//rigidBody.MovePosition()
		}
		
		if (Input.GetKey(KeyCode.D)) //if the up arrow is pressed
		{
			
			
			//Move the object forward
			// Some kind of serious explanation is needed here
			moveVelo +=  new Vector3(moveSpeed,0,0);//, ForceMode.VelocityChange);
			//this.transform.right = new Vector3(1,0,0);
			//rigidBody.MovePosition()
		}
		
		
		
		
		if (Input.GetKeyDown(KeyCode.W) && jumpOk)
		{
			moveVelo.y = jumpHeight;
			jumpOk = false;
		}
		
		this.GetComponent<Rigidbody>().velocity = moveVelo;
		
		if (Input.GetKeyDown(KeyCode.S))
		{
			print ("kill");
			character.BroadcastMessage("Hurt", SendMessageOptions.DontRequireReceiver);
			red.BroadcastMessage("Hurt", SendMessageOptions.DontRequireReceiver);
			
			
			//Move it to the center of the cannon
			transform.position = generator.gameObject.transform.position;
		}
	
	}
	
	 void OnCollisionStay(Collision collision) 
	{
		foreach (ContactPoint p in collision.contacts)
		{
			
			if(p.normal.y > 0&& p.normal.x != -1 && p.normal.x <1)
			{
				jumpOk = true;
			}
		}
	}
	
	public bool isMoving()
	{
		return this.GetComponent<Rigidbody>().velocity.x != 0;
	}
	
	void OnCollisionExit(Collision collision)
	{
		jumpOk = false;
	}
	
}
