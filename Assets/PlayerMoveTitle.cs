using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveTitle : MonoBehaviour
{
	public float fallSpeed = 0.04f;
	[SerializeField] private float moveSpeed;
	[SerializeField] private float width;


	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		Fall();
		Move();
		transform.Rotate(new Vector3(0, 0, -2));
	}
	

	public void Fall()
	{
		var pos = transform.position;

		pos.y += fallSpeed;

		transform.position = pos;
	}

	public void Move()
	{
		var pos = transform.position;

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			pos.x -= moveSpeed;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			pos.x += moveSpeed;
		}

		if (transform.position.x <= -width - 2f)
		{
			pos.x = width - 2f - 0.1f;
		}
		if (transform.position.x >= width - 2f)
		{
			pos.x = -width - 2f + 0.1f;
		}

		transform.position = pos;
	}
}
