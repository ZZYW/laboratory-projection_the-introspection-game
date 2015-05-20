using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InstantiatingPrefabs : MonoBehaviour {

	Object[] allPrefabs;
	public List<GameObject> allLoaded;
	public List<Vector3> rotateSpeed;

	void Start () {
		allLoaded = new List<GameObject>();
		rotateSpeed = new List<Vector3>();

		allPrefabs = Resources.LoadAll("chaptertwo/",typeof(GameObject));

		for(int i=0;i<myParameters.realWorldObjectNumber;i++){
			Vector3 randomPos = new Vector3(Random.Range(-myParameters.xRange,myParameters.xRange), 
			                                Random.Range(-myParameters.realWorldObjectsHeight,0), 
			                                Random.Range(-myParameters.zRange,myParameters.zRange));
			GameObject newObj = (GameObject)Instantiate(allPrefabs[Random.Range(0,allPrefabs.Length-1)], randomPos , Random.rotation);
			newObj.transform.parent = GameObject.Find("realWorldObjects").transform;
			allLoaded.Add(newObj);
			rotateSpeed.Add(new Vector3(Random.Range(-0.1f,0.1f),Random.Range(-0.1f,0.1f),Random.Range(-0.1f,0.1f)));
		}

		for(int i=0;i<myParameters.abstractObjectNumber;i++){
			float abstractStartHeight = -myParameters.realWorldObjectsHeight + myParameters.blendingLayerHeight;

			Vector3 randomPos = new Vector3(Random.Range(-myParameters.xRange,myParameters.xRange),
			                                Random.Range(abstractStartHeight,abstractStartHeight-myParameters.abstractObjectHeight),
			                                Random.Range(-myParameters.zRange,myParameters.zRange));

			GameObject aCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			aCube.transform.position = randomPos;
			float randomScale = Random.Range(myParameters.abstractObjectRange.x,myParameters.abstractObjectRange.y);
			Vector3 cubeScale = new Vector3(randomScale,randomScale,randomScale);
			aCube.transform.localScale = cubeScale;
			aCube.transform.parent = GameObject.Find("abstractObjects").transform;
			allLoaded.Add(aCube);
			rotateSpeed.Add(new Vector3(Random.Range(-0.1f,0.1f),Random.Range(-0.1f,0.1f),Random.Range(-0.1f,0.1f)));
		}


		allLoaded.Add(GameObject.Find("LaboratoryGallery_prefab"));
		rotateSpeed.Add(new Vector3(Random.Range(-0.1f,0.1f),Random.Range(-0.1f,0.1f),Random.Range(-0.1f,0.1f)));

		
	}
	
	// Update is called once per frame
	void Update () {
	
		for(int i=0;i<allLoaded.Count-1;i++){
			allLoaded[i].transform.RotateAround(allLoaded[i].transform.position,rotateSpeed[i],Time.deltaTime * myParameters.generatedObjectRotatationSpeed);
		}


	}


	void instantiating(){
	}
}
