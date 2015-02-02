using UnityEngine;
using System.Collections;

public class ObstacleController : MonoBehaviour {

	public float speed;

	private int scoreValue = 1;

	private GameObject gameManager;
	private GameManager gameManagerScript;

	void Start()
	{
		gameManager = GameObject.Find("Game Manager");
		gameManagerScript = gameManager.GetComponent<GameManager>();

		speed = gameManagerScript.easySpeed;
	}

	void Update()
	{
		this.transform.Translate((Vector3.left) * speed * Time.deltaTime);
	}

	void OnBecameInvisible()
	{
		Destroy(this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D trigger)
	{
		if(trigger.transform.tag == "Player")
		{
			Debug.Log("Score + 1");
			gameManagerScript.AddScore(scoreValue);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.transform.tag == "Player")
		{
			StopAllCoroutines();
			Time.timeScale = 0;
			//Menu
		}
	}
}