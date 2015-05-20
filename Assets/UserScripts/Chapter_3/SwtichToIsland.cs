using UnityEngine;
using System.Collections;

public class SwtichToIsland : MonoBehaviour {

	GameObject ovrController;

	// Use this for initialization
	void Start () {
		ovrController = GameObject.Find("OVRPlayerController");
	}
	
	// Update is called once per frame
	void Update () {
		if(ovrController.transform.position.y > myParameters.darknessAreaHeight){
			Application.LoadLevel(3);
		}
	}
}
