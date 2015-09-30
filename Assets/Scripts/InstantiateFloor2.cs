using UnityEngine;
using System.Collections;

public class InstantiateFloor2 : MonoBehaviour {
	public GameObject[,] tileArray;
	public GameObject tile;
	public GameObject table1;
	public GameObject table2;
	public GameObject table3;
	public GameObject table4;
	public GameObject table5;


	public GameObject chair1;
	public GameObject chair2;
	public GameObject chair3;
	public GameObject chair4;
	public GameObject chair5;
	public GameObject wc;
	public GameObject t1;

	public GameObject t2;
	public GameObject t3;
	public GameObject st1;
	public GameObject st2;
	public GameObject st3;

	public GameObject bt;
	public GameObject bp;

	private MouseDragLevel2 mousedragscript2;

	
	
	public GameObject counter;

	private float tileWidth;
	private float tileHeight;
	public int HouseIndex;
	//public Transform wall;
	int tileIndex =0;
	void Start() {
		tileWidth = tile.GetComponent<Renderer>().bounds.size.x;
		tileHeight = tile.GetComponent<Renderer>().bounds.size.y;
		//Debug.Log (tileWidth + " " + tileHeight);
		tileArray = new GameObject[24,7];
		generateRoom (24, 7);
		generateObstacles ();
	}
	public void generateRoom(int wide, int length)
	{
		for (int x = 0; x < wide; x++) {
			
			for (int y = 0; y < length; y++) {	
				
				GameObject newTile = tile;					
				newTile.name = "tile_"+x+"_"+y;
				newTile.transform.position = new Vector3((y*tileWidth/2) - (x*tileWidth/2), (y*tileHeight/2) + (x*tileHeight/2), 0);
				newTile.transform.rotation = Quaternion.identity; 
				GameObject newTileInstatiated = Instantiate(newTile.gameObject);





				if ((y == 0 || y == 1) && x == 18) {
					newTileInstatiated.GetComponent<SpriteRenderer> ().material.color = Color.white;
					
					newTileInstatiated.tag = "T1";
				}
				
				else if ((y == 5 || y == 6) && x == 20) {
					newTileInstatiated.GetComponent<SpriteRenderer> ().material.color = Color.white;
					
					newTileInstatiated.tag = "T2";
				}
				
				else if ((y == 5 || y == 6) && x == 11) {
					newTileInstatiated.GetComponent<SpriteRenderer> ().material.color = Color.white;
					
					newTileInstatiated.tag = "T3";
				}
				else if ( y == 0 && (x==13 || x==14 || x==15)){
					newTileInstatiated.GetComponent<SpriteRenderer>().material.color=Color.white;
					
					newTileInstatiated.tag = "St2";
				}
				
				else if ( y == 6 && (x==7 || x==8 || x ==9 )){
					newTileInstatiated.GetComponent<SpriteRenderer>().material.color=Color.white;
					
					newTileInstatiated.tag = "St3";
				}
				
				else if ( y == 6 && (x==14 || x==15 || x==16 || x==17)){
					newTileInstatiated.GetComponent<SpriteRenderer>().material.color=Color.white;
					
					newTileInstatiated.tag = "St1";
					
				}
				
				else if ( y == 5 && (x==0 || x==1 || x==2 || x==3 || x==4 )){
					newTileInstatiated.GetComponent<SpriteRenderer>().material.color=Color.white;
					
					newTileInstatiated.tag = "Counter";
					
				}
				else if (( y == 0 || y == 1 )  && (x==21 || x==22 || x==23 )){
					newTileInstatiated.GetComponent<SpriteRenderer>().material.color=Color.white;
					
					newTileInstatiated.tag = "Bp";
					
				}
				else if ((y == 0 || y == 1 || y == 2) && (x == 1 || x == 2)){
					newTileInstatiated.GetComponent<SpriteRenderer> ().material.color = Color.white;
					
					newTileInstatiated.tag = "Bt";
				}
		
				else if ((y == 6) && (x == 23 )){
					newTileInstatiated.GetComponent<SpriteRenderer> ().material.color = Color.white;
					
					newTileInstatiated.tag = "Wc";
				}
		//		"5_1", "9_1" , "6_4"
				else if ((y == 1) && (x == 5) || (y == 1) && (x == 9) ||(y == 4) && (x == 6))
				{
					newTileInstatiated.GetComponent<SpriteRenderer> ().material.color = Color.white;
					
					newTileInstatiated.tag = "Chair2";
				}

				else if ((y == 3) && (x == 12 )){
					newTileInstatiated.GetComponent<SpriteRenderer> ().material.color = Color.white;
					
					newTileInstatiated.tag = "Chair3";
				}

				else if ((y == 6) && (x == 7 )|| (y == 6) && (x == 8 )|| (y == 6) && (x == 9 )|| (y == 6) && (x == 14 )|| (y == 6) && (x == 15 )|| (y == 6) && (x == 16 )|| (y == 6) && (x == 17 )|| (y == 0) && (x == 13 ) ){
					newTileInstatiated.GetComponent<SpriteRenderer> ().material.color = Color.white;
					
					newTileInstatiated.tag = "Chair5";
				}

				else if ((y == 1) && (x == 7 )  || (y == 4) && (x == 18 )  ||(y == 4) && (x == 8 )  ||(y == 2) && (x == 13 )   ){
					newTileInstatiated.GetComponent<SpriteRenderer> ().material.color = Color.white;
					
					newTileInstatiated.tag = "Chair1";
				}

				else if ((y == 0) && (x == 6 )  || (y == 3) && (x == 7 )  ||(y == 3) && (x == 10 )  ||(y == 3) && (x == 15 )  ||(y == 3) && (x == 17 ) ){
					newTileInstatiated.GetComponent<SpriteRenderer> ().material.color = Color.white;
					
					newTileInstatiated.tag = "Chair4";
				}

				else if ((y == 4) && (x == 7 )  || (y == 1) && (x == 10 )  ||(y == 4) && (x == 15 )     ){
					newTileInstatiated.GetComponent<SpriteRenderer> ().material.color = Color.white;
					
					newTileInstatiated.tag = "Table1";
				}

				else if ((y == 2) && (x == 12 )     ){
					newTileInstatiated.GetComponent<SpriteRenderer> ().material.color = Color.white;
					
					newTileInstatiated.tag = "Table2";
				}

				else if ((y == 4) && (x == 17 )     ){
					newTileInstatiated.GetComponent<SpriteRenderer> ().material.color = Color.white;
					
					newTileInstatiated.tag = "Table3";
				}


				else if ((y == 4) && (x == 10 )     ){
					newTileInstatiated.GetComponent<SpriteRenderer> ().material.color = Color.white;
					
					newTileInstatiated.tag = "Table4";
				}

				else if ((y == 1) && (x == 6 )     ){
					newTileInstatiated.GetComponent<SpriteRenderer> ().material.color = Color.white;
					
					newTileInstatiated.tag = "Table5";
				}


			//	"12_3"				
				// chair
/*				level2[5, 1] = 1;
				level2[6, 0] = 1;
				level2[6, 1] = 1;
				level2[7, 1] = 1;

*/  
			//	string[] coordinatesChair5 = new string[] { "7_6", "8_6", "9_6", "14_6", "15_6", "16_6", "17_6", "13_0"

				//		"7_1","18_4", "8_4" , "13_2" chair 1
	/*	else if ( /*(y == 0) && (x == 6)  (y == 1) && (x ==7) /*||(y == 1) && (x == 7))
				{
					newTileInstatiated.GetComponent<SpriteRenderer> ().material.color = Color.white;
					
					newTileInstatiated.tag = "kk";
				}
				*/

				else 
				{
				
					newTileInstatiated.GetComponent<SpriteRenderer>().material.color=Color.gray;
					

					newTileInstatiated.tag = "Floor";


				}

				tileArray[x,y] = newTileInstatiated;


			}
		}

	
/*	
		for (int i  =0 ; i <24 ; i++)
		{
			for (int j  =0 ; j <7 ; j++)
			{

				if (	MouseDragLevel2.level2[i, j] == 0 ) 
				{
					

				}
				else
				{
								//GameObject temppu= GetComponent<InstantiateFloor2>().tileArray[i,j];
			//		tileArray[i,j].GetComponent<SpriteRenderer>().material.color=Color.black;
				}
				
			}
			
		}

	
	*/
	
	
	
	}

