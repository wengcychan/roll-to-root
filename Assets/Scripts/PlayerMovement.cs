using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://gamedevbeginner.com/make-an-object-follow-the-mouse-in-unity-in-2d/ = arrow movement


public class PlayerMovement : MonoBehaviour
{
	// public float moveSpeed = 5f;

	public Rigidbody2D rb;

 	public Camera cam;
	Vector2 movement;
	Vector2 mousePosition;
	public GameObject arrow;
	void Update()
	{
		// movement.x = Input.GetAxisRaw("Horizontal");
		// movement.y = Input.GetAxisRaw("Vertical");
		mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
	}

	float Ballangle()
	{
		// rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
		Vector2 lookDir = mousePosition - rb.position;
		float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg + 90f;
		rb.rotation = angle;
		return(angle);
	}

	void FixedUpdate()
	{
		// Debug.Log(Ballangle());
		float arrowAngle= Ballangle();
		arrow.transform.eulerAngles = new Vector3 (arrow.transform.position.x, arrow.transform.position.y, arrowAngle);
	}
}

