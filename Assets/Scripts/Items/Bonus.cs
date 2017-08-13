using UnityEngine;

[System.Serializable]
public class Bonus{

	[SerializeField]
	public int damageMin;
	[SerializeField]
	public int damageMax;
	[SerializeField]
	public int MPMax;
	[SerializeField]
	public int HPMax;
	[SerializeField]
	public int regeneration;

	public Bonus(){
		
	}
}
