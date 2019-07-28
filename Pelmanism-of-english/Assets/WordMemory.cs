using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordMemory : MonoBehaviour {

	//連想配列を宣言
	Dictionary<string, string> dic = new Dictionary<string, string>(){
		//表示する単語のキーと値を設定する。
		{"apple", "りんご"} ,
		{"greap", "ぶどう"} ,
		{"orenge", "みかん"} ,
		{"strawberry", "いちご"} ,
		{"cherry", "さくらんぼ"} ,
		{"watermelon", "スイカ"} ,
		{"pineapple", "パイナップル"} ,
		{"banana", "バナナ"} ,
		{"peach", "もも"} ,
		{"kiwi fruit", "キウイ"}
	};

	//渡す用の配列の変数を取得
	string[] word_index = new string[100];

	// Use this for initialization
	void Start () {

	    var list = new List<string>();
		string[] list_index = new string[10];
		int i=1;
		foreach (KeyValuePair<string, string> pair in dic) {
			list.Add (pair.Key + "=" + pair.Value);
			Debug.Log (pair.Key + ":" + pair.Value);
			i++;
			list_index [i] = pair.Key + ":" + pair.Value;
			Debug.Log (i);
		}
	}

	// Update is called once per frame
	void Update() {
	}

	//textで出力
	void WordText(string list){
		//Debug.Log ("テキストで表示されるはず" + list);
//		int j = 0;
//		for (j = 0; j < list.Length; j++) {
//			this.GetComponent<Text> ().text = list;
//		}
	}
}

