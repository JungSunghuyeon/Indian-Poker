using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;

public class PlayerName : MonoBehaviour
{
    private Text playerText;
    private Text coinText;
    private static DatabaseReference reference;
    // Start is called before the first frame update
    void Start()
    {
        playerText = GameObject.Find("tf_userName").GetComponent<Text>();
        coinText = GameObject.Find("tf_userCoin").GetComponent<Text>();
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }
     void Update() {
        if(Login.isLogin == true){
            playerText.text = Login.name;
            coinText.text = Login.coin;
        }
    }
    public static void coinUpdate(string id){
        reference = FirebaseDatabase.DefaultInstance.RootReference.Child("member");
        reference.GetValueAsync().ContinueWith(task => {
            DataSnapshot snapshot = task.Result;
            foreach(DataSnapshot data in snapshot.Children){
                IDictionary member = (IDictionary)data.Value;
                if(member["id"].ToString().Equals(id)){
                    Login.coin = member["coin"].ToString();
                    break;
                }
            }
        });
    }
}