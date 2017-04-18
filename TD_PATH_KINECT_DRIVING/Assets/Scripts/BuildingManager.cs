using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour {

    public GameObject selectedTower;
	public Text selectedTowerText;

	// Use this for initialization
	void Start () {
		selectedTowerText.text = selectedTower.name;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectTowrType(GameObject Prefab)
    {
        selectedTower = Prefab;
		selectedTowerText.text = selectedTower.name;
    }
}
