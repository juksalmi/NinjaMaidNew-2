using UnityEngine;
using System.Collections;

public class Enemy1Scene2 : MonoBehaviour {
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
	int lastX=21;
	int lastY=4;
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
		path = new Tile[28];
		for (int i=0; i<path.Length; i++) {
			Tile tile = new Tile ();
			
			if(lastX == 21 && lastY != 2 &&  i < 3) 
			{
				lastY--;
				tile.y = lastY;
				tile.x = lastX;
			}
			else if(lastX !=14 && lastY == 2 && i < 9) 
			{
				lastX--;
				tile.x = lastX;
				tile.y = lastY;
			}
			else if(lastX == 14 && lastY != 1 && i == 9){
				lastY --;
				tile.x = lastX;
				tile.y = lastY;
			}
			else if(lastX != 11 && lastY == 1 && i <13){
				lastX--;
				tile.x = lastX;
				tile.y = lastY;
			}
			else if(lastX == 11 && lastY != 4 && i<16 ){
				lastY++;
				tile.x = lastX;
				tile.y = lastY;
			}
			else if(lastX != 14 && lastY == 4 && i<19){
				lastX++;
				tile.x = lastX;
				tile.y = lastY;
			}
			else if(lastX == 14 && lastY != 5 && i == 19){
				lastY++;
				tile.x = lastX;
				tile.y = lastY;
			}
			else if(lastX != 19 && lastY == 5 && i <25){
				lastX ++;
				tile.x = lastX;
				tile.y = lastY;
			}
			else if(lastX == 19 && lastY != 4 && i == 25){
				lastY--;
				tile.x = lastX;
				tile.y = lastY;
			}
			else if(lastX != 21 && lastY == 4 && i < 28){
				lastX ++;
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


					animator.SetInteger("enemy2_move",1); 
					for (int j = 0; j < 3; j++) {
						detectCol [j].SetActive (false);
					}
					detectCol [3].SetActive (true);
					if(index == 14){
						GameObject test3 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [10,1];
						test3.GetComponent<SpriteRenderer> ().color = Color.white;
					}
					if(index == 20){
						GameObject test3 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [15,4];
						test3.GetComponent<SpriteRenderer> ().color = Color.white;
					}
					GameObject test = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [path [index - 1].x, path [index -1].y + i];
					test.GetComponent<SpriteRenderer> ().color = Color.red;
					GameObject test1 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [path [index - 1].x, path [index - 1].y -i -1];
					test1.GetComponent<SpriteRenderer> ().color = Color.white;
				}
				if (direction == "Down") {

					animator.SetInteger("enemy2_move",3); 
					detectCol [0].SetActive (false);
					detectCol [2].SetActive (false);
					detectCol [3].SetActive (false);
					detectCol [1].SetActive (true);
					if(index == 1){
						GameObject test2 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [22,4];
						test2.GetComponent<SpriteRenderer> ().color = Color.white;
					}
					if(index == 10){
						GameObject test3 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [13,2];
						test3.GetComponent<SpriteRenderer> ().color = Color.white;
					}
					if(index == 11){
						GameObject test3 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [10,5];
						test3.GetComponent<SpriteRenderer> ().color = Color.white;
					}
					if(index == 26){
						GameObject test3 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [20,5];
						test3.GetComponent<SpriteRenderer> ().color = Color.white;
					}
					GameObject test = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [path [index - 1].x, path [index -1].y -i];
					test.GetComponent<SpriteRenderer> ().color = Color.red;
					GameObject test1 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [path [index - 1].x, path [index -1].y + i +1];
					test1.GetComponent<SpriteRenderer> ().color = Color.white;
				}
				if (direction == "Left") {

					animator.SetInteger("enemy2_move",4); 
					detectCol [0].SetActive (true);
					detectCol [1].SetActive (false);
					detectCol [2].SetActive (false);
					detectCol [3].SetActive (false);
					if(index == 0 )
					{
						GameObject test3 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [20,4];
						test3.GetComponent<SpriteRenderer> ().color = Color.white;
						GameObject test2 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [22, 4];
						test2.GetComponent<SpriteRenderer> ().color = Color.red;
					}
					GameObject test;
					GameObject test1;
					if(index == 17){
						GameObject test3 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [11,5];
						test3.GetComponent<SpriteRenderer> ().color = Color.white;
					}
					if(index == 21){
						GameObject test3 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [14,6];
						test3.GetComponent<SpriteRenderer> ().color = Color.white;
					}
					if(index == 27){
						GameObject test3 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [19,3];
						test3.GetComponent<SpriteRenderer> ().color = Color.white;
					}
					test = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [ (path [index-1].x + i), path [index-1].y];
					test1 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [(path[index-1].x -i-1), path [index-1].y];
					test.GetComponent<SpriteRenderer> ().color = Color.red;
					test1.GetComponent<SpriteRenderer> ().color = Color.white;
				}
				if (direction == "Right") {

					animator.SetInteger("enemy2_move",2); 
					detectCol [0].SetActive (false);
					detectCol [1].SetActive (false);
					detectCol [3].SetActive (false);
					detectCol [2].SetActive (true);
					if(index !=0 ) {
						GameObject test = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [path [index-1].x -i , path [index - 1].y];
						test.GetComponent<SpriteRenderer> ().color = Color.red;
					}
					if(index == 3){
						GameObject test3 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [21,1];
						test3.GetComponent<SpriteRenderer> ().color = Color.white;
					}
					if(index == 11){
						GameObject test3 = GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [14,0];
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
				for (int j = 0; j < 24; j++) {
					GameObject.Find ("GameObject").GetComponent<InstantiateFloor2> ().tileArray [j,i].GetComponent<SpriteRenderer> ().color = Color.white;
				}
			}
		}
		
	}
	
	void getDirection(){
		if ((index >=17 && index <= 19) || (index >= 21 && index <= 25) || (index >= 27 && index <= 28)) {
			direction = "Left";
		} else if ((index >=1 && index <= 2) || index == 10 || index == 26) {
			direction = "Down";
		} else if ((index >=3 && index <= 9) || (index >= 11 && index <= 13)){
			direction = "Right";
		} else if ((index >= 14 && index <= 16) || index == 20){
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
