using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using System.Collections.Concurrent;
using System;

public class SignUp : MonoBehaviour
{
    public GameObject Available,NotAvailable, check;
    DatabaseReference reference;
    public InputField id_text2;
    public InputField name_text;
    public InputField password_text2;
    public InputField password_text3;
    public bool id_check = false;
    private int dafaultCoin = 30;
    public void Awake(){
        Available = GameObject.Find("Avail");
        NotAvailable = GameObject.Find("NotAvail");
        check = GameObject.Find("Check");
        Available.SetActive(false);
        NotAvailable.SetActive(false);
        check.SetActive(false);
    }
    public void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }
    private ConcurrentQueue<Action> mainThreadActions = new ConcurrentQueue<Action>();

    private void Update(){
        while(mainThreadActions.Count > 0 && mainThreadActions.TryDequeue(out var action)){
            action?.Invoke();
        }
    }    
    public void Change()
    {
        SceneManager.LoadScene("SignUp");
    }
    public void checkDuplecate()
    {
        checkDuplicated(id_text2.text);
    }
    public void register()
    {
        if (id_text2.text != null && name_text.text != null && password_text2.text != null && password_text3.text != null)
        {
            if (id_check)
            {
                string pwd = password_text2.text;
                string pwd_ck = password_text3.text;
                if (pwd.Equals(pwd_ck))
                {
                    register(name_text.text, id_text2.text, pwd);
                    Debug.Log("success");
                    SceneManager.LoadScene("Login");
                }
            }
            else
            {
                check.SetActive(true);
                Debug.Log("Not duplication checked");
            }
        }
        else
        {
            check.SetActive(true);
            Debug.Log("something is empty");
        }
    }
    private void register(string name, string id, string pwd)
    {
        Member member = new Member(name, id, pwd, dafaultCoin);
        string json = JsonUtility.ToJson(member);
        string key = reference.Child("member").Push().Key;
        reference.Child(key).SetRawJsonValueAsync(json);
        //to login
    }
    private void checkDuplicated(string id)
    {
        int check = 0;
        reference = FirebaseDatabase.DefaultInstance.RootReference.Child("member");
        reference.GetValueAsync().ContinueWith(task =>
        {
            mainThreadActions.Enqueue(() =>
            {
                if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    foreach (DataSnapshot data in snapshot.Children)
                    {
                        IDictionary member = (IDictionary)data.Value;
                        Debug.Log("member = " + member["id"]);
                        Debug.Log("id = " + id);
                        
                        if (member["id"].Equals(id))
                        {
                            check++;
                            break;
                        }
                    }
                    if (check != 0)
                    {
                        NotAvailable.SetActive(true);
                        id_check = false;
                    }
                    else
                    {
                        Available.SetActive(true);
                        id_check = true;
                    }
                }
            });
        });
         
    }
}