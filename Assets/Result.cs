using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Firebase;
using Firebase.Database;

public class Result : MonoBehaviourPunCallbacks, IPunObservable
{
    public static Text tx_result;
    DatabaseReference reference;

    void Start()
    {
        tx_result = GameObject.Find("tx_result").GetComponent<Text>();
        tx_result.text = " ";
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void Update() {
        if(Player1Button.p1state == true && Player2Button.p2state == true){
            if(P1CardNumber.p1Num > P2CardNumber.p2Num){
                tx_result.text = Player1Name.tx_p1Name.text + "승리";
                int winCoin = int.Parse(Player1Coin.tx_p1Coin.text) + BettingCoin.num;
                int loseCoin = int.Parse(Player2Coin.tx_p2Coin.text);
                coinUpdate(Player1ID.player1ID, winCoin);
                coinUpdate(Player2ID.player2ID, loseCoin);
                Invoke("onLeftRoom", 2);
            }
            else if(P1CardNumber.p1Num < P2CardNumber.p2Num){
                tx_result.text = Player2Name.tx_p2Name.text + "승리";
                int winCoin = int.Parse(Player2Coin.tx_p2Coin.text) + BettingCoin.num;
                int loseCoin = int.Parse(Player1Coin.tx_p1Coin.text);
                coinUpdate(Player2ID.player2ID, winCoin);
                coinUpdate(Player1ID.player1ID, loseCoin);
                Invoke("onLeftRoom", 2);
            }
            else{
                tx_result.text = "무승부";
                Invoke("onLeftRoom", 2);
            }
        }
    }

    public void init_Game() {
        Player1Button.p1state = false;
        Player2Button.p2state = false;
        BettingCoin.num = 0;
    }
    
    public  void onLeftRoom() {
        init_Game();
        PhotonNetwork.Disconnect();
        PhotonNetwork.LoadLevel(0);
    }

    void coinUpdate(string playerID, int coin){
        string key;
        Debug.Log("playerID = "+playerID);
        FirebaseDatabase.DefaultInstance
        .GetReference("member")
        .OrderByChild("id").EqualTo(playerID)
        .GetValueAsync().ContinueWith(task => {
            if (task.IsFaulted)
          {
          }
          else if (task.IsCompleted)
          {
              DataSnapshot snapshot = task.Result;
              foreach(var child in snapshot.Children)
              {
                  key = child.Key;
                  updateCoin(key, coin);
              }
          }
      });
    }
    void updateCoin(string key, int coin){
        Dictionary<string, object> childUpdates = new Dictionary<string, object>();
        childUpdates["/member/" + key + "/" + "coin"] = coin;
 
        reference.UpdateChildrenAsync(childUpdates);
    }

   public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        try
        {
            if (stream.IsWriting)
            {
                stream.SendNext(Player1Button.p1state);
                stream.SendNext(Player2Button.p2state);

                stream.SendNext(P1CardNumber.p1Num);
                stream.SendNext(P2CardNumber.p2Num);

                stream.SendNext(Player1Name.tx_p1Name.text);
                stream.SendNext(Player2Name.tx_p2Name.text);

                stream.SendNext(tx_result.text);
                
                stream.SendNext(Player1ID.player1ID);
                stream.SendNext(Player2ID.player2ID);
                stream.SendNext(BettingCoin.num);
            }
            else
            {
                Player1Button.p1state = (bool)stream.ReceiveNext();
                Player2Button.p2state = (bool)stream.ReceiveNext();

                P1CardNumber.p1Num = (int)stream.ReceiveNext();
                P2CardNumber.p2Num = (int)stream.ReceiveNext();

                Player1Name.p1Name = (string)stream.ReceiveNext();
                Player2Name.p2Name = (string)stream.ReceiveNext();

                tx_result.text = (string)stream.ReceiveNext();
                
                Player1ID.player1ID = (string)stream.ReceiveNext();
                Player2ID.player2ID = (string)stream.ReceiveNext();
                BettingCoin.num = (int)stream.ReceiveNext();
            }
        }
        catch (System.NullReferenceException)
        {

        }
    }
}
