﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager instance=null;
	public GameObject BorderObjet;

	private float leftBorder;
	private float rightBorder;
	private float topBorder;
	private float bottomBorder;

	private Vector3 cameraPos;
	private float width;
	private float height;
	// Use this for initialization
	void Awake () {
		if(instance==null){
			instance=this;
		}else if(instance!=this){
			Destroy(gameObject); //than destroy this
		}


		SetBorders ();
		
	}

	void SetBorders(){
//		cameraPos=Camera.main.transform.position;

		//the up right corner
		Vector3 cornerPos=Camera.main.ViewportToWorldPoint(new Vector3(1f,1f,
			Mathf.Abs(-Camera.main.transform.position.z)));

		leftBorder=Camera.main.transform.position.x-(cornerPos.x-Camera.main.transform.position.x);
		rightBorder=cornerPos.x;
		topBorder=cornerPos.y;
		bottomBorder=Camera.main.transform.position.y-(cornerPos.y-Camera.main.transform.position.y);

		width=rightBorder-leftBorder;
		height=topBorder-bottomBorder;

		Debug.Log (" width: " + width + '\n' + "height:" + height);

	}


	void Start () {
		
		GameObject left= Instantiate (BorderObjet, 
			new Vector3 (leftBorder, 0, 0), 
			Quaternion.identity) as GameObject;
		left.transform.localScale = new Vector3 (1, height, 1);
		left.transform.Translate( new Vector3(-left.transform.localScale.x/2,0,0));


		GameObject right= Instantiate (BorderObjet,  new Vector3 (rightBorder, 0, 0), Quaternion.identity)as GameObject;
		right.transform.localScale = new Vector3 (1, height, 1);
		right.transform.Translate (new Vector3 (right.transform.localScale.x / 2,0,0));

		GameObject top= Instantiate (BorderObjet,  new Vector3 (0, topBorder, 0), Quaternion.identity)as GameObject;
		top.transform.localScale = new Vector3 (width, 1, 1);
		top.transform.Translate (new Vector3 (0, top.transform.localScale.y / 2,0));

		GameObject bottom= Instantiate (BorderObjet,  new Vector3 (0, bottomBorder, 0), Quaternion.identity)as GameObject;
		bottom.transform.localScale = new Vector3 (width, 1, 1);
		bottom.transform.Translate (new Vector3 (0, -bottom.transform.localScale.y/2f,0));
	}
}