using UnityEngine;
using System.Collections;

public class FlashRedOnHurt : MonoBehaviour {
	
	float setBackToWhiteTime = float.NegativeInfinity;
	Color originalColor;
	
	// Use this for initialization
	void Start () {
		populateHierarchy(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > setBackToWhiteTime)
		{
			//setToColor(this.gameObject, originalColor);
			this.GetComponent<Renderer>().material.color = originalColor;
		}
	}
	
	public void Hurt()
	{
			this.GetComponent<Renderer>().material.color = Color.red;
			setBackToWhiteTime = Time.time + .2f;
	}
	
	void populateHierarchy(GameObject obj)
	{
		if (obj.GetComponent<Renderer>() != null)
		{
			if (obj.GetComponent<FlashRedOnHurt>() == null)
			{
				obj.AddComponent<FlashRedOnHurt>();
			}
			
			obj.GetComponent<FlashRedOnHurt>().originalColor = obj.GetComponent<Renderer>().material.color;
		} 
		
		for (int i=0; i<obj.transform.childCount; i++)
		{
			populateHierarchy(obj.transform.GetChild(i).gameObject);
		}
		
		if (obj.GetComponent<Renderer>() == null)
		{
			Destroy(this);
		}
		
	}
	
}
