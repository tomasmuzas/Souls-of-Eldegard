using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	[SerializeField]
	private Inventory inventory;
	private Player instance;
	private int HPCurrent;
	private int HPMax;
	private int MPCurrent;
	private int MPMax;
	private Weapon weapon;
	private Armor armor;
	private Armor shoes;
	private Armor helm;
	private int baseDamageMin;
	private int baseDamageMax;
	private int regeneration;


	private Player(){
		inventory = new Inventory ();
		weapon = null;
		armor = shoes = helm = null;

	}

	void Start(){
		HPCurrent = HPMax = PlayerPrefs.GetInt ("PlayerHP", DEFAULTS.PlayerInitialHP);
		MPCurrent = MPMax = PlayerPrefs.GetInt ("PlayerMP", DEFAULTS.PlayerInitialMP);
		baseDamageMin = PlayerPrefs.GetInt ("PlayerBaseDamageMin",DEFAULTS.PlayerInitialDamageMin);
		baseDamageMax = PlayerPrefs.GetInt ("PlayerBaseDamageMax",DEFAULTS.PlayerInitialDamageMax);
		regeneration = PlayerPrefs.GetInt ("PlayerRegeneration",DEFAULTS.PlayerInitialRegeneration);
	}

	public Player GetInstance(){
		if (instance == null) {
			instance = new Player ();
		}
		return instance;
	}

	public int GetDamageMin(){
		return baseDamageMin + weapon.GetDamageMin ();
	}

	public int GetDamageMax(){
		return baseDamageMax + weapon.GetDamageMax ();
	}

	public Inventory GetInventory(){
		return inventory;
	}
}
