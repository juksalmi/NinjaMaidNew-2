using UnityEngine;
using System.Collections;

public class ImageClick : MonoBehaviour {
	public static ImageClick selectionControl;
	public int HouseIndex;
	public GameObject starCanvas;
	public GameObject piippi;
	void OnMouseDown()
	{
		Debug.Log(gameObject.name + " OnMouseOver");
		DontDestroyOnLoad(gameObject);
		selectionControl = this;

		if (GameObject.Find ("MapObject").GetComponent<WriteReadTextFile> ().checkLocks (HouseIndex)) {
			GameObject[] HouseObjects = GameObject.FindGameObjectsWithTag("HouseObject");
			foreach (GameObject house in HouseObjects) {
				house.SetActive(false);
				if(house.name.ToString() == "HomeHouse") {
					piippi.GetComponent<PlayEffects> ().PlaySoundEffect(0);
				} else if (house.name.ToString() == "NinjaBurger") {
					piippi.GetComponent<PlayEffects> ().PlaySoundEffect(1);
				}
			}
			starCanvas.SetActive (starCanvas);
		}
	}
}
