using UnityEngine;
using System.Collections;

public class MenuMusic : MonoBehaviour {
	void Awake () {
		DontDestroyOnLoad (gameObject);
	}
}
