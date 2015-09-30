using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class Top10Script : MonoBehaviour {
	private Database databaseScript;
	private MouseDrag mouseDragScript;
	public GameObject TopTenItem;
	public GameObject TopTenItem1;
	public GameObject TopTenItem2;
	public GameObject TopTenItem3;
	public GameObject TopTenItem4;
	public GameObject TopTenItem5;
	public GameObject TopTenItem6;
	public GameObject TopTenItem7;
	public GameObject TopTenItem8;
	public GameObject TopTenItem9;
	public GameObject nameInput;


	public static int currentLevel = MouseDrag.my_current_level;
	public static string fileName = "";

	// Use this for initialization
	void Start () {

	
		Debug.Log ("MouseDrag.not_top_ten: "+MouseDrag.not_top_ten);
		


		if  ( MouseDrag.not_top_ten == false )
		{
			
			Database.top_ten_name_each_level[ MouseDrag.my_current_level,MouseDrag.temp_rank] = nameInput.GetComponent<InputField>().text;
			
			Debug.Log("nameInput.GetComponent<Text>().text:: "+ nameInput.GetComponent<InputField>().text);
			
			writeTop10File (fileName);
			
		}
		
		
		
		
		//for (int i=0; i<10; i++) {
		TopTenItem.GetComponent<Text>().text   = "1. "+ Database.top_ten_score_each_level[MouseDrag.my_current_level,0]+ " "+ Database.top_ten_name_each_level [MouseDrag.my_current_level,0];
		TopTenItem1.GetComponent<Text>().text  = "2. "+ Database.top_ten_score_each_level[MouseDrag.my_current_level,1]+ " "+ Database.top_ten_name_each_level [MouseDrag.my_current_level,1];
		TopTenItem2.GetComponent<Text>().text  = "3. "+ Database.top_ten_score_each_level[MouseDrag.my_current_level,2]+ " "+ Database.top_ten_name_each_level [MouseDrag.my_current_level,2];
		TopTenItem3.GetComponent<Text>().text  = "4. "+ Database.top_ten_score_each_level[MouseDrag.my_current_level,3]+ " "+ Database.top_ten_name_each_level [MouseDrag.my_current_level,3];
		TopTenItem4.GetComponent<Text>().text  = "5. "+ Database.top_ten_score_each_level[MouseDrag.my_current_level,4]+ " "+ Database.top_ten_name_each_level [MouseDrag.my_current_level,4];
		TopTenItem5.GetComponent<Text>().text  = "6. "+ Database.top_ten_score_each_level[MouseDrag.my_current_level,5]+ " "+ Database.top_ten_name_each_level [MouseDrag.my_current_level,5];
		TopTenItem6.GetComponent<Text>().text  = "7. "+ Database.top_ten_score_each_level[MouseDrag.my_current_level,6]+ " "+ Database.top_ten_name_each_level [MouseDrag.my_current_level,6];
		TopTenItem7.GetComponent<Text>().text  = "8. "+ Database.top_ten_score_each_level[MouseDrag.my_current_level,7]+ " "+ Database.top_ten_name_each_level [MouseDrag.my_current_level,7];
		TopTenItem8.GetComponent<Text>().text  = "9. "+ Database.top_ten_score_each_level[MouseDrag.my_current_level,8]+ " "+ Database.top_ten_name_each_level [MouseDrag.my_current_level,8];
		TopTenItem9.GetComponent<Text>().text  = "10. "+ Database.top_ten_score_each_level[MouseDrag.my_current_level,9]+ " "+ Database.top_ten_name_each_level [MouseDrag.my_current_level,9];
		

}


	public static void writeTop10File (string fileName) {
		var file = File.CreateText (fileName);
		for (int i = 0; i < 10; i++) {
			string temppu = Database.top_ten_score_each_level[MouseDrag.my_current_level,i]+ "," +Database.top_ten_name_each_level[MouseDrag.my_current_level,i];
			file.WriteLine (temppu);
		}
		file.Close ();
	}
	
	public static void readTop10File (string fileName) {
		var reader = File.OpenText (fileName);
		string[] topTenList = new string [10];
		for (int i = 0; i < 10; i++) {
			string temppu = reader.ReadLine();
			
			string[] strArr = null;

			if ( temppu.Length >0)
			{

				char[] delimiterChars = {  ',' };
				strArr = temppu.Split(delimiterChars);
			
				Database.top_ten_score_each_level[MouseDrag.my_current_level,i]=int.Parse(strArr[0] );
				Database.top_ten_name_each_level[MouseDrag.my_current_level,i]= strArr[1]; 
			}	


		}
		reader.Close ();
	}


}
