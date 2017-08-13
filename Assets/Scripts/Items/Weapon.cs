using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item {
	[SerializeField]
	private int damageMin;
	[SerializeField]
	private int damageMax;

	public int GetDamageMin(){
		return damageMin;
	}

	public int GetDamageMax(){
		return damageMax;
	}

	public void SetDamageMin(int newDamageMin){
		this.damageMin = newDamageMin;
	}

	public void SetDamageMax(int newDamageMax){
		this.damageMax = newDamageMax;
	}
}
