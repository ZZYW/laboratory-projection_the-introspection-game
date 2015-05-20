using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Uniduino;

public class sensorInput : MonoBehaviour {



	private static sensorInput singleton = null;

	public static sensorInput getSingleton(){
		return singleton;
	}

	public Arduino arduino;

	//pins
	public int breathSensorPin = 1;
	public int pulseBeatPin = 0;

	//rawValues
	public float rawHeartBeatValue = 0.0f; 
	public float rawBreathingValue = 0.0f;


	void Start () {
		singleton = this;
		arduino = Arduino.global;
		arduino.Setup(ConfigurePins);
	}

	void ConfigurePins( )
	{
		arduino.pinMode(0, PinMode.ANALOG);
		arduino.pinMode(1, PinMode.ANALOG);
		arduino.reportAnalog(0,1); //report status
		arduino.reportAnalog(1,1); //report statu
	}
	
	// Update is called once per frame
	void Update () {
		rawHeartBeatValue = arduino.analogRead(pulseBeatPin);
		rawBreathingValue = arduino.analogRead(breathSensorPin);
	}
}
