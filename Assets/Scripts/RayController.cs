using UnityEngine;
using System.Collections;

public class RayController : MonoBehaviour {

	//パーティクル
	public GameObject gunfireEffect;
	[SerializeField] GameObject usingGun;
	Vector3 muzzlePoint;

	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Ray ray = new Ray(transform.position, transform.forward);

			RaycastHit hit = new RaycastHit();

			if (Physics.Raycast(ray, out hit)) {
				GameObject selectedObj = hit.collider.gameObject;

				//パーティクル発生
				GameObject clone1, clone2;
				muzzlePoint = new Vector3 (usingGun.transform.position.x, usingGun.transform.position.y , usingGun.transform.position.z + 1f);

				clone1 = (GameObject)Instantiate (gunfireEffect, hit.point, Quaternion.identity);
				clone2 = (GameObject)Instantiate (gunfireEffect, muzzlePoint, Quaternion.identity);

				//パーティクル削除
				Destroy (clone1, .5f);
				Destroy (clone2, .5f);
			}
		}
	}
}