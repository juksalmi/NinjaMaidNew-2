using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StarChecker : MonoBehaviour {
	public Sprite StarPoint;
	public Sprite Title;
	public GameObject StarLevel1;
	public GameObject StarLevel2;
	private GameObject Lock1;
	private GameObject Lock2;
	public Image[] images;

	void Start () {
		Lock1 = GameObject.FindGameObjectWithTag ("StarLock1");
		Lock2 = GameObject.FindGameObjectWithTag ("StarLock2");
		StarLevel1.SetActive (false);
		StarLevel2.SetActive (false);
		images = gameObject.GetComponentsInChildren<Image> ();
		CheckStars ();
	}

	void CheckStars () {
		int LevelIndex = ImageClick.selectionControl.HouseIndex;
		int [] Level = WriteReadTextFile.levelControl.Level;
		int [] SubLevel = WriteReadTextFile.levelControl.SubLevel;
		int [] Star = WriteReadTextFile.levelControl.Star;
		int [] TimeLevel = WriteReadTextFile.levelControl.TimeLevel;
		int [] coinAmount = WriteReadTextFile.levelControl.Coins;
		int [] gemAmount = WriteReadTextFile.levelControl.Gems;

		//---------Changing the title. This could be changed to NOT use image array-->> a normal object --------///
		if (LevelIndex == 1) {
			foreach (Image image in images) {
				if (image.name.ToString () == "Title")
					image.sprite = Title;						
			}
		}

		string fileName = "";
		#if  UNITY_IPHONE
		Debug.Log("Running on Apple Device.");
		string fileNameBase = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf('/'));
		fileName = fileNameBase.Substring(0, fileNameBase.LastIndexOf('/')) + "/Documents/" + "Storage.txt";
		#elif UNITY_ANDROID
		Debug.Log("Running on Android Device.");
		fileName = Application.persistentDataPath + "/" + "Storage.txt" ;
		#elif UNITY_EDITOR
		Debug.Log("Not running on mobile Device.");
		fileName = Application.streamingAssetsPath+ "/" + "Storage.txt";
		#else
		Debug.Log("Not optimized for this platform");
		#endif

		int levelCount = GameObject.Find ("MapObject").GetComponent<WriteReadTextFile> ().Counter (fileName);
		Debug.Log ("LEVELCOUNT::: "+levelCount);
		//--------Loops through digits from writeReadTextFile--------//
		for (int j = 0; j < levelCount; j++) {
			Debug.Log ("level:" + Level [j] + "  sublevel:" + SubLevel [j] + " star:" + Star [j] + " time:" + TimeLevel [j] + " coins:" + coinAmount [j] + " gems:" + gemAmount [j]);
			if (Level [j] == LevelIndex) {
				//----------If sublevel 0 is open and set stars for it-----//
				if (SubLevel [j] == 0) {
					Lock1.SetActive (false);
					StarLevel1.SetActive (true);
					if (Star [j] == 0) {

					} else if (Star [j] == 1) {
						foreach (Image image in images) {
							if (image.name.ToString () == "FirstStarSub1")
								image.sprite = StarPoint;						
						}
					} else if (Star [j] == 2) {
						foreach (Image image in images) {
							if (image.name.ToString () == "FirstStarSub1" || image.name.ToString () == "SecondStarSub1")
								image.sprite = StarPoint;						
						}
					} else if (Star [j] == 3) {
						foreach (Image image in images) {
							if (image.name.ToString () == "FirstStarSub1" || image.name.ToString () == "SecondStarSub1" || image.name.ToString () == "ThirdStarSub1")
								image.sprite = StarPoint;						
						}
					}
				}

				//-----------If sublevel 1 is open set stars for it. Set lock1 false and open the starlevel1 and update images array-----//
				if (SubLevel [j] == 1) {
					StarLevel1.SetActive (true);
					StarLevel2.SetActive (true);
					//Set locks false
					Lock1.SetActive (false);
					Lock2.SetActive (false);
					//update images array with starlevel2
					images = gameObject.GetComponentsInChildren<Image> ();
					if (Star [j] == 0) {
							
					} else if (Star [j] == 1) {
						foreach (Image image in images) {
							if (image.name.ToString () == "FirstStarSub2")
								image.sprite = StarPoint;						
						}
					} else if (Star [j] == 2) {
						foreach (Image image in images) {
							if (image.name.ToString () == "FirstStarSub2" || image.name.ToString () == "SecondStarSub2")
								image.sprite = StarPoint;						
						}
					} else if (Star [j] == 3) {
						foreach (Image image in images) {
							if (image.name.ToString () == "FirstStarSub2" || image.name.ToString () == "SecondStarSub2" || image.name.ToString () == "ThirdStarSub2")
								image.sprite = StarPoint;						
						}
					}
				} 

				//------------If sublevel 2 is open set stars for it. Set lock1 and 2 false and open starlevels 1 and 2 and update images array-------//
				if (SubLevel [j] == 2) {
					//update images array with starlevel2 and 3
					images = gameObject.GetComponentsInChildren<Image> ();
					if (Star [j] == 0) {
						
					} else if (Star [j] == 1) {
						foreach (Image image in images) {
							if (image.name.ToString () == "FirstStarSub3")
								image.sprite = StarPoint;						
						}
					} else if (Star [j] == 2) {
						foreach (Image image in images) {
							if (image.name.ToString () == "FirstStarSub3" || image.name.ToString () == "SecondStarSub3")
								image.sprite = StarPoint;						
						}
					} else if (Star [j] == 3) {
						foreach (Image image in images) {
							if (image.name.ToString () == "FirstStarSub3" || image.name.ToString () == "SecondStarSub3" || image.name.ToString () == "ThirdStarSub3")
								image.sprite = StarPoint;						
						}
					}
				}
			}
		}
	}
}