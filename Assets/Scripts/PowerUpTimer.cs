using UnityEngine;
using System.Collections;


public class PowerUpTimer : MonoBehaviour {
	
	public static float myTime = 5.0f;
	private MouseDrag mouseDragScript;
	private MouseDragLevel2 mouseDragScript2;

//	Debug.Log("Running on Apple Device.");
	
	// Update is called once per frame
	void Update () {
		if(myTime>0) {
			myTime -= Time.deltaTime;
		}
		if(myTime<=0) {
			MouseDrag.power_celection = 0;
			MouseDragLevel2.power_celection = 0;

		}
//		Debug.Log("myTime= "+myTime);
	}
}

