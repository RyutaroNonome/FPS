using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public int Bullet;
	public int bulletBox;
	float coolTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		coolTime -= Time.deltaTime;
		if (Input.GetMouseButton(0) && Bullet != 0) {
//			print("左ボタンが押されている");

			//クールタイム機能
			if (coolTime <= 0f){
				Shoot();
			}
			if(Bullet == 0){
				print ("なくなりました！");
				return;
			}
		}

		if (Input.GetKeyDown (KeyCode.R) && Bullet == 0) {
			Bullet = 3;
			bulletBox -= Bullet;
			print (bulletBox);
		}
	}

	void Shoot () {
		Bullet -= 1;
		Debug.Log ("残弾数：" + Bullet);
		coolTime = 0.5f;
	}
}