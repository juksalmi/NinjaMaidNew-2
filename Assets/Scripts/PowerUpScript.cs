using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerUpScript : MonoBehaviour {

	public static bool pover_up_used=false;
	public int powerSpeed;
	public GameObject ShoesAmount;
	public GameObject GlovesAmount;
	public GameObject TeaAmount;
	private MouseDrag mousedragscript;
	private MouseDragLevel2 mousedragscript2;
	private Database databaseScript;
	public GameObject piippi;

//	private PowerUpTimer powerUptimer;

	void Awake ()
	{
		ShoesAmount.GetComponent<Text> ().text = Database.shoes.ToString ();
		GlovesAmount.GetComponent<Text> ().text = Database.gloves.ToString ();
		TeaAmount.GetComponent<Text> ().text = Database.tea.ToString ();
	}
	
	public void ShoesPowerUp () {
		if (Database.shoes != 0) {
			piippi.GetComponent<PlayEffects> ().PlaySoundEffect(0);
			Database.shoes --;
			ShoesAmount.GetComponent<Text> ().text = Database.shoes.ToString ();
			MouseDrag.power_celection = 1;
			MouseDragLevel2.power_celection = 1;
		
//			PowerUpTimer.myTime = 10f;
			pover_up_used=true;

		}
	}

	public void GlovesPowerUp () {
		if (Database.gloves != 0) {
			piippi.GetComponent<PlayEffects> ().PlaySoundEffect(1);
			Database.gloves --;
			GlovesAmount.GetComponent<Text> ().text = Database.gloves.ToString ();
			MouseDrag.power_celection = 2;
			MouseDragLevel2.power_celection = 2;

//			PowerUpTimer.myTime = 10f;
			pover_up_used=true;
		}
	}

	public void TeaPowerUp () {	
		if (Database.tea != 0) {
			piippi.GetComponent<PlayEffects> ().PlaySoundEffect(2);
			Database.tea --;
			TeaAmount.GetComponent<Text> ().text = Database.tea.ToString ();
			MouseDrag.power_celection = 3;
			MouseDragLevel2.power_celection = 3;

//			PowerUpTimer.myTime = 10f;
			pover_up_used=true;
		}
	}
}
