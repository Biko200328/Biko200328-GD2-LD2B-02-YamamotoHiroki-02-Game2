using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
	public float fallSpeed;
	public float saveFallSpeed = 0.01f;
	float initialValue = 0;
	[SerializeField] private float moveSpeed;
	[SerializeField] private float width;

	[SerializeField] private float addSpeed;
	public int lv;

	public bool isFever;
	bool isFever2;
	public bool isFeverBoost;
	private bool isBoostTimerDown;
	private float boostTimer = 0f;

	[SerializeField] private float addRiseSpeed;

	GameManager gameManager;

	float feverCount = 0;
	[SerializeField] float feverTime = 3f;

	[SerializeField] private GameObject Graph0;
	[SerializeField] private GameObject Graph1;
	[SerializeField] private GameObject Graph2;
	[SerializeField] private GameObject Graph3;
	[SerializeField] private GameObject Graph4;
	[SerializeField] private GameObject Graph5;

	[SerializeField] Text text;
	

	// Start is called before the first frame update
	void Start()
	{
		isFever = false;
		isFeverBoost = false;
		isBoostTimerDown = false;
		GameObject managerObj = GameObject.Find("GameManager");
		gameManager = managerObj.GetComponent<GameManager>();
		initialValue = saveFallSpeed;
	}

	// Update is called once per frame
	void Update()
	{
		if (gameManager.isRise == true)
		{
			transform.Rotate(new Vector3(0, 0, 2));
		}
		else
		{
			transform.Rotate(new Vector3(0, 0, -2));
		}
		Move();
		Fall();
		//Loop();
		FeverBoost();
		GraphChange();
		isFever2 = isFever;

		if (isFever == true)
		{
			feverCount += Time.deltaTime;
			if(feverCount >= feverTime)
			{
				//フィーバー終了
				isFever = false;
				//タイマーリセット
				feverCount = 0;
				//lvを0に
				lv = 0;
				//スピードを初期値に
				saveFallSpeed = initialValue;
			}
		}

		switch (lv)
		{
			case 0:
				saveFallSpeed = initialValue;
				break;
			case 1:
				saveFallSpeed = initialValue + addSpeed;
				break;
			case 2:
				saveFallSpeed = initialValue + addSpeed * 2;
				break;
			case 3:
				saveFallSpeed = initialValue + addSpeed * 3;
				break;
			case 4:
				saveFallSpeed = initialValue + addSpeed * 4;
				break;
		}

		if (gameManager.isRise == true)
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

		text.text = "" + transform.position.y.ToString("F");
	}

	//自動で落ちる
	public void Fall()
	{
		var pos = transform.position;

		pos.y += fallSpeed;

		transform.position = pos;
	}

	//public void Loop()
	//{
	//	var pos = transform.position;

	//	if(transform.position.y <= -loopzone)
	//	{
	//		pos.y = 0;
	//	}
	//	if(transform.position.y >= 0)
	//	{
	//		pos.y = -loopzone;
	//	}

	//	transform.position = pos;
	//}

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
		if(lv < 4)
		{
			lv++;
		}
		else if(lv == 4)
		{
			lv++;
			saveFallSpeed += addSpeed;
		}

		//lv5以上でフィーバー
		if(isFever == false && lv >= 5)
		{
			isFever = true;
		}

		if(isFever == true && isFever2 == true && lv == 5)
		{
			isFeverBoost = true;
		}
	}

	public void FeverBoost()
	{
		if (isFeverBoost == true)
		{
			// フィーバー開始から時間をはかる
			boostTimer += Time.deltaTime;
			// タイマーが一以下の場合はスピードを足し続ける(加速)
			saveFallSpeed += addRiseSpeed;
			if (boostTimer >= 1.0f)
			{
				boostTimer = 1.0f;
				//一超えた場合加速を切る
				isFeverBoost = false;
			}
		}
		else
		{
			// 加速が切ってある場合
			// かつ、時間が一以上残っている(加速しきった後)状態の時
			if (boostTimer >= 1.0f)
			{
				// 減速させるフラグ
				isBoostTimerDown = true;
			}
			if (isBoostTimerDown == true)
			{
				// 減速する時間をはかる
				boostTimer -= Time.deltaTime;
				// 0以下になるまで速度を引き続ける(減速)
				saveFallSpeed -= addRiseSpeed;
				// 0以下になった時
				if (boostTimer <= 0)
				{
					// 減速させるフラグを切る
					isBoostTimerDown = false;
					// タイマーのリセット
					boostTimer = 0;
				}
			}
		}
	}

	private void GraphChange()
	{
		switch (lv)
		{
			case 0:
				Graph0.SetActive(true);
				Graph1.SetActive(false);
				Graph2.SetActive(false);
				Graph3.SetActive(false);
				Graph4.SetActive(false);
				Graph5.SetActive(false);
				break;
			case 1:
				Graph0.SetActive(false);
				Graph1.SetActive(true);
				Graph2.SetActive(false);
				Graph3.SetActive(false);
				Graph4.SetActive(false);
				Graph5.SetActive(false);
				break;
			case 2:
				Graph0.SetActive(false);
				Graph1.SetActive(false);
				Graph2.SetActive(true);
				Graph3.SetActive(false);
				Graph4.SetActive(false);
				Graph5.SetActive(false);
				break;
			case 3:
				Graph0.SetActive(false);
				Graph1.SetActive(false);
				Graph2.SetActive(false);
				Graph3.SetActive(true);
				Graph4.SetActive(false);
				Graph5.SetActive(false);
				break;
			case 4:
				Graph0.SetActive(false);
				Graph1.SetActive(false);
				Graph2.SetActive(false);
				Graph3.SetActive(false);
				Graph4.SetActive(true);
				Graph5.SetActive(false);
				break;
			case 5:
				Graph0.SetActive(false);
				Graph1.SetActive(false);
				Graph2.SetActive(false);
				Graph3.SetActive(false);
				Graph4.SetActive(false);
				Graph5.SetActive(true);
				break;
		}
	}
}
