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
    public static bool isLogin = false;
    public static string name;
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
                        name = member["name"].ToString();
                        Debug.Log("login Success");
                        isLogin = true;
                        break;
                    }
                }
            }
        });
        SceneManager.LoadScene("Lobby");
    }
    public void SignUp(){
        SceneManager.LoadScene("SignUp");
    }
}
