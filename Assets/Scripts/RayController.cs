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
	public Vector3 headCenterPoint;
	//ヒットポイント設定
	public int hitPoint;
	public int headshotPointCritical;
	public int headshotPointMiddle;
	public int standardPoint;
	public float dis;
	public RaycastHit _hit;
	[SerializeField] TargetController targetController;

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
				TargetController target = _hit.transform.GetComponent<TargetController> ();
				if (target != null){
					targetController.DecideHitPoint ();
					remainingEnemylife -= hitPoint;
					if(remainingEnemylife <= 0){
						anim.SetBool ("isFall", true);
						enemyrecoveryTime = 2f;
						getupBool = true;
						remainingEnemylife += firstEnemylife;
						return;
					}
				}
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
}