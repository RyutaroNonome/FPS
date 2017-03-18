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
			targetController.GetUpFalse ();
			Ray ray = new Ray(transform.position, transform.forward);

			_hit = new RaycastHit();
			muzzlePoint = Muzzle.transform.position;
			cloneMuzzleEffect = (GameObject)Instantiate (gunfireEffect, muzzlePoint, Quaternion.identity);

			//パーティクル削除
			Destroy (cloneMuzzleEffect, .5f);
				
			if (Physics.Raycast(ray, out _hit)) {
				TargetController target = _hit.transform.GetComponent<TargetController> ();
				if (target != null){
					targetController.DecideHitPoint ();
					remainingEnemylife -= hitPoint;
					if(remainingEnemylife <= 0){
						targetController.FallDownTrue ();
						targetController.enemyrecoveryTime = 2f;
						targetController.getupBool = true;
						remainingEnemylife += firstEnemylife;
						return;
					}
				}
				cloneHitEffect = (GameObject)Instantiate (gunfireEffect, _hit.point, Quaternion.identity);
				//パーティクル削除
				Destroy (cloneHitEffect, .5f);
			}
		}

		targetController.RecoveryGetUp ();
	}
}