using UnityEngine;
using System.Collections;

public class GameMusic : MonoBehaviour {
	void Awake () {
		var MenuMusic = GameObject.Find ("MenuMusic");
		if (MenuMusic) {
			Destroy(MenuMusic);
		}
	}
}
