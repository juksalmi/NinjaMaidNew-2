using UnityEngine;
using System.Collections;

public class TestHideCode : MonoBehaviour {

	public Sprite sprite1; // Drag your first sprite here
	public Sprite sprite2; // Drag your second sprite here
	float distance = 0.1f;
	bool mouseClicksStarted = false; 
	int mouseClicks = 0; 
	float mouseTimerLimit = .25f;

	
	private SpriteRenderer spriteRenderer; 
	
	void Start ()
	{
		spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
		if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
			spriteRenderer.sprite = sprite1; // set the sprite to sprite1
	}
	
	void Update ()
	{
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
					if (hit.collider.name == "Table(Clone)" || hit.collider.name == "Bonsai(Clone)")
					{
						if(Input.GetTouch(0).tapCount == 2)
							ChangeToHideMode ();
					} else {
						ChangeToNormalMode ();
					}				
				}
			}
		}

	}

	void ChangeToHideMode ()
	{
		if (spriteRenderer.sprite == sprite1) // if the spriteRenderer sprite = sprite1 then change to sprite2
		{
			spriteRenderer.sprite = sprite2;
		}
	}

	void ChangeToNormalMode ()
	{
		if (spriteRenderer.sprite == sprite2) // if the spriteRenderer sprite = sprite1 then change to sprite2
		{
			spriteRenderer.sprite = sprite1;
		}
	}	
	
	private void checkMouseDoubleClick()
	{
		Debug.Log("Left mouse button has been pressed at: " + Time.time);
	}
}
