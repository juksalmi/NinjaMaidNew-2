using UnityEngine;
using System.Collections;

public class PlayerDetection : MonoBehaviour {
	
	GameObject parent;
	
	void Start (){
		parent = this.transform.parent.gameObject;
		//		Debug.Log ("" + parent.name); 
	}
	
	void OnTriggerEnter2D(Collider2D other){
		//string direction = parent.GetComponent<Enemy> ().returnDirection ();
		if (other.gameObject.name == "Ninja") {
			sendConfirmation ();
		}
	}
	
	void OnTriggerStay2D(Collider2D other){
		//string direction = parent.GetComponent<Enemy> ().returnDirection ();
		if (other.gameObject.name == "Ninja") {
			sendConfirmation ();
		}
	}
	
	public void sendConfirmation (){
		//first check in what level you are
		if(Application.loadedLevelName == "LevelScene4"){
			//then check the name of enemy from where to trigger the followup
			if(parent.name == "Enemy1"){
				parent.GetComponent<Enemy1Scene2>().setPlayerDet();
			}
			else if(parent.name == "Enemy2"){
				parent.GetComponent<Enemy2Scene2>().setPlayerDet();
			}
		}
		
		if(Application.loadedLevelName == "LevelScene1"){
			//then check the name of enemy from where to trigger the followup
			if(parent.name == "Enemy"){
				parent.GetComponent<Enemy>().setPlayerDet();
			}
			//			else if(parent.name == "Enemy"){
			//				parent.GetComponent<Enemy>().setPlayerDet();
			//			}
		}
		
		if(Application.loadedLevelName == "LevelScene2"){
			//then check the name of enemy from where to trigger the followup
			if(parent.name == "Enemy"){
				parent.GetComponent<Enemy>().setPlayerDet();
			}
			//			else if(parent.name == "Enemy"){
			//				parent.GetComponent<Enemy>().setPlayerDet();
			//			}
		}
		
		if(Application.loadedLevelName == "LevelScene3"){
			//then check the name of enemy from where to trigger the followup
			if(parent.name == "Enemy"){
				parent.GetComponent<Enemy>().setPlayerDet();
			}
			//			else if(parent.name == "Enemy"){
			//				parent.GetComponent<Enemy>().setPlayerDet();
			//			}
		}
		
		
		
		
		
		
		
		// else [Any other level with enemy inside it]
	}
}

