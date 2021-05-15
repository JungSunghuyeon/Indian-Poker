using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;

public class Login : MonoBehaviour
{
    DatabaseReference reference;
    public InputField id_text;
    public InputField password_text;
    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // Update is called once per frame
    public void login(){
        int check = 0;
        string id = id_text.text;
        string pwd = password_text.text;
        reference = FirebaseDatabase.DefaultInstance.RootReference.Child("member");
        reference.GetValueAsync().ContinueWith(task => {
            if(task.IsCompleted){
                DataSnapshot snapshot = task.Result;
                foreach(DataSnapshot data in snapshot.Children){
                    IDictionary member = (IDictionary)data.Value;
                    if(member["id"].ToString().Equals(id) && member["pwd"].ToString().Equals(pwd)){
                        check++;
                        break;
                    }
                }
                if(check != 0){
                    Debug.Log("login Success");
                    // to main
                }
            }
        });
    }
}
