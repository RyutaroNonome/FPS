using UnityEngine;
using System.Collections;

public class TargetController : MonoBehaviour {

	[SerializeField] RayController rayController;
	//アニメーター設定
	[SerializeField] Animator anim;

	//敵が起き上がるまでの時間
	public float enemyrecoveryTime;
	//敵敵が起き上がるためのBool
	public bool getupBool = false;

	public void DecideHitPoint () {
		//弾丸が当たった場所と頭中心との距離をdistancetoHeadに代入
		rayController.dis = Vector3.Distance (rayController._hit.point, rayController.headCenterPoint);

		if(0.3 < rayController.dis){
			rayController.hitPoint = rayController.standardPoint;
		} else if (0.16 < rayController.dis && rayController.dis <= 0.3){
			rayController.hitPoint = rayController.headshotPointMiddle;
		} else if (0 <= rayController.dis && rayController.dis <= 0.16){
			rayController.hitPoint = rayController.headshotPointCritical;
		}
	}

	public void GetUpTrue (){
		anim.SetBool ("isGetup" ,true);
	}
	public void GetUpFalse (){
		anim.SetBool ("isGetup" ,false);
	}
	public void FallDownTrue () {
		anim.SetBool ("isGetup" ,true);
	}
	public void FallDownFalse () {
		anim.SetBool ("isGetup" ,false);
	}
	public void RecoveryGetUp () {
		if (getupBool) {
			enemyrecoveryTime -= Time.deltaTime;
			if(enemyrecoveryTime <= 0f){
				this.GetUpTrue ();
				this.FallDownFalse ();
				getupBool = false;
			}
		}
	}
}