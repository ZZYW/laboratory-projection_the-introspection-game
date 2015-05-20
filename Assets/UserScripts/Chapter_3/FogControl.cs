using UnityEngine;
using System.Collections;

public class FogControl : MonoBehaviour {

	GameObject ovrController;

	// Use this for initialization
	void Start () {
		ovrController = GameObject.Find("OVRPlayerController");
	}
	
	// Update is called once per frame
	void Update () {
		float colorP = 	myMethods.Map(ovrController.transform.position.y,0,-myParameters.darknessAreaHeight,0,1);
		Color myFogColor = new Color(colorP,colorP,colorP);
		RenderSettings.fogColor = myFogColor;
	}
}