	void generateObstacles()
	{
		Vector3 centerPosBp = Vector3.zero;
		GameObject[] bpTiles = GameObject.FindGameObjectsWithTag ("Bp");
		foreach (GameObject tile in bpTiles) {
			centerPosBp.x += tile.transform.position.x;
			centerPosBp.y += tile.transform.position.y;
		}
		centerPosBp.x /= bpTiles.Length;
		centerPosBp.y /= bpTiles.Length;
		
		GameObject bpObject = (GameObject)GameObject.Instantiate (bp, centerPosBp, Quaternion.identity);
		bpObject.GetComponent<SpriteRenderer> ().sortingOrder = 1;


		Vector3 centerPosBt = Vector3.zero;
		GameObject[] btTiles = GameObject.FindGameObjectsWithTag ("Bt");
		foreach (GameObject tile in btTiles) {
			centerPosBt.x += tile.transform.position.x;
			centerPosBt.y += tile.transform.position.y;
		}
		centerPosBt.x /= btTiles.Length;
		centerPosBt.y /= btTiles.Length;
		
		GameObject btObject = (GameObject)GameObject.Instantiate (bt, centerPosBt, Quaternion.identity);
		btObject.GetComponent<SpriteRenderer> ().sortingOrder = 1;
		



		Vector3 centerPosT1 = Vector3.zero;
		GameObject[] t1Tiles = GameObject.FindGameObjectsWithTag ("T1");
		foreach (GameObject tile in t1Tiles) {
			centerPosT1.x += tile.transform.position.x;
			centerPosT1.y += tile.transform.position.y;
		}
		centerPosT1.x /= t1Tiles.Length;
		centerPosT1.y /= t1Tiles.Length;
		
		GameObject t1Object = (GameObject)GameObject.Instantiate (t1, centerPosT1, Quaternion.identity);
		t1Object.GetComponent<SpriteRenderer> ().sortingOrder = 1;
		
		
		Vector3 centerPosT2 = Vector3.zero;
		GameObject[] t2Tiles = GameObject.FindGameObjectsWithTag ("T2");
		foreach (GameObject tile in t2Tiles) {
			centerPosT2.x += tile.transform.position.x;
			centerPosT2.y += tile.transform.position.y;
		}
		centerPosT2.x /= t2Tiles.Length;
		centerPosT2.y /= t2Tiles.Length;
		
		GameObject t2Object = (GameObject)GameObject.Instantiate (t2, centerPosT2, Quaternion.identity);
		t2Object.GetComponent<SpriteRenderer> ().sortingOrder = 1;
		
		Vector3 centerPosT3 = Vector3.zero;
		GameObject[] t3Tiles = GameObject.FindGameObjectsWithTag ("T3");
		foreach (GameObject tile in t3Tiles) {
			centerPosT3.x += tile.transform.position.x;
			centerPosT3.y += tile.transform.position.y;
		}
		centerPosT3.x /= t3Tiles.Length;
		centerPosT3.y /= t3Tiles.Length;
		
		GameObject t3Object = (GameObject)GameObject.Instantiate (t3, centerPosT3, Quaternion.identity);
		t3Object.GetComponent<SpriteRenderer> ().sortingOrder = 1;
		
		
		Vector3 centerPosSt2 = Vector3.zero;
		GameObject[] st2Tiles = GameObject.FindGameObjectsWithTag ("St2");
		foreach (GameObject tile in st2Tiles) {
			centerPosSt2.x += tile.transform.position.x;
			centerPosSt2.y += tile.transform.position.y;
		}
		centerPosSt2.x /= st2Tiles.Length;
		centerPosSt2.y /= st2Tiles.Length;
		Debug.Log ("x: "+centerPosSt2.x+", y:"+centerPosSt2.y);
		GameObject st2Object = (GameObject)GameObject.Instantiate (st2, centerPosSt2, Quaternion.identity);
		st2Object.GetComponent<SpriteRenderer> ().sortingOrder = 3;
		
		
		Vector3 centerPosSt3 = Vector3.zero;
		GameObject[] st3Tiles = GameObject.FindGameObjectsWithTag ("St3");
		foreach (GameObject tile in st3Tiles) {
			centerPosSt3.x += tile.transform.position.x;
			centerPosSt3.y += tile.transform.position.y;
		}
		centerPosSt3.x /= st3Tiles.Length;
		centerPosSt3.y /= st3Tiles.Length;
		
		GameObject st3Object = (GameObject)GameObject.Instantiate (st3, centerPosSt3, Quaternion.identity);
		st3Object.GetComponent<SpriteRenderer> ().sortingOrder = 1;
		
		
		
		Vector3 centerPosSt1 = Vector3.zero;
		GameObject[] st1Tiles = GameObject.FindGameObjectsWithTag ("St1");
		foreach (GameObject tile in st1Tiles) {
			centerPosSt1.x += tile.transform.position.x;
			centerPosSt1.y += tile.transform.position.y;
		}
		centerPosSt1.x /= st1Tiles.Length;
		centerPosSt1.y /= st1Tiles.Length;
		
		GameObject st1Object = (GameObject)GameObject.Instantiate (st1, centerPosSt1, Quaternion.identity);
		st1Object.GetComponent<SpriteRenderer> ().sortingOrder = 1;

		
		
		
		/*string[] coordinatesChair2 = new string[] { "7_0", "8_3", "11_3", "16_3", "18_3" };
		
		foreach (string coordinateChair2 in coordinatesChair2) {
			if (GameObject.Find ("tile_"+coordinateChair2+"(Clone)").transform) {
				var xValue = GameObject.Find ("tile_"+coordinateChair2+"(Clone)").transform.position.x;
				var yValue = GameObject.Find ("tile_"+coordinateChair2+"(Clone)").transform.position.y;
				Instantiate (chair, new Vector3 (xValue, yValue, 0), Quaternion.identity);
				chair.transform.Rotate(0, 180, 0, Space.World); 
				chair.GetComponent<SpriteRenderer> ().sortingOrder = 1;
			}
			
		}*/

		//"7_0", "6_1", "8_1", "10_1", "8_3", "7_4", "9_4", "10_1", "11_3", "14_2", "13_3", "16_3", "18_3", "19_4" 

		string[] coordinatesTable1 = new string[] { "7_4", "10_1", "15_4" };
		foreach (string coordinateTable1 in coordinatesTable1) {
			if (GameObject.Find ("tile_"+coordinateTable1+"(Clone)").transform) {
				var xValue = GameObject.Find ("tile_"+coordinateTable1+"(Clone)").transform.position.x;
				var yValue = GameObject.Find ("tile_"+coordinateTable1+"(Clone)").transform.position.y;
				Instantiate (table1, new Vector3 (xValue, yValue, 0), Quaternion.identity);
				table1.GetComponent<SpriteRenderer> ().sortingOrder = 2;
			}
		}
		
		string[] coordinatesTable5 = new string[] { "6_1" };
		foreach (string coordinateTable5 in coordinatesTable5) {
			if (GameObject.Find ("tile_"+coordinateTable5+"(Clone)").transform) {
				var xValue = GameObject.Find ("tile_"+coordinateTable5+"(Clone)").transform.position.x;
				var yValue = GameObject.Find ("tile_"+coordinateTable5+"(Clone)").transform.position.y;
				Instantiate (table5, new Vector3 (xValue, yValue, 0), Quaternion.identity);
				table5.GetComponent<SpriteRenderer> ().sortingOrder = 2;
			}
		}
		string[] coordinatesTable3 = new string[] { "17_4" };
		foreach (string coordinateTable3 in coordinatesTable3) {
			if (GameObject.Find ("tile_"+coordinateTable3+"(Clone)").transform) {
				var xValue = GameObject.Find ("tile_"+coordinateTable3+"(Clone)").transform.position.x;
				var yValue = GameObject.Find ("tile_"+coordinateTable3+"(Clone)").transform.position.y;
				Instantiate (table3, new Vector3 (xValue, yValue, 0), Quaternion.identity);
				table3.GetComponent<SpriteRenderer> ().sortingOrder = 2;
			}
		}
		string[] coordinatesTable4 = new string[] { "10_4" };
		foreach (string coordinateTable4 in coordinatesTable4) {
			if (GameObject.Find ("tile_"+coordinateTable4+"(Clone)").transform) {
				var xValue = GameObject.Find ("tile_"+coordinateTable4+"(Clone)").transform.position.x;
				var yValue = GameObject.Find ("tile_"+coordinateTable4+"(Clone)").transform.position.y;
				Instantiate (table4, new Vector3 (xValue, yValue, 0), Quaternion.identity);
				table4.GetComponent<SpriteRenderer> ().sortingOrder = 2;
			}
		}
		string[] coordinatesTable2 = new string[] { "12_2" };
		foreach (string coordinateTable2 in coordinatesTable2) {
			if (GameObject.Find ("tile_"+coordinateTable2+"(Clone)").transform) {
				var xValue = GameObject.Find ("tile_"+coordinateTable2+"(Clone)").transform.position.x;
				var yValue = GameObject.Find ("tile_"+coordinateTable2+"(Clone)").transform.position.y;
				Instantiate (table2, new Vector3 (xValue, yValue, 0), Quaternion.identity);
				table2.GetComponent<SpriteRenderer> ().sortingOrder = 2;
			}
		}


		
		Vector3 centerPosCounter = Vector3.zero;
		GameObject[] counterTiles = GameObject.FindGameObjectsWithTag ("Counter");
		foreach (GameObject tile in counterTiles) {
			centerPosCounter.x += tile.transform.position.x;
			centerPosCounter.y += tile.transform.position.y;
		}
		centerPosCounter.x /= counterTiles.Length;
		centerPosCounter.y /= counterTiles.Length;
		
		GameObject counterObject = (GameObject)GameObject.Instantiate (counter, centerPosCounter, Quaternion.identity);
		counterObject.GetComponent<SpriteRenderer> ().sortingOrder = 1;
		
		
		
		string[] coordinatesChair4 = new string[] { "6_0","7_3", "10_3" , "15_3" , "17_3"};
		
		foreach (string coordinateChair4 in coordinatesChair4) {
			if (GameObject.Find ("tile_"+coordinateChair4+"(Clone)").transform) {
				var xValue = GameObject.Find ("tile_"+coordinateChair4+"(Clone)").transform.position.x;
				var yValue = GameObject.Find ("tile_"+coordinateChair4+"(Clone)").transform.position.y;
				Instantiate (chair4, new Vector3 (xValue, yValue, 0), Quaternion.identity);
				chair4.GetComponent<SpriteRenderer> ().sortingOrder = 1;
			}
			
		}
		
		string[] coordinatesChair1 = new string[] { "7_1","18_4", "8_4" , "13_2" };
		
		foreach (string coordinateChair1 in coordinatesChair1) {
			if (GameObject.Find ("tile_" + coordinateChair1 + "(Clone)").transform) {
				var xValue = GameObject.Find ("tile_" + coordinateChair1 + "(Clone)").transform.position.x;
				var yValue = GameObject.Find ("tile_" + coordinateChair1 + "(Clone)").transform.position.y;
				Instantiate (chair1, new Vector3 (xValue, yValue, 0), Quaternion.identity);
				chair1.GetComponent<SpriteRenderer> ().sortingOrder = 1;
			}
		}
		
		string[] coordinatesChair2 = new string[] { "5_1", "9_1" , "6_4" };
		
		foreach (string coordinateChair2 in coordinatesChair2) {
			if (GameObject.Find ("tile_" + coordinateChair2 + "(Clone)").transform) {
				var xValue = GameObject.Find ("tile_" + coordinateChair2 + "(Clone)").transform.position.x;
				var yValue = GameObject.Find ("tile_" + coordinateChair2 + "(Clone)").transform.position.y;
				Instantiate (chair2, new Vector3 (xValue, yValue, 0), Quaternion.identity);
				chair2.GetComponent<SpriteRenderer> ().sortingOrder = 1;
			}
		}
		string[] coordinatesChair3 = new string[] { "12_3" };
		
		foreach (string coordinateChair3 in coordinatesChair3) {
			if (GameObject.Find ("tile_" + coordinateChair3 + "(Clone)").transform) {
				var xValue = GameObject.Find ("tile_" + coordinateChair3 + "(Clone)").transform.position.x;
				var yValue = GameObject.Find ("tile_" + coordinateChair3 + "(Clone)").transform.position.y;
				Instantiate (chair3, new Vector3 (xValue, yValue, 0), Quaternion.identity);
				chair3.GetComponent<SpriteRenderer> ().sortingOrder = 1;
			}
		}
		
		
		string[] coordinatesChair5 = new string[] { "7_6", "8_6", "9_6", "14_6", "15_6", "16_6", "17_6", "13_0" };
		
		foreach (string coordinateChair5 in coordinatesChair5) {
			if (GameObject.Find ("tile_" + coordinateChair5 + "(Clone)").transform) {
				var xValue = GameObject.Find ("tile_" + coordinateChair5 + "(Clone)").transform.position.x;
				var yValue = GameObject.Find ("tile_" + coordinateChair5 + "(Clone)").transform.position.y;
				Instantiate (chair5, new Vector3 (xValue, yValue, 0), Quaternion.identity);
				chair5.GetComponent<SpriteRenderer> ().sortingOrder = 2;
			}
		}
		string[] coordinatesWc = new string[] { "23_6" };
		
		foreach (string coordinateWc in coordinatesWc) {
			if (GameObject.Find ("tile_" + coordinateWc + "(Clone)").transform) {
				var xValue = GameObject.Find ("tile_" + coordinateWc + "(Clone)").transform.position.x;
				var yValue = GameObject.Find ("tile_" + coordinateWc + "(Clone)").transform.position.y;
				Instantiate (wc, new Vector3 (xValue, yValue, 0), Quaternion.identity);
				wc.GetComponent<SpriteRenderer> ().sortingOrder = 1;
			}
		}


	}


	// Update is called once per frame
	void Update () {
		
	}
}
