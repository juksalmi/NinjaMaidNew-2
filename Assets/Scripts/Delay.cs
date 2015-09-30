using UnityEngine;
using System.Collections;

public class Delay : MonoBehaviour {
	void Start() {
		StartCoroutine(DelayFunction());
	}
	
	IEnumerator DelayFunction() {
		yield return new WaitForSeconds(5);
		Application.LoadLevel (1);
	}
}
