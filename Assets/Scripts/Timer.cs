using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	public Slider slider;

	void Update()
	{
		if (Time.timeScale != 0)
			slider.value = Mathf.MoveTowards ((float)slider.value, 10.0f, 0.001f);
	}
}
