using UnityEngine;
using System.Collections;

public class TestInstantiate : MonoBehaviour {
	public GameObject[,] tileArray;
	public GameObject tile;
	public GameObject table;
	public GameObject bonsai;
	public GameObject pilow;
	public GameObject partition;
	
	private float tileWidth;
	private float tileHeight;
	//public Transform wall;
	int tileIndex =0;
	void Start() {
		tileWidth = tile.GetComponent<Renderer>().bounds.size.x;
		tileHeight = tile.GetComponent<Renderer>().bounds.size.y;
		//Debug.Log (tileWidth + " " + tileHeight);
		tileArray = new GameObject[8,7];
		generateRoom (8, 7);
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


				newTileInstatiated.GetComponent<SpriteRenderer>().material.color=Color.gray;


				if(( x==6 || x == 5)&& y==5)
				{
					newTileInstatiated.GetComponent<SpriteRenderer>().material.color=Color.white;

					newTileInstatiated.tag = "Table";
				}
				else if(( x==7 && y==1 ) || ( x==7 && y==3)){
					newTileInstatiated.GetComponent<SpriteRenderer>().material.color=Color.white;

					newTileInstatiated.tag = "Bonsai";
				}
				else if ( x == 1 && (y==2 || y==3)){
					newTileInstatiated.GetComponent<SpriteRenderer>().material.color=Color.white;

					newTileInstatiated.tag = "Pilow";
				}
				else if ( x == 3 && (y==1 || y==2 || y ==3 || y==4)){
					newTileInstatiated.GetComponent<SpriteRenderer>().material.color=Color.white;

					newTileInstatiated.tag = "Partition";
				}

				else 
				{
					newTileInstatiated.tag = "Floor";
				}


				tileArray[x,y] = newTileInstatiated;
				//Debug.Log(newTile.transform.position.x);
				//Debug.Log("Tile = " +tileArray[x,y]);
			}
		}

		
	}
	void generateObstacles()
	{
		//---------------Table---------------------
		Vector3 centerPosTable = Vector3.zero;
		GameObject[] tableTiles = GameObject.FindGameObjectsWithTag ("Table");
		foreach (GameObject tile in tableTiles) {
			centerPosTable.x += tile.transform.position.x;
			centerPosTable.y += tile.transform.position.y;
		}
		centerPosTable.x /= tableTiles.Length;
		centerPosTable.y /= tableTiles.Length;
		
		GameObject tableObject = (GameObject)GameObject.Instantiate (table, centerPosTable, Quaternion.identity);
		tableObject.GetComponent<SpriteRenderer> ().sortingOrder = 1;
		
		//
		//		//---------------Partition---------------------
		Vector3 centerPosPartition = Vector3.zero;
		GameObject[] partitionTiles = GameObject.FindGameObjectsWithTag ("Partition");
		foreach (GameObject tile in partitionTiles) {
			centerPosPartition.x += tile.transform.position.x;
			centerPosPartition.y += tile.transform.position.y;
		}
		centerPosPartition.x /= partitionTiles.Length;
		centerPosPartition.y /= partitionTiles.Length;
		
		GameObject partitionObject = (GameObject)GameObject.Instantiate (partition, centerPosPartition, Quaternion.identity);
		partitionObject.GetComponent<SpriteRenderer> ().sortingOrder = 1;
		partitionObject.transform.localScale = new Vector3 (1, 1, 0);
		
		
		
		//----------------Pilow--------------
		Vector3 centerPosPilow = Vector3.zero;
		GameObject[] pilowTiles = GameObject.FindGameObjectsWithTag ("Pilow");
		foreach (GameObject tile in pilowTiles) {
			centerPosPilow.x += tile.transform.position.x;
			centerPosPilow.y += tile.transform.position.y;
		}
		centerPosPilow.x /= pilowTiles.Length;
		centerPosPilow.y /= pilowTiles.Length;
		
		GameObject pilowObject = (GameObject)GameObject.Instantiate (pilow, centerPosPilow, Quaternion.identity);
		pilowObject.GetComponent<SpriteRenderer> ().sortingOrder = 1;
		pilowObject.transform.localScale = new Vector3 (1, 1, 0);
		

		
		
		
		
		//-----------------Bonsai-------------------
		GameObject[] bonsaiTiles = GameObject.FindGameObjectsWithTag("Bonsai");
		foreach (GameObject tile in bonsaiTiles) {
			Vector3 centerPosBonsai = Vector3.zero;
			centerPosBonsai.x += tile.transform.position.x;
			centerPosBonsai.y += tile.transform.position.y;
			GameObject bonsaiObject = (GameObject)GameObject.Instantiate (bonsai, centerPosBonsai, Quaternion.identity);
			bonsaiObject.GetComponent<SpriteRenderer> ().sortingOrder = 1;
				bonsaiObject.transform.localScale = new Vector3(1f, 1f, 1f);
		//	bonsaiObject.transform.localScale = new Vector3(1f, 1f, 1f);
			
			
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}


