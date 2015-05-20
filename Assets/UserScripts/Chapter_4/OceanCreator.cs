using UnityEngine;
using System.Collections;

public class OceanCreator : MonoBehaviour {

	GameObject islandTerrain;

	void Start () {
		islandTerrain = GameObject.Find("IslandTerrain");
//		Debug.Log(islandTerrain.renderer.bounds.size);
	}
	
	void Update () {

	}
}
