using UnityEngine;
using System.Collections;

public class RayController : MonoBehaviour {

	//パーティクル
	public GameObject gunfireEffect;

	void start () {
	}

	void Update () {
		if(Input.GetMouseButtonDown(0)){
//			Ray ray = Camera.main.ScreenPointToRay(Camera.main.transform.forward);
			Ray ray = new Ray(transform.position, transform.forward);

			RaycastHit hit = new RaycastHit();

			if (Physics.Raycast(ray, out hit)) {
				GameObject selectedObj = hit.collider.gameObject;             
				print("name: " + selectedObj.name + selectedObj.transform.position);
				Instantiate (gunfireEffect, hit.point, Quaternion.identity);
				print ("おっぱい：" + hit.point);
			}
		}
	}
}