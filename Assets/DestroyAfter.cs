using UnityEngine;
using System.Collections;

public class DestroyAfter : MonoBehaviour {
	
	float destoryTime;
	public float lifeSpan = 5;
	
	// Use this for initialization
	void Start () {
	
		this.destoryTime = Time.time + this.lifeSpan;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= destoryTime)
		{
			Destroy(this.gameObject);
		}
	}
}
