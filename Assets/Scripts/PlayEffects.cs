using UnityEngine;
using System.Collections;

public class PlayEffects : MonoBehaviour {
	public AudioClip[] aclip = new AudioClip[6];
	AudioSource audio;

	void Awake () {
		audio =  GetComponent<AudioSource>();
	}

	public void PlaySoundEffect(int effect_nbr)
	{
//		Debug.Log ("PlaySoundEffect ::effect_nbr --> "+effect_nbr);
		audio.clip =aclip [ effect_nbr ];
		audio.Play();
	}
}
