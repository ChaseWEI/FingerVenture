using UnityEngine;
using System.Collections;

public class Variable : MonoBehaviour {
	public static readonly int gameNum = 6;
	public static int [] gameArray = new int[gameNum] ;
	public static int stageCount;
	public static bool isPass;
	public static bool isTimeToNext;
	public static int score;
	public static int level;
	public static int life;


	void Start (){
		stageCount = 0;
		isPass = false;
		isTimeToNext = false;
		level = 1;
		life = 3;
	}
}
