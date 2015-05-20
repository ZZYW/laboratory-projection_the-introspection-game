using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {


	float fadeRate;
	float currentFogDensity;

	// Use this for initialization
	void Start () {
		fadeRate = 0.02f;
		currentFogDensity = 0.4f;
		RenderSettings.fogDensity = currentFogDensity;
	}
	
	// Update is called once per frame
	void Update () {

		if(currentFogDensity > myParameters.c2NormalFogDensity){
			currentFogDensity -= fadeRate * Time.deltaTime;
			RenderSettings.fogDensity = currentFogDensity;
		}


	}
}
