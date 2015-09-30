using UnityEngine;
using System.Collections;

public class collider : MonoBehaviour {
	public GameObject CanvasFailed ;

	public int CoinsAmount;
	// Use this for initialization
	void Start () {
		CoinsAmount = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.name == "Enemy") {
			CanvasFailed.SetActive(true);
			Time.timeScale=0;
			
			Debug.Log ("Enemy");	
		}
		if (col.name == "Enemy1") {
			CanvasFailed.SetActive(true);
			Time.timeScale=0;
			
			Debug.Log ("Enemy1");	
		}
		if (col.name == "Enemy2") {
			CanvasFailed.SetActive(true);
			Time.timeScale=0;
			
			Debug.Log ("Enemy2");	
		}
	}
}
