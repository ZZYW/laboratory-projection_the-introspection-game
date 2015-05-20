using UnityEngine;
using System.Collections;

public static class myParameters {

	//CHAPTER ONE _ THE START
	public static int c1MinimalStayingTime = 20;
	public static int c1FadeTime = 4;

	//CHAPTER TWO _ THE FRAGMENTS
	public static Vector3 OVRControllerinitPosition = new Vector3(0.0f,20.0f,0.0f);

	public static float c2NormalFogDensity = 0.006f;
	public static int c2FadeInTime = 4;
	public static int c2fadeInTime = 3;
	
	public static int xRange = 70;
	public static int zRange = 70;
	public static int realWorldObjectsHeight = 300;
	public static int abstractObjectHeight = 300;
	public static int blendingLayerHeight = 100;
	public static int sceneCutHeight = myParameters.realWorldObjectsHeight + myParameters.abstractObjectHeight - myParameters.blendingLayerHeight + 100;

	public static int realWorldObjectNumber = 100;
	public static int abstractObjectNumber = 100;

	public static Vector2 abstractObjectRange = new Vector2(2.0f,20.0f);

	public static float generatedObjectRotatationSpeed = 2.5f;



	//CHAPTER THREE _ THE DARKNESS
	public static int darknessAreaHeight = 400;


	//CHAPTER FOUR _ THE ISLAND


	//CHAPTER FIVE _ THE END


}