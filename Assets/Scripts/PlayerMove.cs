using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
	[SerializeField] private float fallSpeed;
	[SerializeField] private float moveSpeed;
	[SerializeField] private float width;

	[SerializeField] private bool isLvUp;

	// Start is called before the first frame update
	void Start()
	{
		isLvUp = false;
	}

	// Update is called once per frame
	void Update()
	{
		Move();
		Fall();
	}

	//Ž©“®‚Å—Ž‚¿‚é
	public void Fall()
	{
		var pos = transform.position;

		pos.y -= fallSpeed;

		transform.position = pos;
	}

	//‰¡ˆÚ“®
	public void Move()
	{
		var pos = transform.position;

		if(Input.GetKey(KeyCode.LeftArrow))
		{
			pos.x -= moveSpeed;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			pos.x += moveSpeed;
		}

		if(transform.position.x <= -width)
		{
			pos.x = width - 0.1f;
		}
		if (transform.position.x >= width)
		{
			pos.x = -width + 0.1f;
		}

		transform.position = pos;
	}

	public void LvUp()
	{
		
	}
}
