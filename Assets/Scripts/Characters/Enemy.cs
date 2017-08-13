using UnityEngine;
using System.Collections.Generic;
[System.Serializable]
public class Enemy : MonoBehaviour {
	[SerializeField]
	private int HP;
	[SerializeField]
	private int MP;
	[SerializeField]
	private int damage;
	[SerializeField]
	private List<Item> drop;
	[SerializeField]
	private int soulsReward;
}
