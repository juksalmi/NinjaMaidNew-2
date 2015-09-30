using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using UnityEditor;

public class ButtonClick : MonoBehaviour {
	public GameObject pauseCanvas;
	public GameObject storeCanvas;
	public GameObject topTenCanvas;
	public GameObject rewardCanvas;
	public GameObject nameInput;
	private Database databaseScript;

	private MouseDrag mousedragscript;



	public void StoryClick()
	{
		Application.LoadLevel("MapScene");
	}

	public void LevelCompleteNextClick()
	{
		Time.timeScale = 0;
		topTenCanvas.SetActive (true);
		rewardCanvas.SetActive (false);
		string name = nameInput.GetComponent<InputField> ().text.ToString();

		Database.score [MouseDrag.my_current_level] = 0;
		MouseDrag.power_celection = 0;


		// Database.top_ten_name_each_level[MouseDrag.my_current_level,]     Top_ten_level_ranking.name_of_player = name;
	}

	public void TopTenGoBack()
	{
		Time.timeScale = 0;
		rewardCanvas.SetActive (true);
		topTenCanvas.SetActive (false);
	}

	public void TopTenNextClick ()
	{
		Time.timeScale = 0;
		topTenCanvas.SetActive (false);
		storeCanvas.SetActive (true);
	}

	public void StoreClickGoBack()
	{
		Time.timeScale = 0;
		storeCanvas.SetActive (false);
		topTenCanvas.SetActive (true);
	}
	
	public void ClickTest(string areaName)
	{
		Debug.Log (areaName);
		//Application.LoadLevel("StarScene");
		Application.LoadLevel("LevelScene1");
	}

	public void StartClick()
	{
		//Application.LoadLevel("StarScene");
		Application.LoadLevel("StoryScene");
	}

	public void ClickBack()
	{
		Database.score [MouseDrag.my_current_level] = 0;
		MouseDrag.power_celection = 0;

		Application.LoadLevel("MapScene");
	}

	public void ClickQuit()
	{

		Database.score [MouseDrag.my_current_level] = 0;
		MouseDrag.power_celection = 0;

		Application.Quit();
	}

	public void StartGame()
	{
		Database.score [MouseDrag.my_current_level] = 0;
		MouseDrag.power_celection = 0;

		Application.LoadLevel("LevelScene1");
	}

	public void ClickPause()
	{
		Time.timeScale = 0;
		Debug.Log ("TIMEEEE::: "+Time.timeScale);
		pauseCanvas.SetActive (pauseCanvas);
	}

	public void MenuButtonClick ()
	{
		Database.score [MouseDrag.my_current_level] = 0;
		MouseDrag.power_celection = 0;

		Time.timeScale = 0.01f;
		Application.LoadLevel("MapScene");
	}

	public void MenuRestartClick ()
	{
		Time.timeScale = 0.01f;
		Database.score [MouseDrag.my_current_level] = 0;
		MouseDrag.power_celection = 0;

		Debug.Log ("LEVEL NAME::: "+Application.loadedLevelName);
		Application.LoadLevel(Application.loadedLevelName);
	}

	public void MenuPlayClick ()
	{
		Database.score [MouseDrag.my_current_level] = 0;
		MouseDrag.power_celection = 0;

		pauseCanvas.SetActive (false);
		Time.timeScale = 0.01f;
	}

	public void ClickNextLevel ()
	{
		//Load next level
		int i = Application.loadedLevel;
		Application.LoadLevel(i + 1);

		Database.score [MouseDrag.my_current_level] = 0;
		MouseDrag.power_celection = 0;

	}
}
