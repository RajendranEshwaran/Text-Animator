using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class parallex : MonoBehaviour {


	private float length, startPos;
	public GameObject cam;
	//public float paralexEffect;
	public float speed;
	public Image img1;



	// Use this for initialization
	void Start () {

		startPos = transform.position.x;
		//length = GetComponent<SpriteRenderer> ().bounds.size.x;

		Debug.Log (startPos + "---" + length);

		//StartCoroutine(MoveToPos(new Vector3(0,3,0)));
	}
	
	// Update is called once per frame
	void Update () {


		cam.transform.position = new Vector3 (transform.position.x * speed, transform.position.y, transform.position.z);
		//cam.transform.position = Vector3.MoveTowards (transform.position, new Vector3 (transform.position.x - 0.1f, transform.position.y, transform.position.z), speed);

//		if (img1.transform.position.x < 699) {
//			img1.transform.position.x = img1.transform.position.x - speed * Time.deltaTime;
//
//			Debug.Log ("x:" + img1.transform.position.x);
//		}
//		float temp = (cam.transform.position.x * (1 - paralexEffect));
//		float dis = (cam.transform.position.x * paralexEffect);
//		transform.position = new Vector3 (startPos + dis, transform.position.y, transform.position.z);
//		if (temp > startPos + length)
//			startPos += length;
//		else if (temp < startPos - length)
//			startPos -= length;
	}

	public IEnumerator MoveToPos(Vector3 endPos) {
		Vector3 startPos = transform.position;
		float t = 0f;
		while(t < 1f) {
			transform.position = Vector3.Lerp(startPos, endPos, t);
			t += Time.deltaTime;
			yield return null;
		}
	}
	
}
