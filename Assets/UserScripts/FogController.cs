﻿using UnityEngine;
using System.Collections;

public class FogController : MonoBehaviour {


	float original_fog_density;
	public float fade_rate;

	// Use this for initialization
	void Start () {
		original_fog_density = RenderSettings.fogDensity;	
	}
	
	// Update is called once per frame
	void Update () {
		float temp_density = RenderSettings.fogDensity;
		if (BreathDataProcesser.isInhaling) {
			temp_density += fade_rate * Time.deltaTime;
		} else {
			if(temp_density > original_fog_density){
				temp_density -= fade_rate * Time.deltaTime;
				//gradually reduce fog density to original value...
			}
		}
		RenderSettings.fogDensity = temp_density;
	}
}
