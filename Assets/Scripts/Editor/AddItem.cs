using UnityEngine;
using UnityEditor;

public class AddItem : EditorWindow {
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
	Bonus bonuses = new Bonus();

	[MenuItem("ItemManager/Add Item...")]
	public static void ShowWindow(){
		GetWindow<AddItem> ("Add Item");
	}
		
	void OnGUI(){
		GUILayout.Label ("Image:");
		sprite = (Sprite)EditorGUILayout.ObjectField ("",sprite, typeof(Sprite),true,GUILayout.Height(150),GUILayout.Width(150));
		EditorGUILayout.Space ();


		title = EditorGUILayout.TextField ("Title",title);
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



		if (GUILayout.Button ("Add")) {
			Save();
			sprite = new Sprite();
			title = "";
			sellable = false;
			armor = false;
			weapon = false;
			cost = resistance = damageMax = damageMin = 0;
			bonuses = new Bonus();
		}
	}

	public void Save(){

		string prefabPath = "Assets/Resources/Items";
		GameObject prefab = new GameObject ();
		if (armor) {
			prefab.AddComponent<Armor> ();
		} 
		else if (weapon) {
			prefab.AddComponent<Weapon> ();
		} 
		else {
			prefab.AddComponent<Item>();
		}

		new Item ();
		Item newItem = prefab.GetComponent<Item>();
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
		prefabPath += "/"+newItem.title+".prefab";

		PrefabUtility.CreatePrefab (prefabPath, prefab.gameObject);

	}
}
