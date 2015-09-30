using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseSoundAndMusic : MonoBehaviour {
	public Sprite MuteSound;
	public Sprite MuteMusic;
	public GameObject Sound;
	public GameObject Music;

	public bool sound=true;
	public bool music=true;

	public float level_vol =1f;

//	AudioSource audio2;

//	audio2  = Camera.main.GetComponent<AudioSource>();



	public void PauseSoundClick ()
	{

//		Camera.main.GetComponent<AudioSource> ().mute = true;
		MouseDrag.FindObjectOfType<AudioSource> ().volume = 1f;

		if (sound) 
		{
			MouseDrag.FindObjectOfType<AudioSource> ().mute = true;
			sound = false;
		} 
		else
		{
			MouseDrag.FindObjectOfType<AudioSource> ().mute = false;
			sound = true;
		}



	}
	
	public void PauseMusicClick ()
	{

		MouseDrag.FindObjectOfType<AudioSource> ().volume = 1f;

		// AudioListener.pause = false;

//		Camera.main.GetComponent<AudioSource> ().mute = true;
//		MouseDrag.FindObjectOfType<AudioSource> ().volume = 1f;
		
/*		if (music) 
		{
			Camera.main.GetComponent<AudioSource> ().mute = true;
			music = false;
			
		} 
		else
		{
			Camera.main.GetComponent<AudioSource> ().mute = false;
			music = true;
		}

*/

		if (music) 
		{
			if ( level_vol >= 0)
			{
				level_vol = level_vol - 0.1f;
				Camera.main.GetComponent<AudioSource> ().volume =level_vol;  
			}
			else 
			{
				level_vol = level_vol + 0.1f;
				Camera.main.GetComponent<AudioSource> ().volume =level_vol;  
				music=false;
			}
		} 
		else
		{
			if ( level_vol <= 1)
			{
				level_vol = level_vol + 0.1f;
				Camera.main.GetComponent<AudioSource> ().volume =level_vol;  
			}
			else 
			{
				level_vol = level_vol - 0.1f;
				Camera.main.GetComponent<AudioSource> ().volume =level_vol;  
				music=true;
			}
		}
		

/*

		if (music) 
		{
			if ( AudioListener.volume >= 0)
			{
				AudioListener.volume=AudioListener.volume -0.1f;
			}
			else 
			{
				AudioListener.volume=AudioListener.volume +0.1f;
				music=false;
			}
		} 
		else
		{
			if ( AudioListener.volume <= 1)
			{
				AudioListener.volume=AudioListener.volume +0.1f;
			}
			else 
			{
				AudioListener.volume=AudioListener.volume -0.1f;
				music=true;
			}
		}


*/

	//	audio2.mute = true;

	}
}
