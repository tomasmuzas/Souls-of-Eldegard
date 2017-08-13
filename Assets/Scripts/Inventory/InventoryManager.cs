using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class InventoryManager : MonoBehaviour {

	private Inventory inventory;
	[SerializeField]
	private GameObject inventoryPrefab;
	private GameObject inventoryGameObject;
	[SerializeField]
	private Player player;
	private int currentPage = 0;


	void Show(){

		inventoryGameObject = Instantiate (inventoryPrefab,GameObject.Find("Canvas").transform);
		inventoryGameObject.name = "Inventory";
		inventory = player.GetInventory ();
		int index = currentPage * DEFAULTS.ItemsPerPage;
		for (int i = index; i < DEFAULTS.ItemsPerPage + index; i++) {
			Item item = inventory.items [i];
			Transform itemTileObj = GameObject.Find ("Item (" + i % DEFAULTS.ItemsPerPage + ")").transform.GetChild(0);
			Tile tile = itemTileObj.GetComponent<Tile> ();
			if (tile != null) {
				tile.SetItem (item);
				tile.Render();
			}
		}
		string pageText = (currentPage + 1) + "/" + Mathf.Ceil ((float)inventory.items.Count / 15);
		GameObject.FindGameObjectWithTag ("PagesCount").GetComponent<TextMeshProUGUI> ().SetText( pageText );

	}

	public void Close(){
		Destroy (inventoryGameObject);
	}

	void Update () {
		if (Input.GetKeyDown ("i")) {
			Toggle ();
		}
	}

	public void Toggle(){
		inventoryGameObject = GameObject.Find ("Inventory");
		if (inventoryGameObject != null) {
			Close ();
		} 
		else {
			Show ();
		};
	}


}
