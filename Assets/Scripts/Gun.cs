using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public int Bullet;
	public int bulletBox;
	float coolTime;

	//銃声
	[SerializeField] AudioClip gunfireSound;
	AudioSource audioSource;

	void Start () {
		audioSource = transform.GetComponent<AudioSource> ();
	}
	
	void Update () {
		coolTime -= Time.deltaTime;
		if (Input.GetMouseButton(0) && Bullet != 0) {

			//クールタイム機能
			if (coolTime <= 0f){
				Shoot();
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
		audioSource.PlayOneShot (gunfireSound);
	}
}