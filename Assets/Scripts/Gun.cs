using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	//銃に入れれる弾の限界数
	public int Bullet;

	//弾倉
	public int bulletBox;
	float coolTime;

	//残弾数・リロードする弾数
	int residualBullet, reloadBullet;

	//銃声・リロード音
	[SerializeField] AudioClip gunfireSound, reloadSound;
	AudioSource audioSource;

	void Start () {
		//残弾数 = 初期弾数
		residualBullet = Bullet;
		audioSource = transform.GetComponent<AudioSource> ();
	}
	
	void Update () {
		//クーリング
		coolTime -= Time.deltaTime;

		//リロードする弾数
		reloadBullet = Bullet - residualBullet;

		//クリックしてショットする
		if (Input.GetMouseButton(0) && residualBullet != 0) {
			//クールタイム機能
			if (coolTime <= 0f){
				Shoot();
			}
		}

		//リロード機能
		if (Input.GetKeyDown (KeyCode.R) && residualBullet < Bullet) {
			audioSource.PlayOneShot (reloadSound);
			//残弾数 = 初期弾数
			residualBullet += reloadBullet;
			//リロードすると弾倉内弾数が減る
			bulletBox -= reloadBullet;

			print ("弾倉内弾数：" + bulletBox);
		}
	}

	//ショット機能
	void Shoot () {
		residualBullet -= 1;
		//後ほどUIで使用
		Debug.Log ("残弾数：" + residualBullet);

		//クールタイム設定
		coolTime = 0.5f;
		audioSource.PlayOneShot (gunfireSound);
	}
}