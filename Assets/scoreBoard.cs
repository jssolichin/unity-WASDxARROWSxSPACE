using UnityEngine;
using System.Collections;

public class scoreBoard : MonoBehaviour {
	private float timeInterval = 1F;
	private float nexTime = 0.0F;
	private bool doOnce = true;
	public int score;
	private bool keepCount = true;
	
	void Awake() {
        DontDestroyOnLoad(transform.gameObject);
	}
    
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (keepCount && Time.time > nexTime) {
            nexTime = Time.time + timeInterval;
			score--;
        }
		
		GetComponent<TextMesh>().text  = score+"";
		
		if(doOnce && score <= 0){
			keepCount = false;
			Application.LoadLevel("killScreen");
			doOnce = false;
		}
	}

}
