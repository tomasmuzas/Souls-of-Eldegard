using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Collections;

public class EditItem : EditorWindow {
	Sprite sprite = new Sprite();
	string title = "";
	string description = "";
	bool sellable = false;
	bool armor = false;
	bool weapon = false;
	int cost;
	int resistance;
	int damageMin;
	int damageMax;
	int selected;
	Bonus bonuses = new Bonus();
	static List<Item> items = new List<Item> ();

	[MenuItem("ItemManager/Edit Items...")]
	public static void ShowWindow(){
		GetWindow<EditItem> ("Edit Item");
		items = new List<Item> ();
		Object[] prefabs = Resources.LoadAll ("Items");
		foreach (GameObject prefab in prefabs) {
			Item item = (Item)prefab.GetComponent<Item>();
			if (item != null) {
				items.Add (item);
			}

		}

	}

	void OnGUI(){



		EditorGUILayout.BeginHorizontal ();
			EditorGUILayout.BeginVertical ();

				EditorGUILayout.BeginScrollView (new Vector2 (0, 0), false, false, GUILayout.Width (150), GUILayout.Height (300));

				for (int i = 0; i < items.Count; i++) {
				if (GUILayout.Button ("#" + items [i].ID + " " + items [i].title, EditorStyles.boldLabel)) {
						selected = i;
						sprite = items[i].GetSprite();
						title = items[i].title;
						description = items [i].description;
						sellable = items[i].IsSellable();
						armor = items[i].GetComponent<Armor>() != null;
						weapon = items[i].GetComponent<Weapon>() != null;
						bonuses = items[i].GetBonuses();
						cost = items[i].GetCost();
						if (armor) {
							resistance = items[i].GetComponent<Armor>().GetResistance();
						}
						if (weapon) {
							damageMin = items[i].GetComponent<Weapon>().GetDamageMin();
							damageMax = items[i].GetComponent<Weapon>().GetDamageMax();
						}

						
					}
				}

				EditorGUILayout.EndScrollView ();

			EditorGUILayout.EndVertical ();




			EditorGUILayout.BeginVertical ();
					if (items.Count > 0) {
						GUILayout.Label ("Image:");
						sprite = (Sprite)EditorGUILayout.ObjectField ("", sprite, typeof(Sprite), true, GUILayout.Height (150), GUILayout.Width (150));
						EditorGUILayout.Space ();


						title = EditorGUILayout.TextField ("Title", title);
						EditorGUILayout.Space ();
						GUILayout.Label ("Description");
						description = EditorGUILayout.TextArea (description,GUILayout.Height(50));
						EditorGUILayout.Space ();


						sellable = EditorGUILayout.BeginToggleGroup ("Sellable", sellable);
						cost = EditorGUILayout.IntField ("Cost", cost);
						EditorGUILayout.EndToggleGroup ();
						EditorGUILayout.Space ();


						GUILayout.Label ("Bonuses:");
						bonuses.damageMin = EditorGUILayout.IntField ("Minimal Damage:", bonuses.damageMin);
						bonuses.damageMax = EditorGUILayout.IntField ("Maximal Damage:", bonuses.damageMax);
						bonuses.MPMax = EditorGUILayout.IntField ("Maximal MP:", bonuses.MPMax);
						bonuses.HPMax = EditorGUILayout.IntField ("Maximal HP:", bonuses.HPMax);
						bonuses.regeneration = EditorGUILayout.IntField ("+ Regeneration:", bonuses.regeneration);
						EditorGUILayout.Space ();

						armor = EditorGUILayout.BeginToggleGroup ("Armor", armor);
						resistance = EditorGUILayout.IntField ("Resistance:", resistance);
						EditorGUILayout.EndToggleGroup ();
						EditorGUILayout.Space ();

						weapon = EditorGUILayout.BeginToggleGroup ("Weapon", weapon);
						damageMin = EditorGUILayout.IntField ("Minimal damage:", damageMin);
						damageMax = EditorGUILayout.IntField ("Maximal damage:", damageMax);
						EditorGUILayout.EndToggleGroup ();



						if (GUILayout.Button ("Save")) {
							Save ();
							sprite = new Sprite ();
							title = "";
							description = "";
							sellable = false;
							armor = false;
							weapon = false;
							cost = resistance = damageMax = damageMin = 0;
							bonuses = new Bonus ();
						}

					} 
					else {
						GUILayout.Label ("No items to display");
					}
				
			EditorGUILayout.EndVertical();

		EditorGUILayout.EndHorizontal ();

	}

	public void Save(){
		
		Item newItem = items[selected];
		newItem.title = title;
		newItem.description = description;
		newItem.SetSellable (sellable);
		newItem.SetCost (cost);
		newItem.SetBonuses (bonuses);
		newItem.SetSprite (sprite);
		if (armor) {
			((Armor)newItem).SetResistance (resistance);
		}
		if (weapon) {
			((Weapon)newItem).SetDamageMin (damageMin);
			((Weapon)newItem).SetDamageMax (damageMax);
		}

	}
}
