using UnityEngine;
using System.Collections;

public class SceneFade: MonoBehaviour {
	
	float initFogDensity;
	Color initSphereColor;
	public bool printOutDensityAndAlpha = false;
	float fogFadeRate;
	float sphereFadeRate;
	float lightFadeRate = 0.5f;
	float targetFogDensity = 0.8f, targetSphereAlpha = 1.0f;
	float coroutineGapTime = 0.02f;
	float fogDensity;
	Color hollowSphereColor;
	public GameObject hollowSphere;
	bool sceneEnding = false;


	void OnEnable(){
		BreathDataProcesser.deepBreathHappened += kickOffFade;
	}

	// Use this for initialization
	void Start () {
		fogDensity = RenderSettings.fogDensity;
		initFogDensity = fogDensity;
		hollowSphereColor = hollowSphere.renderer.material.color;
		initSphereColor = hollowSphereColor;
		fogFadeRate = (targetFogDensity - fogDensity) / (myParameters.c1FadeTime/coroutineGapTime);
		sphereFadeRate = (targetSphereAlpha - hollowSphereColor.a) / (myParameters.c1FadeTime/coroutineGapTime);
	}
	
	// Update is called once per frame
	void Update () {
		if(!sceneEnding){
			if(BreathDataProcesser.isInhaling){
				fogDensity += fogFadeRate * lightFadeRate;
				RenderSettings.fogDensity = fogDensity;

				hollowSphereColor.a += sphereFadeRate * lightFadeRate;
				hollowSphere.renderer.material.color = hollowSphereColor;
			}else{
				if(fogDensity > initFogDensity){
					fogDensity -= fogFadeRate * lightFadeRate;
					RenderSettings.fogDensity = fogDensity;
				}
				if(hollowSphereColor.a  > initSphereColor.a){
					hollowSphereColor.a -= sphereFadeRate * lightFadeRate;
					hollowSphere.renderer.material.color = hollowSphereColor;
				}
			}
		}

		if(printOutDensityAndAlpha)Debug.Log("Fog Density: "+ fogDensity+"Alpha: "+hollowSphereColor.a);

		if(fogDensity >= targetFogDensity && hollowSphereColor.a >= targetSphereAlpha){

			Application.LoadLevel(1);
		}
	}

	void kickOffFade(){
		if(minimalTimeControl.c1ReadyToSwtich){
			StartCoroutine(finalFadeFog());
			StartCoroutine(finalFadeHollowSphere());
			sceneEnding = true;
		}else{
			Debug.LogWarning("Detected a deep breath, But minimal Staying Time hasn't been fulfilled.");
		}
	}


	IEnumerator finalFadeFog() {
		while(fogDensity < targetFogDensity){
			fogDensity += fogFadeRate;
			RenderSettings.fogDensity = fogDensity;
			yield return new WaitForSeconds(coroutineGapTime);
		}
	}

	IEnumerator finalFadeHollowSphere() {
		while(hollowSphereColor.a < targetSphereAlpha){
			hollowSphereColor.a += sphereFadeRate;
			hollowSphere.renderer.material.color = hollowSphereColor;
			yield return new WaitForSeconds(coroutineGapTime);
		}
	}



}
