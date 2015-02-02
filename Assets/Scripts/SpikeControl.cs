using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpikeControl : MonoBehaviour {

	GameObject[] spikes;
	List<Vector2> spikePositions;
	int spikeNum, currSpikeNum;
	bool canRespawn;

	//Initialization
	void Start () {
		spikes = GameObject.FindGameObjectsWithTag ("Spike");
		spikeNum = spikes.Length;
		currSpikeNum = spikeNum;
		spikePositions = new List<Vector2>();
		canRespawn = false;
		foreach (GameObject spike in spikes) {
			spikePositions.Add(spike.transform.position);
		}
	}

	public void respawnSpikes() {
		for (int i = 0; i < spikeNum; i++) {
			Instantiate(Resources.Load("Spike"), spikePositions[i], Quaternion.identity);
		}
		canRespawn = false;
	}

	public void removeSpike() {
		currSpikeNum--;
		Debug.Log (currSpikeNum);
		if (currSpikeNum <= 0) {
			canRespawn = true;
		}
	}

	public bool getCanRespawn() {
		return canRespawn;
	}
}