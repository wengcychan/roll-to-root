using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate_parent : MonoBehaviour
{
	public GameObject player1;
	public GameObject user_input;
	public GameObject root;
	public GameObject current_player;
	int i;
	public int nbr_parent;
	bool parent_generated;
	public bool all_parent_generated;
	public GameObject[] player_parents;
	bool all_stop;
	public GameObject ball1;
	public GameObject ball2;
	public GameObject ball3;

    // Start is called before the first frame update
    void Start()
    {
		i = 0;
		parent_generated = false;
		all_parent_generated = false;
		all_stop = true;
    }

    // Update is called once per frame
    void Update()
    {
		if (i < nbr_parent)
		{
			if (parent_generated == false && (Mathf.Abs(root.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(root.GetComponent<Rigidbody2D>().velocity.y)) < 0.01 && check_stop() == true)
			{
				if (i != 0)
				{
					FindObjectOfType<GameManager>().score_calculator(1);
					FindObjectOfType<GameManager>().score_calculator(2);
				}
				current_player = Instantiate(player1, transform.position, Quaternion.identity);
				if (i == 0)
					ball3.SetActive(false);
				else if (i == 1)
					ball2.SetActive(false);
				else
					ball1.SetActive(false);
				user_input.GetComponent<user_input>().input_active = true;
				parent_generated = true;
			}
			if (parent_generated == true)
			{
				if (user_input.GetComponent<user_input>().input_chosen == true)
				{
					current_player.GetComponent<add_force>().enabled = true;
					if (i < nbr_parent - 1)
					{
						user_input.GetComponent<user_input>().input_chosen = false;
					}
					if ((Mathf.Abs(current_player.GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(current_player.GetComponent<Rigidbody2D>().velocity.y)) < 0.01)
					{		
						parent_generated = false;
						GetComponent<parent2>().enabled = true;
						GetComponent<generate_parent>().enabled = false;
					}
					i++;
				}
			}
		}
		if (i == nbr_parent)
		{
			user_input.GetComponent<user_input>().input_chosen = false;
			GetComponent<generate_parent>().enabled = false;
		}
    }

	bool check_stop()
	{
		all_stop = true;

		player_parents = GameObject.FindGameObjectsWithTag("Player1");
		foreach (GameObject parent in player_parents)
		{
			if (!((Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.x) < 0.01) && Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.y) < 0.01))
			{
				all_stop = false;
			}
		}
		
		player_parents = GameObject.FindGameObjectsWithTag("Player2");
		foreach (GameObject parent in player_parents)
		{
			if (!((Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.x) < 0.01) && Mathf.Abs(parent.GetComponent<Rigidbody2D>().velocity.y) < 0.01))
			{
				all_stop = false;
			}
		}
		return all_stop;
	}
}
