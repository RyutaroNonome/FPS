using UnityEngine;
using System.Collections;

public class RayController : MonoBehaviour {

	//パーティクル
	[SerializeField] GameObject gunfireEffect;
	[SerializeField] GameObject Muzzle;
	Vector3 muzzlePoint;

	//パーティクル発生
	GameObject cloneHitEffect, cloneMuzzleEffect;

	[SerializeField] Animator anim;

	void Start () {
//		anim = GetComponents<Animator> ();
	}

	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Ray ray = new Ray(transform.position, transform.forward);

			RaycastHit hit = new RaycastHit();
			muzzlePoint = Muzzle.transform.position;
			cloneMuzzleEffect = (GameObject)Instantiate (gunfireEffect, muzzlePoint, Quaternion.identity);

			//パーティクル削除
			Destroy (cloneMuzzleEffect, .5f);

			if (Physics.Raycast(ray, out hit)) {
				GameObject selectedObj = hit.collider.gameObject;

				//ヒットしたオブジェクトの情報
				print("name: " + selectedObj.name + selectedObj.transform.position);
				if(selectedObj.name == "Enemy"){
					anim.SetBool ("isFall", true);
				}

				cloneHitEffect = (GameObject)Instantiate (gunfireEffect, hit.point, Quaternion.identity);

				//パーティクル削除
				Destroy (cloneHitEffect, .5f);


			}
		}
	}
}