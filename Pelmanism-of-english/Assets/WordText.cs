using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordText : MonoBehaviour {

	//wordを格納するための変数
	public string word;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<Text>().text = word.ToString ();
	}
}
