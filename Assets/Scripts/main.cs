using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class main : MonoBehaviour
{

	public Canvas start_menu;
	public Canvas manual;

	public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void Open_Manual()
	{
		start_menu.gameObject.SetActive(false);
		manual.gameObject.SetActive(true);
	}

	public void Close_Manual()
	{
		start_menu.gameObject.SetActive(true);
		manual.gameObject.SetActive(false);
	}
}
