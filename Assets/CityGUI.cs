using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CityGUI : MonoBehaviour {

	public Slider energySlider;
	public Text energyText;
	public CityEnergy energy;
	// Use this for initialization
	void Start () {
		energyText.text = "100";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void UpdateEnergy(float ene)
	{
		energySlider.value = ene;
		energyText.text = energySlider.value.ToString ();
	}
}
