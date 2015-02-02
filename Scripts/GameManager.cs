using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum DifficultyEnum
{
	Easy,
	Medium,
	Hard,
	MLG
}

public class GameManager : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText;
	public Text difficultyText;
	public Slider difficultySlider;

	private int highScore;
	private int totalScore;

	//Get All the Objects
	private GameObject[] allObstacles;

	private string difficultyString = "";
	public DifficultyEnum difficulty;

	//Speeds for difficulties
	public float easySpeed = 5;
	public float mediumSpeed = 6;
	public float hardSpeed = 7.5f;
	public float mlgSpeed = 12;

	void Start()
	{
		highScore = 10;
		totalScore = 0;
	}

	void Update()
	{
		allObstacles = GameObject.FindGameObjectsWithTag("Obstacle");

		//HUD Text
		scoreText.text = "Score: " + totalScore.ToString();
		highScoreText.text = "High Score: " + highScore.ToString();
		difficultyText.text = difficulty + " Mode";

		if(totalScore >= highScore)
		{
			highScore = totalScore;

			PlayerPrefs.SetInt("High Score", highScore);
			PlayerPrefs.SetString("Difficulty", difficultyString);
		}

		//Setting the Difficulties
		if(difficulty == DifficultyEnum.Easy)
		{
			//Speed is normal speed
			foreach(GameObject obstacle in allObstacles)
			{
				obstacle.GetComponent<ObstacleController>().speed = easySpeed;
			}
			difficultyString = "Easy";
		}
		else if(difficulty == DifficultyEnum.Medium)
		{
			//Speed is a little faster
			foreach(GameObject obstacle in allObstacles)
			{
				obstacle.GetComponent<ObstacleController>().speed = mediumSpeed;
			}
			difficultyString = "Medium";
		}
		else if(difficulty == DifficultyEnum.Hard)
		{
			//Speed is fast
			foreach(GameObject obstacle in allObstacles)
			{
				obstacle.GetComponent<ObstacleController>().speed = hardSpeed;
			}
			difficultyString = "Hard";
		}
		else if(difficulty == DifficultyEnum.MLG)
		{
			//Speed is really fast. Like REALLY REALLY. Packed with Peanuts.
			foreach(GameObject obstacle in allObstacles)
			{
				obstacle.GetComponent<ObstacleController>().speed = mlgSpeed;
			}
			difficultyString = "MLG";
		}

	}

	//Add Score Functions
	public void AddScore(int score)
	{
		totalScore += score;
	}
}