using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

	public TextMeshProUGUI scoreText_player1;
	public TextMeshProUGUI scoreText_player2;
	public TextMeshProUGUI finalscoreText_player1;
	public TextMeshProUGUI finalscoreText_player2;
	// public Text score_player1;
	// public Text score_player2;
	GameObject root;
	GameObject[] player1s;
	GameObject[] player2s;
	GameObject[] children1;
	GameObject[] children2;
	float totalDistance_player1;
	float averageDistance_player1;
	float totalDistance_player2;
	float averageDistance_player2;
	public int scale;
	public GameObject winner1;
	public GameObject winner2;
	public GameObject endgame;

	public void score_calculator(int player)
	{
		root = GameObject.FindGameObjectWithTag("Root");
		if (player == 1)
		{
			totalDistance_player1 = 0f;
			player1s = GameObject.FindGameObjectsWithTag("Player1");
			foreach (GameObject player1 in player1s)
			{
				totalDistance_player1 += Vector3.Distance(root.transform.position, player1.transform.position);
			}
			children1 = GameObject.FindGameObjectsWithTag("Children1");
			foreach (GameObject child1 in children1)
			{
				totalDistance_player1 += Vector3.Distance(root.transform.position, child1.transform.position);
			}
			averageDistance_player1 = totalDistance_player1 / (player1s.Length + children1.Length) * scale;
			scoreText_player1.text = averageDistance_player1.ToString("0");
		}
		if (player == 2)
		{
			totalDistance_player2 = 0f;
			player2s = GameObject.FindGameObjectsWithTag("Player2");
			foreach (GameObject player2 in player2s)
			{
				totalDistance_player2 += Vector3.Distance(root.transform.position, player2.transform.position);
			}
			children2 = GameObject.FindGameObjectsWithTag("Children2");
			foreach (GameObject child2 in children2)
			{
				totalDistance_player2 += Vector3.Distance(root.transform.position, child2.transform.position);
			}
			averageDistance_player2 = totalDistance_player2 / (player2s.Length + children2.Length) * scale;
			scoreText_player2.text = averageDistance_player2.ToString("0");

		}
	}

	public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void EndGame()
	{
		endgame.SetActive(true);

		if (averageDistance_player1 <= averageDistance_player2)
			winner1.gameObject.SetActive(true);
		else
			winner2.gameObject.SetActive(true);
		finalscoreText_player1.text = averageDistance_player1.ToString("0");
		finalscoreText_player2.text = averageDistance_player2.ToString("0");
	}

	public void Restart()
	{
		endgame.SetActive(false);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
