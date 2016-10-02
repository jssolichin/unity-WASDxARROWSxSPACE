using UnityEngine;
using System.Collections;

public class flashRed : MonoBehaviour {
	bool doneDelay = false;
 
    IEnumerator Wait(float sec)
    {
        yield return new WaitForSeconds(sec);
        doneDelay = true;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(doneDelay){
			Fade (0.3F, 0, 0.5F, gameObject);
			doneDelay = false;
		}
	}
	
	public void Fade (float start, float end, float length, GameObject currentObject) { //define Fade parmeters
		print (Time.time);
		var tex = currentObject.GetComponent<GUITexture>();
		print (tex.color.a);
		if (tex.color.a == start){
			for (float i = 0.0F; i < 1.0F; i += Time.deltaTime*(1/length)) { //for the length of time
				Color colorT = tex.color;
				colorT.a = Mathf.Lerp(start, end, i);
				tex.color = colorT;
				StartCoroutine(Wait(0.1F));
				colorT.a = end;
				tex.color = colorT;
				
	        } //end for
		}
	} //end Fade
		 
	public void Hurt (){
	    Fade (0, 0.3F, 0.5F, gameObject);
	    StartCoroutine(Wait(150f));
    }
	

	
}
