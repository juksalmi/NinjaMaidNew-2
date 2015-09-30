using UnityEngine;
using System.Collections;

public class Enemy2Scene2 : MonoBehaviour {
	class Tile
	{
		public int x;   // x row
		public int y;  // y row
	}
	public GameObject[] detectCol;
	public GameObject exclMark;
	public GameObject player;
	private string direction;
	private Tile[] path;
	float duration = 1.0f;
	float timeElapsed = 0.0f;
	public float moveSpeed = 400f;
	string nextTileName;
	int index = 0;
	int lastX=0;
	int lastY=6;
	bool ok = true;
	GameObject nextTileToMove;
	bool foundPlayer = false;
	float timer;
	bool startHideExcl = false;

	private Animator animator;

	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator> ();

		Time.timeScale = 0.01f;
		path = new Tile[37];
		for (int i=0; i<path.Length; i++) {
			Tile tile = new Tile ();
			
			if(lastX != 5 && lastY==6 && i< 5 ) 
			{
				lastX++;
				tile.y = lastY;
				tile.x = lastX;
			}
			else if(lastX == 5 && lastY != 5 && i == 5 ) 
			{
				lastY--;
				tile.x = lastX;
				tile.y = lastY;
			}
			else if(lastX !=9 && lastY == 5 && i < 10){
				lastX ++;
				tile.x = lastX;
				tile.y = lastY;
			}
			else if(lastX == 9 && lastY != 3 && i < 12){
				lastY--;
				tile.x = lastX;
				tile.y = lastY;
			}
			else if(lastX !=8 && lastY == 3 && i < 13){
				lastX--;
				tile.x = lastX;
				tile.y = lastY;
			}
			else if(lastX == 8 && lastY != 2 && i < 14){
				lastY --;
				tile.x = lastX;
				tile.y = lastY;
			}
			else if(lastX != 4 && lastY == 2 && i < 18){
				lastX --;
				tile.x = lastX;
				tile.y = lastY;
			}
			else if(lastX == 4 && lastY != 3 && i < 19){
				lastY ++;
				tile.x = lastX;
				tile.y = lastY;
			}
			else if(lastX != 0 && lastY == 3 && i < 23){
				lastX--;
				tile.x = lastX;
				tile.y = lastY;
			}
			else if(lastX == 0 && lastY != 2 && i < 24){
				lastY --;
				tile.x = lastX;
				tile.y = lastY;
			}
			else if(lastX == 0 && lastY != 4 && i < 26){
				lastY ++;
				tile.x = lastX;
				tile.y = lastY;
			}
			else if(lastX != 5 && lastY == 4 && i < 32){
				lastX++;
				tile.x = lastX;
				tile.y = lastY;
			}
			else if(lastX == 5 && lastY != 6 && i < 34){
				lastY++;
				tile.x = lastX;
				tile.y = lastY;
			}
			else if(lastX !=1 && lastY == 6 && i < 37){
				lastX --;
				tile.x = lastX;
				tile.y = lastY;
			}
//			Debug.Log("X--- " + tile.x + "----Y---- " + tile.y );
			path[index] = tile;
			index++;
		}
		index = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (ok) {
			nextTileToMove = NextTileName ();
		}
		if (gameObject.transform.position.x == nextTileToMove.transform.position.x)
			ok = true;
		else {
			if (!foundPlayer) {
				float step = moveSpeed * Time.deltaTime;
				gameObject.transform.position = Vector3.MoveTowards (this.transform.position, nextTileToMove.transform.position, step);
				ok = false;
			} else if(foundPlayer) {
				float step = moveSpeed * Time.deltaTime;
				gameObject.transform.position = Vector3.MoveTowards (this.transform.position, player.transform.position, step);
				ok = false;
			}
		}
		getDirection ();
		FieldOfView ();
	}
	
	GameObject NextTileName()
	{
		int lastIndex = 0;
		if (index == 0)
			lastIndex = path.Length - 1;
		else
			lastIndex = index-1;
		//Debug.Log ("current Tile: "+path[lastIndex].x + " "+path[lastIndex].y);
		
//		Debug.Log ("Tile x = "+path[index].x);
//		Debug.Log ("Tile y  = "+path[index].y);
		GameObject nextTile = GameObject.Find("GameObject").GetComponent<InstantiateFloor2>().tileArray[path[index].x,path[index].y];
		if (index < path.Length-1 )
			index++;
		else
			index = 0;
		return nextTile;
	}
	void FieldOfView()
	{
		//Debug.Log ("Tile x = "+tiles[index].x);
		//Debug.Log ("Tile y  = "+tiles[index].y);
		//gameObject.GetComponent<SpriteRenderer>().color;
		/*for (int i=0; i<7; i++) {
			for (int j=0; j<8; j++) {
				GameObject.Find("GameObject").GetComponent<InstantiateFloor2>().tileArray[path[i].x,path[j].y].GetComponent<SpriteRenderer>().color = Color.white;
			}
		}*/
		if (!foundPlayer) {
			for (int i = 0; i < 2; i++) {
				if (direction == "Up") {

					animator.SetInteger("BurgerMoveDirections",1); 
					for (int j = 0; j < 3; j++) {
						detectCol [j].SetActive (false);
					}
					detectCol [3].SetActive (true);
					if(index == 19){
						GameObject test3 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [3,2];
						test3.GetComponent<SpriteRenderer> ().color = Color.white;
					}
					if(index == 32){
						GameObject test3 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [6,4];
						test3.GetComponent<SpriteRenderer> ().color = Color.white;
					}
					GameObject test = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [path [index - 1].x, path [index -1].y + i];
					test.GetComponent<SpriteRenderer> ().color = Color.red;
					GameObject test1 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [path [index - 1].x, path [index - 1].y -i -1];
					test1.GetComponent<SpriteRenderer> ().color = Color.white;
				}
				if (direction == "Down") {
					animator.SetInteger("BurgerMoveDirections",3); 

					detectCol [0].SetActive (false);
					detectCol [2].SetActive (false);
					detectCol [3].SetActive (false);
					detectCol [1].SetActive (true);
					if(index == 6){
						GameObject test3 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [6,6];
						test3.GetComponent<SpriteRenderer> ().color = Color.white;
					}
					if(index == 11){
						GameObject test3 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [10,5];
						test3.GetComponent<SpriteRenderer> ().color = Color.white;
					}
					if(index == 14){
						GameObject test3 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [7,3];
						test3.GetComponent<SpriteRenderer> ().color = Color.white;
					}
					GameObject test = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [path [index - 1].x, path [index -1].y -i];
					test.GetComponent<SpriteRenderer> ().color = Color.red;
					GameObject test1 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [path [index - 1].x, path [index -1].y + i +1];
					test1.GetComponent<SpriteRenderer> ().color = Color.white;
				}
				if (direction == "Left") {

				
					animator.SetInteger("BurgerMoveDirections",4); 

					detectCol [0].SetActive (true);
					detectCol [1].SetActive (false);
					detectCol [2].SetActive (false);
					detectCol [3].SetActive (false);
					GameObject test;
					GameObject test1;
//					Debug.Log(path[index-1].x );
//					Debug.LogError(path[index-1].y);
					if(path[index-2].x == 0){
						GameObject test2 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [2, path [index-1].y];
						test2.GetComponent<SpriteRenderer> ().color = Color.red;
					}
					if(index == 7){
						GameObject test3 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [5,4];
						test3.GetComponent<SpriteRenderer> ().color = Color.white;
					}
					if(index == 27){
						GameObject test3 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [0,5];
						test3.GetComponent<SpriteRenderer> ().color = Color.white;
					}
					test = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [ (path [index-1].x + i), path [index-1].y];
					test1 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [(path[index-1].x -i-1), path [index-1].y];
					test.GetComponent<SpriteRenderer> ().color = Color.red;
					test1.GetComponent<SpriteRenderer> ().color = Color.white;
				}
				if (direction == "Right") {

					animator.SetInteger("BurgerMoveDirections",2); 
					detectCol [0].SetActive (false);
					detectCol [1].SetActive (false);
					detectCol [3].SetActive (false);
					detectCol [2].SetActive (true);
					if(index !=0 ) {
						GameObject test = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [path [index-1].x -i , path [index - 1].y];
						test.GetComponent<SpriteRenderer> ().color = Color.red;
					}
					if(index == 0 )
					{
						GameObject test2 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [0, 6];
						test2.GetComponent<SpriteRenderer> ().color = Color.red;
						GameObject test3 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [2,6];
						test3.GetComponent<SpriteRenderer> ().color = Color.white;
					}
					if(index == 13){
						GameObject test3 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [9,2];
						test3.GetComponent<SpriteRenderer> ().color = Color.white;
					}
					if(index == 15){
						GameObject test3 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [8,1];
						test3.GetComponent<SpriteRenderer> ().color = Color.white;
					}
					if(index == 20){
						GameObject test3 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [4,4];
						test3.GetComponent<SpriteRenderer> ().color = Color.white;
					}
					GameObject test1 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [path [index -1].x + i +1, path [index - 1].y];
					test1.GetComponent<SpriteRenderer> ().color = Color.white;
				}
			}
		} else {
			timer += Time.deltaTime * 100;
			if (timer >= 2) //2 can be replaced with any number of seconds for the excl mark to disappear
				exclMark.SetActive (false);
			for (int i = 0; i < 7; i++) {
				for (int j = 0; j < 8; j++) {
					GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [j,i].GetComponent<SpriteRenderer> ().color = Color.white;
				}
			}
		}
		
	}
	
	void getDirection(){
		if ((index >=1 && index <= 5) || (index >=7 && index <= 10) || ( index >= 27 && index <= 31)) {
			direction = "Left";
		} else if (index == 6 || (index >= 11 && index <= 12) || index == 14 || index == 24) {
			direction = "Down";
		} else if (index == 13 || (index >= 15 && index <=18) || (index >= 20 && index <= 23) || (index >= 34 && index <= 36) || index == 0 ) {
			direction = "Right";
		} else if (index == 19 || (index >= 25 && index <= 26) || (index >= 32 && index <= 33)){
			direction = "Up";
		}
//		Debug.Log ("Direction ---- " + direction + "--------" + index );
	}
	
	public string returnDirection(){
		return direction;
	}
	
	IEnumerator hideMark(){
		yield return new WaitForSeconds (2f);
		exclMark.SetActive (false);
	}
	
	public void setPlayerDet(){
		foundPlayer = true;
		exclMark.SetActive (true);
		detectCol [0].SetActive (false);
		detectCol [1].SetActive (false);
		detectCol [3].SetActive (false);
		detectCol [2].SetActive (false);
		startHideExcl = true;
		timer = 0;
		player.GetComponent<PlayEffects> ().PlaySoundEffect(6);
	}
}
