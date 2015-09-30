using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeartControl : MonoBehaviour {
	public GameObject Heart1;
	public GameObject Heart2;
	public GameObject Heart3;
	public GameObject ExclamationMark;
	private GameObject[] heartArray;
	private int heartLenght;

	// Use this for initialization
	void Start () {
		heartArray = GameObject.FindGameObjectsWithTag("Heart");
		heartLenght = heartArray.Length;
//		Debug.Log (heartLenght);
	}
	
	// Update is called once per frame
	void Update () {
		if (heartLenght == 3) {
			if (ExclamationMark.active) {
				GameObject.Destroy (Heart1);
			}
		} else if (heartLenght == 2) {
			if (ExclamationMark.active) {
				GameObject.Destroy (Heart2);
			}
		} else if (heartLenght == 1) {
			if (ExclamationMark.active) {
				GameObject.Destroy (Heart3);
			}
		} else if (heartLenght == 0) {
			Debug.Log ("Level failed!");
		}
	}
}
