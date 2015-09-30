

using UnityEngine;
using System.Collections;

public class test_zoom : MonoBehaviour {


	int zoom   = 20; 
	int  normal  = 60; 
	float  smooth   = 5; 
	private   bool isZoomed = true;

void Update () { 


	if(Input.GetKeyDown("z")){ isZoomed = !isZoomed; }
	
	if(isZoomed == true){
		GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView,zoom,Time.deltaTime*smooth);
	}
	else{
		GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView,normal,Time.deltaTime*smooth);
	}
	}
}
