using UnityEngine;
using System.Collections;
using Microsoft;
using System;
using System.IO;

public class MapMusic : MonoBehaviour { 
	public GameObject mapMusic;
	void Awake () {
		var MenuMusic = GameObject.Find("MenuMusic");
		if (MenuMusic) {
			AudioListener listener = mapMusic.GetComponent(typeof(AudioListener)) as AudioListener;
			listener.enabled = false;
			AudioSource source = mapMusic.GetComponent (typeof(AudioSource)) as AudioSource;
			source.enabled = false;
		} else {
			AudioListener listener = mapMusic.GetComponent(typeof(AudioListener)) as AudioListener;
			listener.enabled = true;
			AudioSource source = mapMusic.GetComponent (typeof(AudioSource)) as AudioSource;
			source.enabled = true;
		}
	}

}
