using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public int Bullet;
	public int bulletBox;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0) && Bullet != 0) {
			print("左ボタンが押されている");
			Bullet -= 1;
			Debug.Log (Bullet);
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
//
//		if(bulletBox == 0){
//			print ("なくなりました！");
//		}
	}
}
