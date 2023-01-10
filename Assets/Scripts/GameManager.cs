using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	private bool isGameOver = false;
	private bool isGameEnd = false;

	private float timer = 0;
	private bool isF;
	public float flashingTime = 1;

	[SerializeField] private float gameOverTime = 120.0f;

	public GameObject Clear;
	public GameObject Failure;
	public Text text;

	float endtTimer = 0;

	SceneController sceneController;

	[SerializeField] AudioSource boostSE;
	[SerializeField] AudioSource upSE;
	[SerializeField] AudioSource IdeaSE;


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

		GameObject camera = GameObject.Find("Main Camera");
		sceneController = camera.GetComponent<SceneController>();
	}

	// Update is called once per frame
	void Update()
	{
		gameOverTime -= Time.deltaTime;
		text.text = "" + gameOverTime.ToString("F");

		if(gameOverTime <= 0)
		{
			isGameOver = true;
		}

		Gauge();

		GameEnd();

		if(isGameEnd == true)
		{
			endtTimer += Time.deltaTime;
			if(endtTimer >= 5)
			{
				sceneController.sceneChange("TitleScene");
			}
		}
	}

	private void Gauge()
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

			if (isF)
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

	public void GameEnd(bool isClear)
	{
		if(isGameEnd == false)
		{
			if (isClear)
			{
				Clear.SetActive(true);
				isGameEnd = true;
			}
			else
			{
				Failure.SetActive(true);
				isGameEnd = true;
			}
		}
	}

	public void GameEnd()
	{
		if(isGameOver== true && isGameEnd == false)
		{
			Failure.SetActive(true);
			isGameEnd = true;
		}
	}

	public void BoostSound()
	{
		boostSE.Play();
	}

	public void UpSound()
	{
		upSE.Play();
	}

	public void IdeaSound()
	{
		IdeaSE.Play();
	}
}
