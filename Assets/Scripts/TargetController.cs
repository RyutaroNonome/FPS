using UnityEngine;
using System.Collections;

public class TargetController : MonoBehaviour {

	[SerializeField] RayController rayController;

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
}