using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using System.Collections.Concurrent;
using System;

public class Ranking : MonoBehaviour
{   
    public Text[] Rank = new Text[8];
    public string[] strRank;
    public long strLen;

    private bool textLoad = false;
    // Start is called before the first frame update
    
    public DatabaseReference reference;
    public string tmp;
    void Start()
    {
       reference = FirebaseDatabase.DefaultInstance.RootReference;
      
    //   reference = FirebaseDatabase.DefaultInstance.RootReference.Child("member");
    //   reference.GetValueAsync().ContinueWith(task => {
    //         if (task.IsCompleted){ // 성공적으로 데이터를 가져왔으면
    //             DataSnapshot snapshot = task.Result;
    //             // 데이터를 출력하고자 할때는 Snapshot 객체 사용함
 
    //             foreach(DataSnapshot data in snapshot.Children){
    //                 IDictionary rank = (IDictionary)data.Value;
    //                 Debug.Log(snapshot.Key[1]);
    //                // Debug.Log("이름: " + rank["name"] + ", 코인: " + rank["coin"]);
                   
                    
    //                 coin1 = Convert.ToInt32(rank["coin"]);
    //                 coin2 = 2;
                    
    //                // Debug.Log("1111111111111111111   : "+coin1);
                    
    //             }
                
    //         }
    //     });
    //     Rank_coin1.text = coin1.ToString(); 
    }  

    // Update is called once per frame
    void Update()
    {
        try{
       DataLoad();   
        if (textLoad)
        {
            TextLoad();
        }
        if (Time.timeScale != 0.0f) Time.timeScale = 0.0f;
        }catch(System.NullReferenceException){
            Debug.Log("null");
        }
    }
    void LateUpdate()
    {
       
    }
    void DataLoad()
    {
        //데이터 로드
        reference.Child("member").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                //에러 데이터로드 실패 시 다시 데이터 로드
                DataLoad();
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                
                int count = 0;
                strLen = snapshot.ChildrenCount;
                strRank = new string[strLen];
                
                foreach (DataSnapshot data in snapshot.Children)
                {
                    //받은 데이터들을 하나씩 잘라 string 배열에 저장
                    IDictionary rankInfo = (IDictionary)data.Value;
                    
                    //strRank[count] = Convert.ToInt32(rankInfo["coin"]);
                    
                    
                    strRank[count] = rankInfo["id"].ToString() + "님 " 
                                    + string.Format("{0:N2}", rankInfo["coin"] + "coin");
                    count++;
                    
                }
                //LateUpdate의 TextLoad() 함수 실행
                textLoad = true;
            }
        });
    }

    void TextLoad()
    {
        textLoad = false;
        try
        {
            //받아온 데이터 정렬 = > 위에서부터 아래로
            //Array.Sort(strRank);
             Array.Sort(strRank, (x, y) => string.Compare(
           y.Substring(y.Length - 8,5).ToString() + x.Substring(x.Length - 8,5).ToString(),
          x.Substring(x.Length - 8,5).ToString() + y.Substring(y.Length - 8, 5).ToString()));
         
        }
        catch (System.NullReferenceException e)
        {
            return;
        }

        for (int i = 0; i < Rank.Length; i++)
        {
 //Text UI 에 현재 가지고있는 str 길이 까지만 보여주기 위함.
            if (strLen <= i) return;      
            Rank[i].text = strRank[i];
        }
    }
}
