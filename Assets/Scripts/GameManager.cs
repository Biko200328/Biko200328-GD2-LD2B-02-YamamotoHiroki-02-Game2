using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	Transform lv1;
	Transform lv2;
	Transform lv3;
	Transform lv4;
	Transform lv5;

	PlayerMove playerMove;

	public float stageSize = 36.0f;

	public bool isRise = false;

	public bool isClear = false;

	private float timer = 0;
	private bool isF;
	public float flashingTime = 1;

	// Start is called before the first frame update
	void Start()
	{
		Screen.SetResolution(1024, 864, false);
		Application.targetFrameRate = 60;

		//êeÇíTÇ∑
		GameObject canvas = GameObject.Find("Canvas");

		lv1 = canvas.transform.Find("lv1");
		lv2 = canvas.transform.Find("lv2");
		lv3 = canvas.transform.Find("lv3");
		lv4 = canvas.transform.Find("lv4");
		lv5 = canvas.transform.Find("lv5");

		GameObject player = GameObject.Find("Player");
		playerMove = player.GetComponent<PlayerMove>();
	}

	// Update is called once per frame
	void Update()
	{
		switch (playerMove.lv)
		{
			case 0:
				lv1.gameObject.SetActive(false);
				lv2.gameObject.SetActive(false);
				lv3.gameObject.SetActive(false);
				lv4.gameObject.SetActive(false);
				lv5.gameObject.SetActive(false);
				break;
			case 1:
				lv1.gameObject.SetActive(true);
				break;
			case 2:
				lv2.gameObject.SetActive(true);
				break;
			case 3:
				lv3.gameObject.SetActive(true);
				break;
			case 4:
				lv4.gameObject.SetActive(true);
				break;
			case 5:
				lv5.gameObject.SetActive(true);
				break;
		}

		if (playerMove.isFever)
		{
			timer += Time.deltaTime;
			if (timer >= flashingTime)
			{
				isF = !isF;
				timer = 0;
			}

			if(isF)
			{
				lv1.gameObject.SetActive(true);
				lv2.gameObject.SetActive(true);
				lv3.gameObject.SetActive(true);
				lv4.gameObject.SetActive(true);
				lv5.gameObject.SetActive(true);
			}
			else
			{
				lv1.gameObject.SetActive(false);
				lv2.gameObject.SetActive(false);
				lv3.gameObject.SetActive(false);
				lv4.gameObject.SetActive(false);
				lv5.gameObject.SetActive(false);
			}
		}
	}
}
