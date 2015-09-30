using UnityEngine;
using System.Collections;
using Microsoft;
using UnityEngine.UI;
using System;
using System.IO;

public class MouseDrag : MonoBehaviour {
	public static int my_current_level ;
	public static bool not_top_ten  ;

	public static int temp_rank;
	public float[] PoverUpCelection = new float[4];  

	public float[] PoverUpLenght = new float[4];

	public int[] LevelDB = new int [100];
	public int[] SubLevelDB = new int [100];
	public int[] StarDB = new int [100];
	public int[] TimeLevelDB = new int [100];
	public int[] CoinsDB = new int [100];
	public int[] GemsDB = new int [100];
	public int levelAmount;
	public int subLevelIndex;
	public int starsCompleted;
	public GameObject UITimeBonus;
	public GameObject UIScore;
	public GameObject UIGems;
	public GameObject UICoins;
	public GameObject UIGemsFail;
	public GameObject UICoinsFail;
	public GameObject CanvasFailed ;
	public int CoinsAmount;
	public int GemsAmount;
	public Slider slider;
	public GameObject Star1;
	public GameObject Star2;
	public GameObject Star3;
	public GameObject rewardScreen;
	public int my_position_index_x;
	public int my_position_index_y;
	public int my_old_position_index_x;
	public int my_old_position_index_y;
	static int my_moving_diretion;
	public int[,] level1;
	public int[,] level1_floor_status;

	float distance = 0.1f;//1;//10;
	//float duration = 0.5f;
	float duration = 0.7f;

	float coloranimationLength ;


	public bool my_double_mover_y=false, my_double_mover_x=false ;
	public 	int move_direction = 0 ;


	public GameObject moved_directions;
	public Color lerpedColor = Color.white;
	public int  num_of_tile = 45 ;
	public GameObject guiScore  ;
	public GameObject game_score  ;
	public int score;

	public int kerroin =1;

	public float speed = 1.0f ;//0.5F;
	private float startTime;
	bool isMoving = false;
	//	Vector3 objPosition;
	float timer;
	public static float poweruppi_timer;
	Vector3 startPos;
	private Animator animator;
	AudioSource audio;
	AudioSource audio2;
	public static int power_celection=0;

	public GameObject piippi;

	private Database databaseScript;
	private Top10Script top10script;

	private PowerUpScript powerupscript;

	float time_bonus = 0;

	public string fileName;

	public string fileName_2;

