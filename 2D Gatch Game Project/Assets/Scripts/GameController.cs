using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public Camera cam;
	public GameObject ball;
	public float timeLeft;
	public Text timerText;
	public GameObject gameOvertext;
	public GameObject restartButton;
	public GameObject splashScreen;
	public GameObject startButton;
	private float maxWidth;

	void Start ()
	{
		if(cam == null)
		{
			cam = Camera.main;
		}
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float ballWidth = ball.GetComponent<Renderer>().bounds.extents.x;
		maxWidth = targetWidth.x - ballWidth;
		UpdateText();
	}

	void FixedUpdate()
	{
		timeLeft -= Time.deltaTime;
		if(timeLeft < 0)
		{
			timeLeft = 0;
		}
		UpdateText();
	}

	public void StartGame()
	{
		splashScreen.SetActive(false);
		startButton.SetActive(false);
		StartCoroutine (Spawn());
	}
	IEnumerator Spawn()
	{
		yield return new WaitForSeconds(2.0f);
		while(timeLeft > 0)
		{
			Vector3 spawnPosition = new Vector3(Random.Range(-maxWidth, maxWidth), transform.position.y, 0.0f);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate(ball, spawnPosition, spawnRotation);
			yield return new WaitForSeconds(Random.Range(1.0f, 2.0f)); //wait betwee 1-2 seconds and do the loop again
		}
		yield return new WaitForSeconds(2.0f);
		gameOvertext.SetActive(true);
		yield return new WaitForSeconds(2.0f);
		restartButton.SetActive(true);
	}

	void UpdateText()
	{
		timerText.text = "Time Left:\n" + Mathf.RoundToInt(timeLeft);
	}
}
