using UnityEngine;
using System.Collections;

public class RewardInput : MonoBehaviour {
	public GameObject inputName;
	// Use this for initialization
	void Start () {
		if (MouseDrag.not_top_ten == true) {
			inputName.SetActive(false);
		} 
	}
}
