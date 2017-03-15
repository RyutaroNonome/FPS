using UnityEngine;
using System.Collections;

public class RayController : MonoBehaviour {

	//パーティクル
	public GameObject gunfireEffect;

	void start () {
	}

	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Ray ray = new Ray(transform.position, transform.forward);

			RaycastHit hit = new RaycastHit();

			if (Physics.Raycast(ray, out hit)) {
				GameObject selectedObj = hit.collider.gameObject;             
				print("name: " + selectedObj.name + selectedObj.transform.position);

				//パーティクル発生
				GameObject clone;
				clone = (GameObject)Instantiate (gunfireEffect, hit.point, Quaternion.identity);
				//パーティクル削除
				Destroy (clone, .5f);
			}
		}
	}
}