using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManagerTitle : MonoBehaviour
{
	SceneController sceneController;
	// Start is called before the first frame update
	void Start()
	{
		Screen.SetResolution(1024, 864, false);
		Application.targetFrameRate = 60;

		GameObject camera = GameObject.Find("Main Camera");
		sceneController = camera.gameObject.GetComponent<SceneController>();
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown("space"))
		{
			sceneController.sceneChange("GameScene");
		}
	}
}
