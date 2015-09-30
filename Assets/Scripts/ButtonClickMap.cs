using UnityEngine;
using System.Collections;

public class ButtonClickMap : MonoBehaviour {
	public static ButtonClickMap subLevelControl;
	public string starLevelIndex;

	private Database databaseScript;

	public void StarLevelClick (string StarLevelIndex) {
		int houseIndex = ImageClick.selectionControl.HouseIndex;
		starLevelIndex = StarLevelIndex;
		DontDestroyOnLoad (gameObject);
		subLevelControl = this;
		int starInt = int.Parse (StarLevelIndex);

		Debug.Log ("Taso:: " + houseIndex + "Tähtitaso:: " + StarLevelIndex);
		if (houseIndex == 0) {
			//mute sound here!!!
			if (starInt == 0)
			{
				Database.shoes =3;
				Database.gloves =3;
				Database.tea =3;

				Application.LoadLevel ("LevelScene1");
			}
			else if (starInt == 1)
				Application.LoadLevel ("LevelScene2");
			else if (starInt == 2)
				Application.LoadLevel ("LevelScene3");
		} else if (houseIndex == 1) {
			if (starInt == 0)
				Application.LoadLevel ("LevelScene4");
			else if (starInt == 1)
				Application.LoadLevel ("LevelScene5");
			else if (starInt == 2)
				Application.LoadLevel ("LevelScene6");
		} else if (starInt == 1) {
			Debug.Log ("This level is not implemented yet");//Application.LoadLevel("LevelScene5");
		} else if (starInt == 2) {
				Debug.Log ("This level is not implemented yet");//Application.LoadLevel("LevelScene6");
		} else if (houseIndex == 2) {
			Debug.Log ("This level is not implemented yet");
		} else if (houseIndex == 3) {
			Debug.Log ("This level is not implemented yet");
		} else if (houseIndex == 4) {
			Debug.Log ("This level is not implemented yet");
		} else if (houseIndex == 5) {
			Debug.Log ("This level is not implemented yet");
		} else if (houseIndex == 6) {
			Debug.Log ("This level is not implemented yet");
		} else if (houseIndex == 7) {
			Debug.Log ("This level is not implemented yet");
		} else if (houseIndex == 8) {
			Debug.Log ("This level is not implemented yet");
		} else if (houseIndex == 9) {
			Debug.Log ("This level is not implemented yet");
		} else if (houseIndex == 10) {
			Debug.Log ("This level is not implemented yet");
		} else if (houseIndex == 11) {
			Debug.Log ("This level is not implemented yet");
		} else {
			Debug.Log ("ERROR!! in ButtonClickMap file: StarLevelClick function");
		}
	}
}