	void Awake()
	{	
		animator = GetComponent<Animator> ();	
		audio =  GetComponent<AudioSource>();
		//audio2 = GetComponent<AudioSource>();

		//audio2 = GameObject.Find ("MainCamera").GetComponent<AudioSource>();
		audio2  = Camera.main.GetComponent<AudioSource>();
		//GameObject.Find ("Maincamera").GetComponent<AudioSource> ().mute = true;

		fileName = "";
		#if  UNITY_IPHONE
		Debug.Log("Running on Apple Device.");
		string fileNameBase = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf('/'));
		fileName = fileNameBase.Substring(0, fileNameBase.LastIndexOf('/')) + "/Documents/" + "Storage.txt";
		#elif UNITY_ANDROID
		Debug.Log("Running on Android Device.");
		fileName = Application.persistentDataPath + "/" + "Storage.txt" ;
		#elif UNITY_EDITOR
		//		Debug.Log("Not running on mobile Device.");
		fileName = Application.streamingAssetsPath+ "/" + "Storage.txt";
		#else
		//		Debug.Log("Not optimized for this platform");
		#endif
	}

	void Start() {
		num_of_tile = 45 ;
		level1 = new int[8,7];
		level1_floor_status = new int[8,7];
		my_position_index_x=0;
		my_position_index_y=0;

		level1[7, 1] = 1;
		level1[7, 3] = 1;
		level1[6, 5] = 1;
		level1[5, 5] = 1;
		
		level1[3, 1] = 1;
		level1[3, 2] = 1;
		level1[3, 3] = 1;
		level1[3, 4] = 1;
		
		level1[1, 2] = 1;
		level1[1, 3] = 1;
		
		for (int i  =0 ; i <8 ; i++)
		{
			for (int j  =0 ; j <7 ; j++)
			{
				level1_floor_status[i,j]=1;
			}
			
		}
		
		level1_floor_status [0, 0] = 0;
		startTime = Time.time;

		PoverUpCelection [ 0 ] = 90f;	// default 
		PoverUpCelection [ 1 ] = 150f;	// power up 1
		PoverUpCelection [ 2 ] = 300f;	// power up 2
		PoverUpCelection [ 3 ] = 490f;	// power up 3


		PoverUpLenght [ 0 ] = 0f;	// default 
		PoverUpLenght [ 1 ] = 0.11f;	// power up 1
		PoverUpLenght [ 2 ] = 0.08f;	// power up 2
		PoverUpLenght [ 3 ] = 0.05f;	// power up 3
		





		Debug.Log ("mouse drag startti !!!!!!!!!!!!!!!");	



		#if  UNITY_IPHONE
		Debug.Log("Running on Apple Device.");
		string fileNameBase = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf('/'));
		fileName_2 = fileNameBase.Substring(0, fileNameBase.LastIndexOf('/')) + "/Documents/" + "Top10_"+my_current_level.ToString()+".txt";
		#elif UNITY_ANDROID
		Debug.Log("Running on Android Device.");
		fileName_2 = Application.persistentDataPath + "/" + "Top10_"+my_current_level.ToString()+".txt" ;
		#elif UNITY_EDITOR
		//		Debug.Log("Not running on mobile Device.");
		fileName_2 = Application.streamingAssetsPath+ "/" + "Top10_"+my_current_level.ToString()+".txt";
		#else
		//		Debug.Log("Not optimized for this platform");
		#endif
		Top10Script.fileName = fileName_2;

		if (!File.Exists (fileName_2)) {
			Top10Script.  writeTop10File (fileName_2);
			Debug.Log ("File created!!");
		} else {
			Debug.Log ("database alustus  !");
			
			Top10Script.readTop10File(fileName_2);
		}
		// readTop10File (fileName); 


	}

	//If enters 2D collider Enemy OR Coin OR Gem
	void OnTriggerEnter2D(Collider2D col)
	{ 
		if (col.name == "Enemy") {
			UICoinsFail.GetComponent<Text>().text = CoinsAmount.ToString();
			UIGemsFail.GetComponent<Text>().text = GemsAmount.ToString();
			piippi.GetComponent<PlayEffects> ().PlaySoundEffect(7);
			CanvasFailed.SetActive(true);
			Time.timeScale=0;
			
			Debug.Log ("Enter");	
		}
		
		if (col.name == "Coin") {
		//	Debug.Log ("HEY");
			//PlaySoundEffect(0);
			piippi.GetComponent<PlayEffects> ().PlaySoundEffect(3);
			Database.score[ my_current_level ] = Database.score[ my_current_level ] + 100;
			CoinsAmount += 1;
			Destroy(col.gameObject);				
		}

		if (col.name == "Gem") {
			//PlaySoundEffect(0);
			piippi.GetComponent<PlayEffects> ().PlaySoundEffect(4);
			Database.score[ my_current_level ] = Database.score[ my_current_level ] + 500;
			GemsAmount += 1;
			Destroy(col.gameObject);				
		}
	}
	
	void MoveTimer()
	{
		timer += Time.deltaTime * PoverUpCelection [power_celection];

		float animationLength = timer/duration;

		if (level1_floor_status[my_position_index_x,my_position_index_y]  == 1 )
		{

			level1_floor_status[my_position_index_x,my_position_index_y]  = 0;
			piippi.GetComponent<PlayEffects> ().PlaySoundEffect(5);
			num_of_tile --;
			//	Debug.Log ("num_of_tile : "+num_of_tile);
			float sliderValue = slider.value;

			if (sliderValue <= 3.33f) {
			
				kerroin = 10;
			} else if (sliderValue >= 3.33f && sliderValue <= 6.66f) {
				kerroin = 5;
			} else if (sliderValue > 6.66f && sliderValue < 10f){
				kerroin = 2;
			} else {
				kerroin = 1;					
			}


			Database.score[ my_current_level ] = Database.score[ my_current_level ] + kerroin;
		
			//	Debug.Log ("Database.score[ 0 ]: "+Database.score[ 0 ]);

			// all tiles has been collected ... go reward screen !!
			if (num_of_tile == 0 ) 
			{
				//	float sliderValue = slider.value;
				temp_rank=11;
				int  ranking =0;
			    not_top_ten  = true;
				
				
				time_bonus =  (10 - sliderValue)*100 ;
				
				Debug.Log ("time_bonus: "+time_bonus);
				
				Debug.Log ("time_bonus: int  "+(int) time_bonus);
				
				
				Database.score[ my_current_level ] = Database.score[ my_current_level ] + (int) time_bonus;
				
				while ( ranking < 10 && not_top_ten )
				{
					if ( Database.score[ my_current_level ] > Database.top_ten_score_each_level [ my_current_level , ranking ]  )
					{
						not_top_ten= false;
						temp_rank = ranking; 
					}
					ranking++;
					
				}// end while  
				

				for ( int i = 0 ; i<10 ; i++){
					Database.top_ten_score_each_level [ 9 , i ] = Database.top_ten_score_each_level [ my_current_level , i];
					Database.top_ten_name_each_level [ 9 , i ] = Database.top_ten_name_each_level [ my_current_level , i];

				}

				for ( int i = 0 ; i<10 ; i++)
				{
					
					if ( i > temp_rank && i<=9)
					{
						Database.top_ten_score_each_level [ my_current_level , i ] = Database.top_ten_score_each_level [ 9 , i-1 ];
						Database.top_ten_name_each_level [ my_current_level , i ] =Database.top_ten_name_each_level [ 9 , i-1 ];
						
					}
					
					else if ( i == temp_rank)
					{
						Database.top_ten_score_each_level [ my_current_level , temp_rank ] = Database.score[ my_current_level ] ;
						Database.top_ten_name_each_level [ my_current_level , temp_rank ] = "jp" ;
					}
					
					else if ( i < temp_rank)
					{
						// rank is better  than rank score
						Database.top_ten_score_each_level [ my_current_level , i ] = Database.top_ten_score_each_level [ 9 , i ];
						Database.top_ten_name_each_level [ my_current_level , i ] =Database.top_ten_name_each_level [ 9 , i ];
					}
					
				Debug.Log ("rank nr " + i+": "+ Database.top_ten_name_each_level [ my_current_level , i ] +"  score :: "+Database.top_ten_score_each_level [ my_current_level , i ]);
				}
				
				
				
				if (sliderValue <= 3.33f) {
					Debug.Log ("Huippu pelaaja");
					starsCompleted = 3;
					piippi.GetComponent<PlayEffects> ().PlaySoundEffect(8);
				} else if (sliderValue >= 3.33f && sliderValue <= 6.66f) {
					starsCompleted = 2;
					Star3.SetActive (false);
					piippi.GetComponent<PlayEffects> ().PlaySoundEffect(9);
				} else if (sliderValue > 6.66f && sliderValue < 10f){
					starsCompleted = 1;
					Star2.SetActive (false);
					Star3.SetActive (false);
					piippi.GetComponent<PlayEffects> ().PlaySoundEffect(10);
				} else {
					starsCompleted = 0;
					Star1.SetActive (false);
					Star2.SetActive (false);
					Star3.SetActive (false);
					Debug.Log ("Paska pelaaja");					
				}
				time_bonus = (int)time_bonus;
				UITimeBonus.GetComponent<Text>().text = time_bonus.ToString();
				UICoins.GetComponent<Text>().text = CoinsAmount.ToString();
				UIGems.GetComponent<Text>().text = GemsAmount.ToString();
				UIScore.GetComponent<Text>().text = Database.score[ my_current_level ].ToString();
				rewardScreen.SetActive(true);
				Time.timeScale=0;
				
				//start testing if update, new line or do nothing
				int houseIndex = 0;
				int subLevelInt = getSubLevel();
				int starsAmount = starsCompleted;
				int amountOfLevelsOpen = Counter (fileName);
				int time = 0;
			
				
				if (amountOfLevelsOpen == 0) {
					saveToFile(fileName, houseIndex, subLevelInt, starsAmount, time, CoinsAmount, GemsAmount);
				} else if (amountOfLevelsOpen == 1) {
					saveToFile(fileName, houseIndex, subLevelInt, starsAmount, time, CoinsAmount, GemsAmount);
				} else if (amountOfLevelsOpen == 2) {
					saveToFile(fileName, houseIndex, subLevelInt, starsAmount, time, CoinsAmount, GemsAmount);
				}
				
				Debug.Log ("House index SaveProgress::" + houseIndex.ToString () + ", Sub Level Index:: " + subLevelInt.ToString () + ", stars:: " + starsAmount.ToString () + ", time:::" + time.ToString() + ", amount of levels open:::" + amountOfLevelsOpen.ToString());
			}		
		}
		else
		{
			//	lerpedColor = Color.Lerp(Color.white, Color.white, animationLength);
			//	lerpedColor = Color.Lerp(Color.grey, Color.white, animationLength);

		}
		
		//	GameObject.Find("GameObject").GetComponent<TestInstantiate>().tileArray[my_position_index_x,my_position_index_y].GetComponent<SpriteRenderer>().material.color =lerpedColor;
		transform.position = Vector3.Lerp(startPos, moved_directions.transform.position, animationLength);
	
		if (animationLength >= 1.0f) {
			timer = 0.0f;
			isMoving = false;
		}
	}

	void check_poveruptimer(){
	
		poweruppi_timer += Time.deltaTime;//+ 10f; ;
		
		float power_effect = poweruppi_timer ; //timer/duration;

//		Debug.Log ("power_effect "+power_effect+ "  power_celection = " +power_celection+ " PowerUpScript.pover_up_used == "+PowerUpScript.pover_up_used );
		
	

///		if (power_effect >= 0.05f)
			if ( power_effect >= PoverUpLenght [ power_celection ] )
		{
			poweruppi_timer = 0.0f;
			PowerUpScript.pover_up_used = false;
			//power_celection=0;
			 power_celection=0;
		}
	
	}


	void Update()
	{

		if (PowerUpScript.pover_up_used) {

			check_poveruptimer();

		} 
		else 
		{
		
			//PowerUpScript.pover_up_used=false;
		
		}

		if (isMoving)
		{
			MoveTimer ();
			//	#if UNITY_EDITOR
		}
		else
		{
			if (PowerUpScript.pover_up_used) {
				
				check_poveruptimer();
				
			} 



			//if (
			Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);

			guiScore.GetComponent<Text>().text=num_of_tile.ToString();

			game_score.GetComponent<Text>().text=Database.score[ my_current_level ].ToString();

			GameObject.Find("GameObject").GetComponent<TestInstantiate>().tileArray[my_position_index_x,my_position_index_y].GetComponent<SpriteRenderer>().material.color =Color.Lerp(Color.grey, Color.white,1);

			if (Input.GetMouseButton(0)) 
			{
				//	Debug.Log ("Update --> else haara: GetMouseButton  -->hit  ");
				Ray ray = Camera.main.ScreenPointToRay(mousePosition);
				RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
				float hide_distance = Mathf.Abs(hit.point.x - this.transform.position.x );	
//				Debug.Log("hide_distance::  ->"+hide_distance);	
				
//				Debug.Log("hit.collider.name::  ->"+hit.collider.name);	
				//	RaycastHit2D hit2 = Physics2D.Raycast(transform.position, -Vector2.up);
 				if (   /* hit.collider.name.Contains("Coin") || hit.collider.name.Contains("Gem") || */ hit.collider.name.Contains("Pillow") || hit.collider.name.Contains("Partition") || hit.collider.name.Contains("Table") || hit.collider.name.Contains("bamboo") ) 
				{
					Debug.Log("hit.collider.name::  ->"+hit.collider.name);	

					Debug.Log("hide_distance:: 2 ->"+hide_distance);	
					
					Debug.Log("hit.collider.name::  ->"+hit.collider.name);	
					if (  hide_distance <1.8  )
					{
						transform.position = GameObject.Find(hit.collider.name).transform.position;
					}
				}
				
				else //if (hit != null) 
				{	

//					Debug.Log("else ::hit.collider.name::  ->"+hit.collider.name);	

	//				if ( hit.collider !=null && hit.collider.name != "Ninja"   &&  move_allowed )
					if (  hit.collider !=null && hit.collider.name != "Ninja"   &&  ninja_move_checker(hit.collider.name ) )

					{
						moved_directions=GameObject.Find(hit.collider.name);
						float distCovered = (Time.time - startTime) * speed;

						if(!isMoving)
						{
							isMoving=true;
							startPos = this.transform.position;
						}
					}
				}		
			}
		}
		
		if (Input.GetMouseButtonUp(0)) 
		{	
			//	Debug.Log("nappin painnallus lopetettu");	
			//	Debug.Log("nappin painnallus lopetettu");	
			//	Debug.Log("nappin painnallus lopetettu");	
			//	Debug.Log("nappin painnallus lopetettu");	

			  move_direction  =0;
//			Debug.Log ("move_direction mouse up :: "+move_direction  );//my_moving_diretion
			animator.SetInteger("Ninja_move_direction",move_direction); 


		}





	}  // update




	int tile_x_index( string tile_name )
	{
//		Debug.Log ("tile_x_index = "+tile_name );

		return 	int.Parse( tile_name.Substring (5, 1));
	}
	
	int tile_y_index( string tile_name )
	{
		return 	 int.Parse(tile_name.Substring(7, 1))  ;
	}

	//	bool ninja_move_checker(int new_x  , int new_y)
	bool ninja_move_checker(string tile_name)	
	{
		//		Debug.Log ("ninja_move_checker = "+tile_name );
		
		bool return_value = true;
		bool negative = false;
		int new_x, new_y;
		
		my_double_mover_y = false;
		my_double_mover_x = false;
		new_x = tile_x_index (tile_name);
		new_y = tile_y_index (tile_name);
		//Debug.Log ("new_x = "+new_x +"new_y = "+new_y);
		// first will be checked area bondaries 0<= new x <= 7
		
		if (new_x < 0 || new_x > 7) {
			//return_value =false;
			return false;		
		}
		
		if (new_y < 0 || new_y > 6) {
			//return_value =false;
			return false;	
		}
		
		// ninja can not move 2 tile in once !!
		//	if ( Mathf.Abs( my_position_index_x - new_x) >=2  )
		if (Mathf.Abs (my_position_index_x - new_x) > 2) {
			return_value = false;
		}
		
		//		if ( Mathf.Abs( my_position_index_y - new_y) >=2  )
		if (Mathf.Abs (my_position_index_y - new_y) > 2) {
			return_value = false;
		}
		
		if (Mathf.Abs (my_position_index_x - new_x) == 2 )
		{
			
			my_double_mover_x=true;
			
			if (new_x >my_position_index_x) 
				negative = true;
			
		}
		
		
		if (Mathf.Abs (my_position_index_y - new_y) == 2)
		{
			
			my_double_mover_y=true;
			
			if (new_y >my_position_index_y) 
				negative = true;
			
			
		}
		
		// next will be checked furniture places 
		if ( level1[new_x, new_y] == 1)
		{
			return_value =false;
		}
		
		// next will be checked allowed directions left -- right , up -- down  not possible change both same time !!
		if ( return_value == true &&  new_x != this.my_position_index_x &&  new_y != this.my_position_index_y )
		{
			return_value =false;	
		}	
		//Debug.Log ("return_value "+return_value  );
		
		if ( return_value )
		{	
			move_direction = my_ninja_is_moving(my_position_index_x, new_x, my_position_index_y, new_y);
			//			Debug.Log ("move_direction "+move_direction  );//my_moving_diretion
			animator.SetInteger("Ninja_move_direction",move_direction); 
			my_old_position_index_x = my_position_index_x;
			my_old_position_index_y = my_position_index_y ;
			my_position_index_x = new_x;
			my_position_index_y = new_y ;
			
			double_mover_fixer(my_double_mover_x , my_double_mover_y , tile_name, negative);
			
		}
		return return_value;
	}

	
	int my_ninja_is_moving (int old_x , int new_x ,int old_y , int new_y)
	{
		int return_value = 0;// ninja is idle =0 ;
		if  ( old_x == new_x && new_y > old_y )
		{
			// ninja is moving up !!
			return_value = 1; 
			//Debug.Log ("ninja is moving up ==>return_value "+return_value  );
		}
		
		if  ( old_x == new_x && new_y < old_y )
		{
			// ninja is moving down !!
			return_value = 3; 
			//Debug.Log ("ninja is moving down ==>return_value "+return_value  );	
		}
		
		if  ( old_x > new_x && new_y == old_y )
		{
			// ninja is moving right  !!
			return_value = 2; 
			//Debug.Log ("ninja is moving right ==>return_value "+return_value  );	
		}
		
		if  ( old_x < new_x && new_y  == old_y )
		{
			// ninja is moving left !!
			return_value = 4; 
			//Debug.Log ("ninja is moving left ==>return_value "+return_value  );	
		}
		//Debug.Log ("return_value "+return_value  );
		my_moving_diretion = return_value;
		return return_value;
	}

	//New level has been completed
	static void saveToFile(string fileName, int houseIndex, int subLevelIndex, int starsAmount, int time, int coinsAmount, int gemsAmount)
	{
		var sw = File.AppendText(fileName);
		sw.WriteLine (houseIndex);//level
		sw.WriteLine (subLevelIndex);//sublevel
		sw.WriteLine (starsAmount);//stars
		sw.WriteLine (time);//time
		sw.WriteLine (coinsAmount);//coins
		sw.WriteLine (gemsAmount);//gems
		sw.Close();
		Debug.Log(fileName+" saved.");
	}

	//Game has been completed with better scores
	static void updateToFile(string fileName, int houseIndex, int subLevelIndex, int starsAmount, int time, int coinsAmount, int gemsAmount)
	{
		string[] lines = File.ReadAllLines(fileName);
		string allString = "";
		lines [0] = houseIndex.ToString();
		lines [1] = subLevelIndex.ToString();
		lines [2] = starsAmount.ToString();
		lines [3] = time.ToString();
		lines [4] = coinsAmount.ToString();
		lines [5] = gemsAmount.ToString();
		for(int i=0; i<lines.Length; i++) {
			allString += lines[i]+"\n";
		} 
		File.WriteAllText(fileName, allString);
	}

	//Get the index of sublevel from the loaded level index
	public int getSubLevel () {
		Debug.Log ("LEVEL NAME::: "+Application.loadedLevelName + "LEVEL index: " +Application.loadedLevel);
		if (Application.loadedLevelName == "LevelScene1") {
			subLevelIndex = 0;
		} else if (Application.loadedLevelName == "LevelScene2") {
			subLevelIndex = 1;
		} else if (Application.loadedLevelName == "LevelScene3") {
			subLevelIndex = 2;
		}
		return subLevelIndex;
	}

	public int Counter (string fileName) {
		int count = 0;
		var sr = File.OpenText (fileName);
		string line;
		while ((line = sr.ReadLine()) != null)
		{
			count++;
		}
		sr.Close ();
		levelAmount = count / 6;
		return levelAmount;
	}

	public void readFile(string fileName)
	{
		int levelAmount = Counter (fileName);
		var reader = File.OpenText (fileName);
		for (int i = 0; i < levelAmount; i++) {
			LevelDB [i] = int.Parse (reader.ReadLine ());
			SubLevelDB [i] = int.Parse (reader.ReadLine ());
			StarDB [i] = int.Parse (reader.ReadLine ());
			TimeLevelDB [i] = int.Parse (reader.ReadLine ());
			CoinsDB [i] = int.Parse (reader.ReadLine ());
			GemsDB [i] = int.Parse (reader.ReadLine ());
			Debug.Log ("level:" + LevelDB [i] + "  sublevel:" + SubLevelDB [i] + " star:" + StarDB [i] + " time:" + TimeLevelDB [i] + " coins:" + CoinsDB [i] + " gems:" + GemsDB [i]);
		}
		reader.Close ();
	}


	void double_mover_fixer(bool x , bool y , string tile_name, bool miinus)
		
	{
		
		int x_axix = tile_x_index (tile_name);
		int y_axix = tile_y_index (tile_name);
		
		int double_x;
		int double_y;
		
		Debug.Log("x_axixe= "+x_axix+" y_axixe= "+y_axix + " x mover = "+x +" y mover = "+y );
		
		if ( x  )
		{		
//			Debug.Log ("num_of_tile : " + num_of_tile);
			
			if ( miinus )
			{
				double_x = x_axix-1 ;
			}
			
			else // negative movement
			{
				double_x = x_axix+1 ;
			}
			
			Debug.Log("double_x= "+double_x+" level1_floor_status [double_x, y_axix]= "+level1_floor_status [double_x, y_axix] );
			
			
			if (level1_floor_status [double_x, y_axix] == 1) 
			{
				
				level1_floor_status [double_x, y_axix] = 0;
				piippi.GetComponent<PlayEffects> ().PlaySoundEffect (5);
				num_of_tile --;
				//	Debug.Log ("num_of_tile : "+num_of_tile);
				float sliderValue = slider.value;
				
				if (sliderValue <= 3.33f) {
					
					kerroin = 10;
				} else if (sliderValue >= 3.33f && sliderValue <= 6.66f) {
					kerroin = 5;
				} else if (sliderValue > 6.66f && sliderValue < 10f) {
					kerroin = 2;
				} else {
					kerroin = 1;					
				}
				
				
				Database.score [my_current_level] = Database.score [my_current_level] + kerroin;
				
				GameObject.Find("GameObject").GetComponent<TestInstantiate>().tileArray[double_x,y_axix].GetComponent<SpriteRenderer>().material.color =Color.Lerp(Color.grey, Color.white,1);
				
				
			} // end of x double mover 
		}		
		
		
		if ( y  )
		{		
			//				Debug.Log ("num_of_tile : " + num_of_tile);
			
			if ( miinus )
			{
				double_y = y_axix-1 ;
			}
			
			else // negative movement
			{
				double_y = y_axix+1 ;
			}
			
			
			Debug.Log(" sign = "+ miinus+ " double_y= "+double_y+" level1_floor_status [double_y, y_axix]= "+level1_floor_status [x_axix, double_y]);
			
			
			if (level1_floor_status [x_axix, double_y] == 1) 
			{
				
				level1_floor_status [x_axix, double_y] = 0;
				piippi.GetComponent<PlayEffects> ().PlaySoundEffect (5);
				num_of_tile --;
				//	Debug.Log ("num_of_tile : "+num_of_tile);
				float sliderValue = slider.value;
				
				if (sliderValue <= 3.33f) {
					
					kerroin = 10;
				} else if (sliderValue >= 3.33f && sliderValue <= 6.66f) {
					kerroin = 5;
				} else if (sliderValue > 6.66f && sliderValue < 10f) {
					kerroin = 2;
				} else {
					kerroin = 1;					
				}
				
				
				Database.score [my_current_level] = Database.score [my_current_level] + kerroin;
				
				GameObject.Find("GameObject").GetComponent<TestInstantiate>().tileArray[x_axix,double_y].GetComponent<SpriteRenderer>().material.color =Color.Lerp(Color.grey, Color.white,1);
				
				
			} // end of y double m
			
			
		}
		
		
	} // end of double mover 




	void PoUtimer (float how_long_time) {


//		float myTime += Time.deltaTime ;

		/*
		if(myTime>0) {
			myTime -= Time.deltaTime;
		}
		if(myTime<=0) {
			MouseDrag.power_celection = 0;
			MouseDragLevel2.power_celection = 0;
			
		}
		//		Debug.Log("myTime= "+myTime);
*/

}


} // end of class MouseDrag


