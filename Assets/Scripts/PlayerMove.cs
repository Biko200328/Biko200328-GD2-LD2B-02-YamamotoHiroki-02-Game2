using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
	public float fallSpeed;
	public float saveFallSpeed = 0.01f;
	[SerializeField] private float moveSpeed;
	[SerializeField] private float width;

	[SerializeField] private float addSpeed;
	public int lv;

	[SerializeField] private bool isFever;

	public bool isRise;
	[SerializeField] private float addRiseSpeed;

	// Start is called before the first frame update
	void Start()
	{
		isFever = false;
	}

	// Update is called once per frame
	void Update()
	{
		Move();
		Fall();

		if(isRise == true)
		{
			fallSpeed += addRiseSpeed;
			if(fallSpeed >= saveFallSpeed)
			{
				fallSpeed = saveFallSpeed;
			}
		}
		else
		{
			fallSpeed -= addRiseSpeed;
			if (fallSpeed <= -saveFallSpeed)
			{
				fallSpeed = -saveFallSpeed;
			}
		}
	}

	//自動で落ちる
	public void Fall()
	{
		var pos = transform.position;

		pos.y += fallSpeed;

		transform.position = pos;
	}

	//横移動
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
		if(lv < 5)
		{
			lv++;
			saveFallSpeed += addSpeed;
		}

		//lv5以上でフィーバー
		if(lv >= 4)
		{
			isFever = true;
		}
	}
}
