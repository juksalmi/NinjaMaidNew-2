using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class ReadWriteTextFile : MonoBehaviour {
	public int[] Level = new int [100];
	public int[] SubLevel = new int [100];
	public int[] Star = new int [100];
	public int[] TimeLevel = new int [100];
	public Transform starGrey;
	public Transform star;
	public Transform levelLock;
	
	
	void Start () {
		var fileName = "Storage.txt";

		if (File.Exists(fileName))
		{
			Debug.Log(fileName+" already exists.");
			readFile (fileName); 
			return;
		}
		writeFile (fileName);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	static void writeFile(String fileName)
	{
		var sw = File.CreateText(fileName);
		//first level, second star level, third stars, forth time
		for (int i = 0; i < 3; i++) 
		{
			sw.WriteLine ("{0}", i);
			sw.WriteLine ("{0}", 0);
			sw.WriteLine ("{0}", 0);
			sw.WriteLine ("{0}", 0);
		}
		sw.Close();
		Debug.Log(fileName+" file created.");
	}

	public void readFile(String fileName)
	{
		var sr = File.OpenText(fileName);
		var line = 0;
		int count = 0;
		for (int i = 0; i < 3; i++)
		{
			Debug.Log(line+" "+i); // prints each line of the file
			Level[i] = int.Parse (sr.ReadLine());
			SubLevel[i] = int.Parse (sr.ReadLine());
			Star[i] = int.Parse (sr.ReadLine());
			TimeLevel[i] = int.Parse (sr.ReadLine());
			count++;
		}
		Debug.Log("TASO:::."+count);

		/*if (count == 3) {
			Instantiate (levelLock, new Vector3 (430, 160, 0), Quaternion.identity);
		}*/

		/*ImageClick imageClass = new ImageClick();
		GameObject levelObject = imageClass.GetLevelObject();
		int levelIndex = int.Parse (levelObject.name);*/

		int LevelIndex = ImageClick.selectionControl.HouseIndex;

		for (int j = 0; j < 2; j++)
		{
			Debug.Log("level:"+Level[j]+"  sublevel:"+SubLevel[j]+" star:"+Star[j]+" time:"+TimeLevel[j]);
			if (Level[j] == LevelIndex) 
			{
				int LevelOneStars = 0;
				if(SubLevel[j] == 0) {
					LevelOneStars = Star[j];
					Debug.Log("Tämä toimii mainiosti!! "+LevelIndex);
					/*GameObject objnewObject = (GameObject)Instantiate(starGrey,new Vector3(44, 1,0),Quaternion.identity);
					objnewObject.transform.parent = GameObject.Find("Canvas").transform;*/
					Instantiate (starGrey, new Vector3 (430, 160, 0), Quaternion.identity);
					Instantiate (starGrey, new Vector3 (105, 2, 0), Quaternion.identity);
					Instantiate (starGrey, new Vector3 (162, 1, 0), Quaternion.identity);
					/*Transform ParentObject = GameObject.Find("Canvas").transform;
					ParentObject.parent = starGrey;*/
				} else if (SubLevel[j] == 1) {
					LevelOneStars = Star[j];
					/*Instantiate (star, new Vector3 (155.4, yValue, 0), Quaternion.identity);
					Instantiate (starGrey, new Vector3 (xValue, yValue, 0), Quaternion.identity);
					Instantiate (starGrey, new Vector3 (xValue, yValue, 0), Quaternion.identity);*/
				} else if (SubLevel[j] == 2) {
					LevelOneStars = Star[j];
					/*Instantiate (star, new Vector3 (xValue, yValue, 0), Quaternion.identity);
					Instantiate (star, new Vector3 (xValue, yValue, 0), Quaternion.identity);
					Instantiate (starGrey, new Vector3 (xValue, yValue, 0), Quaternion.identity);*/
				} else if (SubLevel[j] == 3) {
					LevelOneStars = Star[j];
					/*Instantiate (star, new Vector3 (xValue, yValue, 0), Quaternion.identity);
					Instantiate (star, new Vector3 (xValue, yValue, 0), Quaternion.identity);
					Instantiate (star, new Vector3 (xValue, yValue, 0), Quaternion.identity);*/
				}
				else {
					Debug.Log("Storage file may be broken");
				}
				Debug.Log("Ensimmäisen levelin stars::: "+LevelOneStars);
			}
		}

	}
}
