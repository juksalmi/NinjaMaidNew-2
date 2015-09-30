using UnityEngine;
using System.Collections;

public class HidePlayer : MonoBehaviour {
	public GameObject touched_object;
	public GameObject player;
	float distance = 0.1f;
	private SpriteRenderer spriteRenderer;
	public Sprite spriteHide;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
		Vector3 objPosition = Camera.main.ScreenToWorldPoint (mousePosition); 
		//GameObject.Find("GameObject").GetComponent<TestInstantiate>().tileArray;
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay(mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
			
			if (hit != null) 
			{
				if (hit.collider !=null)
				{
					if (hit.collider.name == "Table(Clone)")
					{
						Debug.Log("Toimiii!!!!!!!"+hit.collider.name);
						spriteRenderer.sprite = spriteHide;
					}
					
					

				}
			}
		}

	
	}
}
