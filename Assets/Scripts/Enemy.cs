using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
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
	int lastX=1;
	int lastY=6;
	bool ok = true;
	GameObject nextTileToMove;
	bool foundPlayer = false;
	float timer;
	bool startHideExcl = false;

	//jp 
	private Animator animator;

	//jp ends


	// Use this for initialization
	void Start () {
	
		// jp
		animator = GetComponent<Animator> ();	

		Time.timeScale = 0.01f;
		path = new Tile[20];

		for (int i=0; i<path.Length; i++) {
			Tile tile = new Tile ();

			if(lastX==0 && lastY != 6) // a, going from bottom left corner to bottom right corner
			{
				lastY++;
				tile.y = lastY;
				tile.x = lastX;
			}
			else if(lastX!=4 && lastY == 6 ) // b, going from bottom right corner to top right corner
			{
				lastX++;
				tile.x = lastX;
				tile.y = lastY;
			}
			else if(lastX==4 && lastY!=0) // c, going from top right corner to top left corner
			{
				lastY--;
				tile.y = lastY;
				tile.x = lastX;
			}
			else if(lastX !=0 && lastY == 0) // d, going from top left corner to bottom left corner
			{
				lastX--;
				tile.x = lastX;
				tile.y = lastY;
			}	
//			Debug.Log("X--- " + tile.x + "----Y---- " + tile.y );
			path[index] = tile;
			//Debug.Log("ind: "+index);
			//Debug.Log("x: "+tiles[index].x);
			//Debug.Log("y: "+tiles[index].y);
			index++;
		}
		index = 0;
	}

	// Update is called once per frame
	void Update () {
		if (ok) {
			//nextTileToMove = new GameObject ();
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
//		Debug.Log ("X---- " + nextTileToMove.transform.position.x + " Y----- " + nextTileToMove.transform.position.y);
//		Debug.Log ("" + index + "--------" + path[index].x + "---------" + path[index].y);

		/*
			timeElapsed += Time.deltaTime;
			if (timeElapsed > duration) {
				timeElapsed=0;

				GameObject nextTileToMove = NextTileName();
				//GameObject.Find("GameObject").GetComponent<TestInstantiate>().tileArray[
				//GameObject nextPlace = GameObject.Find(nextTileName);
				if(nextTileToMove!=null)
				{

					//Debug.Log("Tile found");
					this.transform.position = nextTileToMove.transform.position;
					//Debug.Log(this.transform.position.x +", "+this.transform.position.y);
					//Debug.Log(nextTileToMove.name);
				}
				else
				{
					//Debug.Log("Tile not found");
				}

			}*/
			//float step = 1.0f * Time.deltaTime;
			//this.transform.position = Vector3.MoveTowards(this.transform.position, nextTileToMove.transform.position, step);
	}

	GameObject NextTileName()
	{
		int lastIndex = 0;
		if (index == 0)
			lastIndex = path.Length - 1;
		else
			lastIndex = index-1;
		//Debug.Log ("current Tile: "+path[lastIndex].x + " "+path[lastIndex].y);

		//Debug.Log ("Tile x = "+tiles[index].x);
		//Debug.Log ("Tile y  = "+tiles[index].y);
		GameObject nextTile = GameObject.Find("GameObject").GetComponent<TestInstantiate>().tileArray[path[index].x,path[index].y];
		//Debug.Log ("next Tile "+path[index].x +" "+path[index].y);
		if (index < path.Length-1 )
			index++;
		else
			index = 0;
//		Debug.Log (nextTile.name);
		/*
		if (path [lastIndex].x > path [index].x) {
			Debug.Log ("Down");
			direction = "Down";
		}
		if (path [lastIndex].x < path [index].x) {
			Debug.Log ("Up");
			direction = "Up";
		}
		if (path [lastIndex].y > path [index].y) {
			Debug.Log ("Left");
			direction = "Left";
		}
		if (path [lastIndex].y < path [index].y) {
			Debug.Log ("Right");
			direction = "Right";
		}*/
		return nextTile;
	}
	void FieldOfView()
	{
		//Debug.Log ("Tile x = "+tiles[index].x);
		//Debug.Log ("Tile y  = "+tiles[index].y);
		//gameObject.GetComponent<SpriteRenderer>().color;
		/*for (int i=0; i<7; i++) {
			for (int j=0; j<8; j++) {
				GameObject.Find("GameObject").GetComponent<TestInstantiate>().tileArray[path[i].x,path[j].y].GetComponent<SpriteRenderer>().color = Color.white;
			}
		}*/
		if (!foundPlayer) {
			for (int i = -1; i < 1; i++) {
				if (direction == "Up") {

					//jp
//					Debug.Log ("Enemy move up :: --> 1"  );//my_moving_diretion
					animator.SetInteger("GrandmotherMoveDirection",1); 
					// jp

					for (int j = 0; j < 3; j++) {
						detectCol [j].SetActive (false);
					}
					detectCol [3].SetActive (true);
					GameObject test = GameObject.Find ("GameObject").GetComponent<TestInstantiate> ().tileArray [path [index - 1].x, path [index + i].y];
					test.GetComponent<SpriteRenderer> ().color = Color.red;
					GameObject test1 = GameObject.Find ("GameObject").GetComponent<TestInstantiate> ().tileArray [path [index - 2].x, path [index + i - 2].y];
					test1.GetComponent<SpriteRenderer> ().color = Color.white;
				}
				if (direction == "Down") {

					//jp
//					Debug.Log ("Enemy move DOWN :: --> 3"  );//my_moving_diretion
					animator.SetInteger("GrandmotherMoveDirection",3); 
					// jp


					detectCol [0].SetActive (false);
					detectCol [2].SetActive (false);
					detectCol [3].SetActive (false);
					detectCol [1].SetActive (true);
					if (index == 4)
						GameObject.Find ("GameObject").GetComponent<TestInstantiate> ().tileArray [5, 6].GetComponent<SpriteRenderer> ().color = Color.white;
					GameObject test = GameObject.Find ("GameObject").GetComponent<TestInstantiate> ().tileArray [path [index - 1].x, path [index + i].y];
					test.GetComponent<SpriteRenderer> ().color = Color.red;
					GameObject test1 = GameObject.Find ("GameObject").GetComponent<TestInstantiate> ().tileArray [path [index - 2].x, path [index + i - 2].y];
					test1.GetComponent<SpriteRenderer> ().color = Color.white;
				}
				if (direction == "Left") {

					//jp
//					Debug.Log ("Enemy move LEFT :: --> 4"  );//my_moving_diretion
					animator.SetInteger("GrandmotherMoveDirection",4); 
					// jp

					detectCol [0].SetActive (true);
					detectCol [1].SetActive (false);
					detectCol [2].SetActive (false);
					detectCol [3].SetActive (false);
					GameObject test;
					GameObject test1;
					if (index == 0) {
						test = GameObject.Find ("GameObject").GetComponent<TestInstantiate> ().tileArray [1 - i, 6];
						test1 = GameObject.Find ("GameObject").GetComponent<TestInstantiate> ().tileArray [0, 6];
					} else {
						test = GameObject.Find ("GameObject").GetComponent<TestInstantiate> ().tileArray [path [index + i].x, path [index - 1].y];
						if (index == 1) {
							test1 = GameObject.Find ("GameObject").GetComponent<TestInstantiate> ().tileArray [1, 6];
						} else if (index == 2) {
							test1 = GameObject.Find ("GameObject").GetComponent<TestInstantiate> ().tileArray [2, 6];
						} else {
							if(index == 3)
								test = GameObject.Find ("GameObject").GetComponent<TestInstantiate> ().tileArray [5, 6];
							test1 = GameObject.Find ("GameObject").GetComponent<TestInstantiate> ().tileArray [path [index + i - 2].x, path [index - 1].y]; 
						}
						//if(index)
					}
					test.GetComponent<SpriteRenderer> ().color = Color.red;
					test1.GetComponent<SpriteRenderer> ().color = Color.white;
				}
				if (direction == "Right") {
					//jp
//					Debug.Log ("Enemy move RIGHT :: --> 2"  );//my_moving_diretion
					animator.SetInteger("GrandmotherMoveDirection",2); 
					// jp


					detectCol [0].SetActive (false);
					detectCol [1].SetActive (false);
					detectCol [3].SetActive (false);
					detectCol [2].SetActive (true);
					GameObject test = GameObject.Find ("GameObject").GetComponent<TestInstantiate> ().tileArray [path [index + i].x, path [index - 1].y];
					test.GetComponent<SpriteRenderer> ().color = Color.red;
					GameObject test1 = GameObject.Find ("GameObject").GetComponent<TestInstantiate> ().tileArray [path [index + i - 2].x, path [index - 1].y];
					test1.GetComponent<SpriteRenderer> ().color = Color.white;
				}
			}
		} else {
			timer += Time.deltaTime * 100;
			if (timer >= 2) //2 can be replaced with any number of seconds for the excl mark to disappear
				exclMark.SetActive (false);
			for (int i = 0; i < 7; i++) {
				for (int j = 0; j < 8; j++) {
					GameObject.Find ("GameObject").GetComponent<TestInstantiate> ().tileArray [j,i].GetComponent<SpriteRenderer> ().color = Color.white;
				}
			}
		}

	}

	void getDirection(){
		if (index <= 3 ) {
			direction = "Left";
		} else if (index > 3 && index <= 9) {
			direction = "Down";
		} else if (index > 9 && index <= 13) {
			direction = "Right";
		} else if (index > 13 ){
			direction = "Up";
		}
//		Debug.Log ("Direction ---- " + direction);
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
