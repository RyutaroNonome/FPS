using UnityEngine;
using System.Collections;

public class RayController : MonoBehaviour {

	//パーティクル
	[SerializeField] GameObject gunfireEffect;
	//銃口位置
	[SerializeField] GameObject Muzzle;
	Vector3 muzzlePoint;
	//パーティクル発生
	GameObject cloneHitEffect, cloneMuzzleEffect;
	//アニメーター設定
	[SerializeField] Animator anim;
	//敵が起き上がるまでの時間
	float enemyrecoveryTime;
	//敵敵が起き上がるためのBool
	bool getupBool = false;

	//敵の初期体力
	[SerializeField] int firstEnemylife;
	//敵の残体力
	int remainingEnemylife;
	//敵の頭の中心
	[SerializeField] GameObject headCenter;
	Vector3 headCenterPoint;
	//ヒットポイント設定
	int hitPoint;
	[SerializeField] int headshotPointCritical;
	[SerializeField] int headshotPointMiddle;
//	[SerializeField] int headshotPointEdge;
	[SerializeField] int standardPoint;
	private float dis;

	RaycastHit _hit;

	void Start () {
		remainingEnemylife = firstEnemylife;
		//敵の頭の中心を設定
		headCenterPoint = headCenter.transform.position;
	}

	void Update () {

		if(Input.GetMouseButtonDown(0)){
			anim.SetBool ("isGetup" ,false);
			Ray ray = new Ray(transform.position, transform.forward);

			_hit = new RaycastHit();
			muzzlePoint = Muzzle.transform.position;
			cloneMuzzleEffect = (GameObject)Instantiate (gunfireEffect, muzzlePoint, Quaternion.identity);

			//パーティクル削除
			Destroy (cloneMuzzleEffect, .5f);

			if (Physics.Raycast(ray, out _hit)) {
				GameObject selectedObj = _hit.collider.gameObject;
				if (selectedObj.name == "Enemy"){
					DecideHitPoint ();
					remainingEnemylife -= hitPoint;
//					print ("敵体力残り：" + remainingEnemylife);
					if(remainingEnemylife == 0){
						anim.SetBool ("isFall", true);
						enemyrecoveryTime = 2f;
						getupBool = true;
						remainingEnemylife += firstEnemylife;
						print ("敵死亡");
						return;
					}
				}
				//ヒットしたオブジェクトの情報
//				print("name: " + selectedObj.name + selectedObj.transform.position);

				cloneHitEffect = (GameObject)Instantiate (gunfireEffect, _hit.point, Quaternion.identity);

				//パーティクル削除
				Destroy (cloneHitEffect, .5f);
			}
		}
		if (getupBool) {
			enemyrecoveryTime -= Time.deltaTime;
			if(enemyrecoveryTime <= 0f){
				anim.SetBool ("isGetup" ,true);
				anim.SetBool ("isFall" ,false);
				getupBool = false;
			}
		}
	}

	//ヒットポイント判定
	void DecideHitPoint () {
		//弾丸が当たった場所と頭中心との距離をdistancetoHeadに代入
		dis = Vector3.Distance (_hit.point, headCenterPoint);

		if(0.3 < dis){
			hitPoint = standardPoint;
		}
		if(0.16 < dis && dis <= 0.3){
			hitPoint = headshotPointMiddle;
		}
		if(0 <= dis && dis <= 0.16){
			hitPoint = headshotPointCritical;
		}

		print ("ヒットポイント：" + hitPoint + ", " + "dis：" + dis + ", " + "被弾位置：" + _hit.point + ", " + "頭中心位置：" + headCenterPoint);
	}
}