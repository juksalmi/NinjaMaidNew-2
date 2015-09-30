using UnityEngine;
using System.Collections;

public class InstantiateFloor : MonoBehaviour {

	public Transform tile;

		void Start() {
			//for (int y = 120; y < 128; y++) {
				for (int x = 0; x < 10; x++) {			   		
					Instantiate(tile, new Vector3(300+x, 120+x, 0), Quaternion.identity);
					Instantiate(tile, new Vector3(302+x, 120+x, 0), Quaternion.identity);
					Instantiate(tile, new Vector3(304+x, 120+x, 0), Quaternion.identity);
					Instantiate(tile, new Vector3(306+x, 120+x, 0), Quaternion.identity);
					Instantiate(tile, new Vector3(308+x, 120+x, 0), Quaternion.identity);
					Instantiate(tile, new Vector3(310+x, 120+x, 0), Quaternion.identity);
					Instantiate(tile, new Vector3(312+x, 120+x, 0), Quaternion.identity);
					Instantiate(tile, new Vector3(314+x, 120+x, 0), Quaternion.identity);
				}
		//}
		}
	
	// Update is called once per frame
	void Update () {
	
	}
}
