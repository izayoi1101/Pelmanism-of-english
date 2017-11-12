﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class touchword : MonoBehaviour {
	Button[] first_word,second_word;
	public Button buttonPrefab;
	int first_word_ptr,second_word_ptr;
	//２つ目のボタンを押した回数
	int wait_cnt=0;
	int tmp_index_first,tmp_index_second;
	// Use this for initialization
	void Start () {
		StartCoroutine (Timelimit(10));
		int i = 0;
		first_word = new Button[3];
		second_word = new Button[3];
		for(i=0;i<3;i++){
			first_word[i] = Instantiate (buttonPrefab) as Button;
			first_word[i].transform.SetParent (this.transform);
			//位置設定
			first_word[i].GetComponent<RectTransform>().localPosition = new Vector2 (-140, 138-80*i);
			//Debug.Log (first_word[i].name);
			//ここのポインタは乱数によって代入するインデックスが異なる
			first_word[i].transform.FindChild ("word_ptr").GetComponent<Text> ().text = i.ToString();
			int n = i;
			first_word[i].onClick.AddListener(() => {
				second_word[tmp_index_second].interactable = true;
				tmp_index_first = n;
				//Debug.Log(n);
				first_word_ptr = int.Parse(first_word[n].transform.FindChild ("word_ptr").GetComponent<Text> ().text);
				Debug.Log(first_word[n].transform.FindChild ("word_ptr").GetComponent<Text> ().text);
//								Debug.Log(first_word_ptr);

				//次のSecondターンが終わるまでFirstの方は非アクティブにする
				foreach(Button value in first_word){
					if(value.interactable==true){
						value.enabled = false;
					}
				}
				//Secondの方を押せるようにする
				foreach(Button value in second_word){
						value.enabled = true;
				}
				first_word[n].enabled = true;
				first_word[n].interactable = false;
			});	


			second_word[i] = Instantiate (buttonPrefab) as Button;
			second_word[i].transform.SetParent (this.transform);

			if (wait_cnt < 1) {
				second_word [i].enabled = false;
			} else if(wait_cnt ==1){
				second_word [i].enabled = true;
			}
			//位置設定
			second_word[i].GetComponent<RectTransform>().localPosition = new Vector2 (120, 138-80*i);
			second_word[i].transform.FindChild ("word_ptr").GetComponent<Text> ().text = i.ToString();

			int m = i;
			second_word[i].onClick.AddListener(() => {
				wait_cnt++;
				Debug.Log(wait_cnt);
				first_word[tmp_index_first].interactable = true;
				tmp_index_second = m;
				second_word_ptr = int.Parse(second_word[m].transform.FindChild ("word_ptr").GetComponent<Text> ().text);
				Debug.Log(second_word[m].transform.FindChild ("word_ptr").GetComponent<Text> ().text);	
//				Debug.Log(second_word_ptr);

				bool iscomplete = false;
				if(first_word_ptr == second_word_ptr){
					Debug.Log ("complete!!!!!!1");
					iscomplete = true;
					foreach(Button value in first_word){
						if(value.interactable==true){
							value.enabled = false;
						}
					}
				}

				foreach(Button value in second_word){
					if(value.interactable==true){
						value.enabled = false;
					}
				}

				//次のFirstカードを有効にする(コンプリート時を除く)
				if(!iscomplete){
					foreach(Button value in first_word){
						if(value.interactable==true){
							value.enabled = true;
						}
					}
				}

//				second_word[m].enabled = true;
//				second_word[m].interactable = false;
//				second_word[m].enabled = false;
//				second_word[m].interactable = true;
			});
		}
	}

	void Update(){
		//Debug.Log (first_word_ptr+" "+second_word_ptr);
//		Debug.Log(wait_cnt);
//		if(first_word_ptr == second_word_ptr && wait_cnt>0){
//			Debug.Log ("complete!!!!!!1");
//			foreach(Button value in first_word){
//				if(value.interactable==true){
//					value.enabled = false;
//				}
//			}
//		}
	}


	public IEnumerator Timelimit(int time) {  
		yield return new WaitForSeconds (time);
		Debug.Log ("GameOver");
	}  

}