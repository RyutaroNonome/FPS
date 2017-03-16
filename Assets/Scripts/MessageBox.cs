using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour {

	[SerializeField] Canvas canvas;
	[SerializeField] Text timeText;
	[SerializeField] Text ptText;
	[SerializeField] Text bulletboxText;
	[SerializeField] Text bulletText;

	[SerializeField] RayController rayController;
	[SerializeField] Gun gun;

	int test;

	// Use this for initialization
	void Start () {
		test = gun.bullet; 
	}
	
	// Update is called once per frame
	void Update () {
//		text.text = string.Format("{0:f3}",Time.time.ToString(), 1);
		timeText.text = "Time：" + Time.time.ToString("f1") + "s";
		ptText.text = " Pt：" + rayController.hitPoint;
		bulletboxText.text = "BulletBox：" + gun.bulletBox;
		bulletText.text = "Bullet：" + gun.residualBullet + "/" + gun.bullet;
	}
}