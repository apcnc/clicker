using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class main : MonoBehaviour {
	private float woodpersecond, foodpersecond, landpersecond;
	public float wood, food, land;
	public int woodcutter, explorer, farmer, settler;
	public float woodperwoodcutter, foodperfarmer, landperexplorer;
	public float landperfood, landperwood;
	public Text woodanzeige;
	// Use this for initialization
	void Start () {
		StartCoroutine(ticker ());
	}
	
	// Update is called once per frame
	void Update () {
		woodpersecond = woodcutter * woodperwoodcutter;
		foodpersecond = farmer * foodperfarmer;
		landpersecond = explorer * landperexplorer;
		woodanzeige.text = "Settler: "+ settler +"\nWood: " + wood + "\nFood: " + food + "\nLand: " + land + "\nWoodPerSecond: " + woodpersecond + "\nFoodPerSecond: " + foodpersecond + "\nLandPerSecond: " + landpersecond;
	}

	void tick(){
		land += landpersecond;
		if (land >= landperwood * woodpersecond) {
			wood += woodpersecond;
			land -= landperwood * woodpersecond;
		}
		if (land >= landperfood * foodpersecond) {
			food += foodpersecond;
			land -= landperfood * foodpersecond;
		}
		food -= woodcutter + farmer + settler + explorer;

	}

	IEnumerator ticker(){
		while (true) {
			tick ();
			yield return new WaitForSeconds (1f);
		}
	}

	public void settlerclick(){
		if (food > 0) {
			settler++;
			food--;
		}
	}

	public void farmerclick(){
		if (settler > 0) {
			farmer++;
			settler--;
		}
	}

	public void wootcutterclick(){
		if (settler > 0) {
			woodcutter++;
			settler--;
		}
	}

	public void explorerclick(){
		if (settler > 0) {
			explorer++;
			settler--;
		}
	}
}
