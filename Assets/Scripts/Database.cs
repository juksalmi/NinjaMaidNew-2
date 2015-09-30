using UnityEngine;
using System.Collections;

public class Database : MonoBehaviour {
	
	
	
	public static int[] score = new int [6] {0,0,0,0,0,0}; // Each level own score 
	public static int[,] top_ten_score_each_level = new int [10,10]; // Each level top ten  score hall of fame 6 = level , 10 = score 
	public static string [,] top_ten_name_each_level = new string [10,10]; // Each level top ten  score hall of fame 6 = level , 10 = score 
	
	public static int shoes = 3;
	public static int gloves = 3;
	public static int tea = 3;
	
	/*
	public class Top_ten_level_ranking    {

		public static int score_rank;
		public static string name_of_player;

		public Top_ten_level_ranking (int score_rank,string name_of_player)
		{
			this.score_rank = score_rank;
			this.name_of_player = name_of_player;
		}

	}

	public static Top_ten_level_ranking[,] top_ten_each_level = new Top_ten_level_ranking [6,10]; // Each level top ten  score hall of fame 6 = level , 10 = score 

*/
	void Awake()
	{
		DontDestroyOnLoad(this);
	}
}
