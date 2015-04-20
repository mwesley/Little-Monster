using UnityEngine;
using System.Collections;

public class CityEnergy : MonoBehaviour {

	public CityGUI gui;
	public float energy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void Heal(float ene)
	{
		energy += ene;
		if(energy > 100)
		{
			energy = 100f;
		}
		gui.UpdateEnergy (energy);
	}
	public void TakeHit(float dmg)
	{
		if(energy > dmg)
		{
			energy -= dmg;
			gui.UpdateEnergy(energy);
		}
		else
		{
			energy = 0;
			gui.UpdateEnergy(energy);
			GameOver();
		}
	}
	public void GameOver()
	{
		Debug.Log ("You Died!");
	}
}
