using UnityEngine;
using System.Collections;
using System;
using System.IO;
using UnityEngine.UI;

public class WriteReadTextFile : MonoBehaviour {
	public int[] Level = new int [100];
	public int[] SubLevel = new int [100];
	public int[] Star = new int [100];
	public int[] TimeLevel = new int [100];
	public int[] Coins = new int [100];
	public int[] Gems = new int [100];
	public int count;
	public int levelAmount;
	public static WriteReadTextFile levelControl;

	//-------------Initialize function--------------//
	void Start () {
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

		if (!File.Exists (fileName)) {
			writeFile (fileName);
		}
		readFile (fileName);
		DontDestroyOnLoad(gameObject);
		levelControl = this;
	}

	//-------------Writes file if not exists-------------//
	static void writeFile(String fileName)
	{
		var sw = File.CreateText(fileName);
		/*sw.WriteLine ("{0}", 0);//level
		sw.WriteLine ("{0}", 0);//sub
		sw.WriteLine ("{0}", 0);//stars
		sw.WriteLine ("{0}", 0);//time
		sw.WriteLine ("{0}", 0);//coins
		sw.WriteLine ("{0}", 0);//gems*/
		sw.Close();
		Debug.Log(fileName+" file created.");
	}

	//-------------Read from file----------------///
	public void readFile(String fileName)
	{
		int levelAmount = Counter (fileName);
		var reader = File.OpenText (fileName);
		for (int i = 0; i < levelAmount; i++) {
			Level [i] = int.Parse (reader.ReadLine ());
			SubLevel [i] = int.Parse (reader.ReadLine ());
			Star [i] = int.Parse (reader.ReadLine ());
			TimeLevel [i] = int.Parse (reader.ReadLine ());
			Coins [i] = int.Parse (reader.ReadLine ());
			Gems [i] = int.Parse (reader.ReadLine ());
			if (SubLevel [i] == 2) {
				if (checkLocks (Level [i])) {
					GameObject Lock = GameObject.FindGameObjectWithTag ("lock" + Level [i].ToString ());
					Lock.SetActive (false);		
				}
			}
		}
		reader.Close ();
	}

	//-----------Counter for lines in textfile---------//
	public int Counter (String fileName) {
		count = 0;
		var sr = File.OpenText(fileName);
		string line;
		while ((line = sr.ReadLine()) != null)
		{
			count++;
		}
		sr.Close ();
		levelAmount = count / 6;
		return levelAmount;
	}

    //------------Lock checker----------------------//
	public bool checkLocks(int houseIndex)
	{
		if (houseIndex == 0)
			return true;
		else if (houseIndex == 1 && (levelAmount >= 3))                                          
			return true;
		else if (houseIndex == 2 && (levelAmount >= 6))
			return true;
		else if (houseIndex == 3 && (levelAmount >= 9))
			return true;
		else if (houseIndex == 4 && (levelAmount >= 12))
			return true;
		else if (houseIndex == 5 && (levelAmount >= 15))
			return true;
		else if (houseIndex == 6 && (levelAmount >= 18))
			return true;
		else if (houseIndex == 7 && (levelAmount >= 21))
			return true;
		else if (houseIndex == 8 && (levelAmount >= 24))
			return true;
		else if (houseIndex == 9 && (levelAmount >= 27))
			return true;
		else if (houseIndex == 10 && (levelAmount >= 30))
			return true;
		else if (houseIndex == 11 && levelAmount == 33)
			return true;
		else
			return false;
	}
}
