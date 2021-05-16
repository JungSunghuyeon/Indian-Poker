using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public Text playerText;
    // Start is called before the first frame update
    void Start()
    {
        if(Login.isLogin == true){
            playerText.text = Login.name;
        }
    }
}
