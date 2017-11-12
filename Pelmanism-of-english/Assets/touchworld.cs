using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class touchword : MonoBehaviour {
	Button[] first_word,second_word;
	public Button buttonPrefab;
	int first_word_ptr,second_word_ptr;
	int wait_cnt=0;
	// Use this for initialization
	void Start () {
		int i = 0;
		first_word = new Button[3];
		second_word = new Button[3];
		for(i=0;i<3;i++){
			first_word[i] = Instantiate (buttonPrefab) as Button;
			first_word[i].transform.SetParent (this.transform);
			//位置設定
			first_word[i].GetComponent<RectTransform>().localPosition = new Vector2 (-140, 138-80*i);
			//Debug.Log (first_word[i].name);
			first_word[i].transform.Find ("word_ptr").GetComponent<Text> ().text = i.ToString();
			int n = i;
			first_word[i].onClick.AddListener(() => {
				//Debug.Log(n);
				first_word_ptr = int.Parse(first_word[n].transform.Find ("word_ptr").GetComponent<Text> ().text);
				Debug.Log(first_word[n].transform.Find ("word_ptr").GetComponent<Text> ().text);
//								Debug.Log(first_word_ptr);

				//次のSecondターンが終わるまでFirstの方は非アクティブにする
				foreach(Button value in first_word){
					if(value.interactable==true){
						value.enabled = false;
					}
				}
				//Secondの方を押せるようにする
				foreach(Button value in second_word){
					if(value.interactable==true){
						value.enabled = true;
					}
				}
				//interactiable = trueの見栄えを良くするためにenabledの方は解除する
				first_word[n].enabled=true;
				first_word[n].interactable=false;
			});	


			second_word[i] = Instantiate (buttonPrefab) as Button;
			second_word[i].transform.SetParent (this.transform);
			//位置設定
			second_word[i].GetComponent<RectTransform>().localPosition = new Vector2 (120, 138-80*i);
			second_word[i].transform.Find ("word_ptr").GetComponent<Text> ().text = i.ToString();
			int m = i;
			second_word[i].onClick.AddListener(() => {
				wait_cnt++;
				second_word_ptr = int.Parse(second_word[m].transform.Find ("word_ptr").GetComponent<Text> ().text);
				Debug.Log(second_word[m].transform.Find ("word_ptr").GetComponent<Text> ().text);	
//				Debug.Log(second_word_ptr);

				foreach(Button value in second_word){
					if(value.interactable==true){
						value.enabled = false;
					}
				}
				foreach(Button value in first_word){
					if(value.interactable==true){
						value.enabled = true;
					}
				}
				//interactiable = trueの見栄えを良くするためにenabledの方は解除する
				second_word[n].enabled=true;
				second_word[n].interactable=false;
			});
		}
	}

	void Update(){
		//Debug.Log (first_word_ptr+" "+second_word_ptr);
		Debug.Log(wait_cnt);
		if(first_word_ptr == second_word_ptr && wait_cnt>0){
			Debug.Log ("complete!!!!!!1");
			foreach(Button value in first_word){
				if(value.interactable==true){
					value.enabled = true;
				}
			}
		}
	}

}