using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManagerTitle : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		Screen.SetResolution(1024, 864, false);
		Application.targetFrameRate = 60;
	}

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(new Vector3(0, 0, -2));
	}
}