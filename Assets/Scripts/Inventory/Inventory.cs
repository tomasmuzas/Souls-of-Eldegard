using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Inventory{
	public List< Item > items;

	public Inventory(){
		items = new List<Item> ();
		for (int i = 0; i < 32; i++) {
			items.Add (null);
		}
	}

	public void AddItem(Item item){
		int i;
		for (i = 0; i < items.Count; i++) {
			if (items[i] == null) {
				break;
			}
		}
		items [i] = item;
	}

	public void RemoveItem(int ID){
		int i;
		for (i = 0; i < items.Count; i++) {
			if (items[i].ID == ID) {
				break;
			}
		}
		items.RemoveAt (i);
	}

	public Item GetItem(int index){
		return items [index];
	}
}
