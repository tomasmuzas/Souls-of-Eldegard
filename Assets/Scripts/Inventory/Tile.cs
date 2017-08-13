using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Tile: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{

	Item item;
	public GameObject tooltip;
	GameObject tooltipObj = null;

	public void Swap(Tile other){
		Item temp = this.item;
		this.item = other.item;
		other.item = temp;
	}

	public void Render(){
		Image image = this.GetComponent<Image> ();
		if (image != null && item != null) {
			image.sprite = this.item.GetSprite ();
			image.color = new Color (255,255,255,255);
		}

	}

	public void SetItem(Item item){
		this.item = item;
	}

	public void OnPointerEnter(PointerEventData data){
		if (tooltipObj == null && item != null ) {
			tooltipObj = Instantiate (tooltip, new Vector2(0,0), Quaternion.identity, GameObject.Find ("Canvas").transform);
			tooltipObj.transform.position = data.position;
			GameObject.FindGameObjectWithTag ("ItemTooltipDescription").GetComponent<TextMeshProUGUI> ().SetText( item.description);
			GameObject.FindGameObjectWithTag ("ItemTooltipCost").GetComponent<TextMeshProUGUI> ().SetText("Cost: " + item.GetCost());
		}

	}

	public void OnPointerExit(PointerEventData data){
		Destroy (tooltipObj);
	}
}
