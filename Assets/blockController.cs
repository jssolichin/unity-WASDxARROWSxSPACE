using UnityEngine;
using System.Collections;

public class blockController : MonoBehaviour {
	
	public GameObject currentTetromino;
	
	// Use this for initialization
	void Start () {
	
	}
	public float yRotation = 5.0F;
	// Update is called once per frame
	void Update () {
		if(currentTetromino !=null){
			if(Input.GetKeyDown(KeyCode.LeftArrow)){
				currentTetromino.transform.position += Vector3.left * 2;
			}
			if(Input.GetKeyDown(KeyCode.RightArrow)){
				currentTetromino.transform.position += Vector3.right * 2;
			}
			if(Input.GetKey(KeyCode.DownArrow)){
				currentTetromino.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
				currentTetromino.transform.position += Vector3.down * 2;
			}
			if(Input.GetKeyDown(KeyCode.UpArrow)){
	       		currentTetromino.transform.eulerAngles += new Vector3(90.0F, 90.0F, 90.0F);
			}
		}
		
		
		
	}
	public void setCurrent (GameObject x){
		print(x);
		currentTetromino = x;
	}
}
