using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using System.Collections.Concurrent;
using System;

public class Login : MonoBehaviour
{
    DatabaseReference reference;
    public InputField id_text;
    public InputField password_text;
    public static bool isLogin = false;
    public static string name;
    public static String coin;
    // Start is called before the first frame update


    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }
    private ConcurrentQueue<Action> mainThreadActions = new ConcurrentQueue<Action>();
    private void Update(){
        while(mainThreadActions.Count > 0 && mainThreadActions.TryDequeue(out var action)){
            action?.Invoke();
        }
    }
    // Update is called once per frame
    public void login(){
        int check = 0;
        string id = id_text.text;
        string pwd = password_text.text;
        reference = FirebaseDatabase.DefaultInstance.RootReference.Child("member");
        reference.GetValueAsync().ContinueWith(task => {
            mainThreadActions.Enqueue(() =>
            {
                DataSnapshot snapshot = task.Result;
                foreach(DataSnapshot data in snapshot.Children){
                    IDictionary member = (IDictionary)data.Value;
                    if(member["id"].ToString().Equals(id) && member["pwd"].ToString().Equals(pwd)){
                        name = member["name"].ToString();
                        coin = member["coin"].ToString();
                        Debug.Log("login Success");
                        isLogin = true;
                        SceneManager.LoadScene("Lobby");
                        break;
                    }
                }
            }    
            );
        });
    }
    public void SignUp(){
        SceneManager.LoadScene("SignUp");
    }
}
