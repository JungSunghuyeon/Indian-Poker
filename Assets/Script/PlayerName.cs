using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    private Text playerText;
    private Text coinText;
    // Start is called before the first frame update
    void Start()
    {
        playerText = GameObject.Find("tf_userName").GetComponent<Text>();
        coinText = GameObject.Find("tf_userCoin").GetComponent<Text>();
        
    }
     void Update() {
        if(Login.isLogin == true){
            playerText.text = Login.name;
            coinText.text = Login.coin;
        }
    }
}
