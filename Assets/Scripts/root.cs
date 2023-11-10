using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class root : MonoBehaviour
{
	public bool root_shoot;
	public GameObject user_input;
	public GameObject start_point;

    // Start is called before the first frame update
    void Start()
    {
		GetComponent<add_force>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (root_shoot == false)
		{
			if (user_input.GetComponent<user_input>().input_chosen == true)
			{
				GetComponent<add_force>().enabled = true;
				user_input.GetComponent<user_input>().input_chosen = false;
				root_shoot = true;
				if ((Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) + Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y)) < 0.01)
				{
					start_point.GetComponent<generate_parent>().enabled = true;
				}
			}
		}
    }
}
