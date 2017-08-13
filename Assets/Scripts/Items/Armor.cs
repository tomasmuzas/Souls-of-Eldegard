using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Item {
	[SerializeField]
	private int resistance;

	public int GetResistance(){
		return resistance;
	}

	public void SetResistance(int newResistance){
		this.resistance = newResistance;
	}
}
