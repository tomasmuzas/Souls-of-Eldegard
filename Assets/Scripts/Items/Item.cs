using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour{
	public int ID;
	public static int globalID;
	public string title;
	[SerializeField]
	private bool sellable;
	[SerializeField]
	private int cost;
	[SerializeField]
	private Bonus bonuses;
	[SerializeField]
	private Sprite sprite;
	public string description;

	void Start(){
		Item.globalID = PlayerPrefs.GetInt ("ItemID", 0);
		ID = Item.globalID;
		Item.globalID++;
		PlayerPrefs.SetInt ("ItemID", globalID);

	}

	public Item(){
		
	}

	public bool IsSellable(){
		return sellable;
	}

	public void SetSellable(bool sellable){
		this.sellable = sellable;
	}

	public int GetCost(){
		return cost;
	}

	public void SetCost(int newCost){
		this.cost = newCost;
	}

	public Bonus GetBonuses(){
		return bonuses;
	}

	public void SetBonuses(Bonus newBonuses){
		this.bonuses = newBonuses;
	}

	public Sprite GetSprite(){
		return sprite;
	}

	public void SetSprite(Sprite newSprite){
		this.sprite = newSprite;
	}

}
