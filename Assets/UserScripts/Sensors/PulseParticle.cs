using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PulseParticle : MonoBehaviour {
	
	
	public List<float> beatTimeStamp;
	public List<float> BPMData;
	public float rawData;

	private float temp;
	public float BPM;

	private float waitTime;

	// Use this for initialization
	void Start () {
		beatTimeStamp = new List<float>();
		BPMData = new List<float>();


		temp = 0;
		BPM = 0;

		waitTime = 10.0f;
	}

	// Update is called once per frame
	void Update () {
		if (Time.time > waitTime) {
			getUniqueBeat ();	
		}

		if(beatTimeStamp.Count>21){
			beatTimeStamp.RemoveAt(0);
//			calcBPM ();

		}

		if (BPMData.Count > 500) {
			BPMData.RemoveAt(0);		
		}
	}

	private void getUniqueBeat(){
		rawData = sensorInput.getSingleton().rawHeartBeatValue;			
		if (temp < 30) {
			if(rawData > 400){
				beatTimeStamp.Add (Time.time);
				this.GetComponent<ParticleSystem> ().emissionRate = 2000;
			}else{
				this.GetComponent<ParticleSystem> ().emissionRate = 0;
			}
		}
		temp = rawData; 
	}

	private void calcBPM(){
		float beatDuration = (beatTimeStamp [beatTimeStamp.Count - 1] - beatTimeStamp [0]) / (beatTimeStamp.Count - 1);
		BPM = 60.0f/beatDuration;
		BPMData.Add (BPM);
//		SensorProcessingMethods.drawCurves(BPMData);
	}

	
}
