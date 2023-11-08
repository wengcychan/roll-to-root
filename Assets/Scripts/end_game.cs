using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end_game : MonoBehaviour
{
	bool all_stop;
	public GameObject[] children1;
	public GameObject[] children2;
	public GameObject[] parent1s;
	public GameObject[] parent2s;
    public GameObject child;

    // Start is called before the first frame update
    void Start()
    {
		all_stop = true;
        child = GameObject.FindGameObjectWithTag("Children2");
    }

    void Update()
    {
		FindObjectOfType<GameManager>().score_calculator(1);
		FindObjectOfType<GameManager>().score_calculator(2);

        if ((Mathf.Abs(child.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(child.GetComponent<Rigidbody2D>().velocity.y)) < 0.01)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    bool check_stop()
	{
		all_stop = true;

		parent1s = GameObject.FindGameObjectsWithTag("Player1");
		parent2s = GameObject.FindGameObjectsWithTag("Player2");

		foreach (GameObject parent in parent1s)
		{
			if (!((Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.x) < 0.01) && Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.y) < 0.01))
			{
				all_stop = false;
			}
		}
		
		foreach (GameObject parent in parent2s)
		{
			if (!((Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.x) < 0.01) && Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.y) < 0.01))
			{
				all_stop = false;
			}
		}

		children1 = GameObject.FindGameObjectsWithTag("Children1");
		children2 = GameObject.FindGameObjectsWithTag("Children2");

		foreach (GameObject child1 in children1)
		{
			if (!((Mathf.Abs(child1.GetComponent<Rigidbody2D>().velocity.x) < 0.01) && Mathf.Abs(child1.GetComponent<Rigidbody2D>().velocity.y) < 0.01))
			{
				all_stop = false;
			}
		}

		foreach (GameObject child2 in children1)
		{
			if (!((Mathf.Abs(child2.GetComponent<Rigidbody2D>().velocity.x) < 0.01) && Mathf.Abs(child2.GetComponent<Rigidbody2D>().velocity.y) < 0.01))
			{
				all_stop = false;
			}
		}
		return all_stop;
	}			
}
