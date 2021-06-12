using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Firebase;
using Firebase.Database;
using UnityEngine.SceneManagement;

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

    public void Update()
    {
        if (Player1Button.p1state == true && Player2Button.p2state == true)
        {
            Disable();
            if (P1CardNumber.p1Num > P2CardNumber.p2Num)
            {
                if(PhotonNetwork.IsMasterClient){
                    tx_result.text = "승리";
                }
                else{
                    tx_result.text = "패배";
                }
                Player1Coin.tx_p1Coin.text = (Player1Button.p1usercoin + BettingCoin.num).ToString();
                int winCoin = Player1Button.p1usercoin + BettingCoin.num;
                int loseCoin = Player2Button.p2usercoin;
                Player1Coin.tx_p1Coin.text = winCoin.ToString();
                coinUpdate(Player1ID.player1ID, winCoin);
                coinUpdate(Player2ID.player2ID, loseCoin);
                
            }
            else if (P1CardNumber.p1Num < P2CardNumber.p2Num)
            {
                 if(!PhotonNetwork.IsMasterClient){
                    tx_result.text = "승리";
                }
                else{
                    tx_result.text = "패배";
                }
                int winCoin = Player2Button.p2usercoin + BettingCoin.num;
                int loseCoin = Player1Button.p1usercoin;
                Player2Coin.tx_p2Coin.text = winCoin.ToString();
                coinUpdate(Player2ID.player2ID, winCoin);
                coinUpdate(Player1ID.player1ID, loseCoin);
            }
            else
            {
                if(!PhotonNetwork.IsMasterClient || PhotonNetwork.IsMasterClient){
                    tx_result.text = "무승부";
                }
            }

           Invoke("LeftRoom", 2f);
        }
    }
    public void LeftRoom(){
        if(photonView.IsMine){
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("Lobby");
        }
      
    }

    public void Disable()
    {
        Player1Button.btn_p1call.interactable = false;
        Player1Button.btn_p1half.interactable = false;
        Player1Button.btn_p1die.interactable = false;

        Player2Button.btn_p2call.interactable = false;
        Player2Button.btn_p2half.interactable = false;
        Player2Button.btn_p2die.interactable = false;
    }


    void coinUpdate(string playerID, int coin)
    {
        string key;
        FirebaseDatabase.DefaultInstance
        .GetReference("member")
        .OrderByChild("id").EqualTo(playerID)
        .GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                foreach (var child in snapshot.Children)
                {
                    key = child.Key;
                    updateCoin(key, coin);
                }
            }
        });
    }
    void updateCoin(string key, int coin)
    {
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
                stream.SendNext(tx_result.text);
                stream.SendNext(Player1ID.player1ID);
                stream.SendNext(Player2ID.player2ID);
                stream.SendNext(BettingCoin.num);
                stream.SendNext(Player1Button.btn_p1call.interactable);
                stream.SendNext(Player1Button.btn_p1half.interactable);
                stream.SendNext(Player1Button.btn_p1die.interactable);
                stream.SendNext(Player2Button.btn_p2call.interactable);
                stream.SendNext(Player2Button.btn_p2half.interactable);
                stream.SendNext(Player2Button.btn_p2die.interactable);
                stream.SendNext(Player1Button.p1usercoin); 
                stream.SendNext(Player2Button.p2usercoin); 
                stream.SendNext(Player1Coin.tx_p1Coin.text); 
                stream.SendNext(Player2Coin.tx_p2Coin.text); 

            }
            else
            {
                Player1Button.p1state = (bool)stream.ReceiveNext();
                Player2Button.p2state = (bool)stream.ReceiveNext();
                P1CardNumber.p1Num = (int)stream.ReceiveNext();
                P2CardNumber.p2Num = (int)stream.ReceiveNext();
                tx_result.text = (string)stream.ReceiveNext();
                Player1ID.player1ID = (string)stream.ReceiveNext();
                Player2ID.player2ID = (string)stream.ReceiveNext();
                BettingCoin.num = (int)stream.ReceiveNext();
                Player1Button.btn_p1call.interactable = (bool)stream.ReceiveNext();
                Player1Button.btn_p1half.interactable = (bool)stream.ReceiveNext();
                Player1Button.btn_p1die.interactable = (bool)stream.ReceiveNext();
                Player2Button.btn_p2call.interactable = (bool)stream.ReceiveNext();
                Player2Button.btn_p2half.interactable = (bool)stream.ReceiveNext();
                Player2Button.btn_p2die.interactable = (bool)stream.ReceiveNext();
                Player1Button.p1usercoin = (int)stream.ReceiveNext();
                Player2Button.p2usercoin = (int)stream.ReceiveNext();
                Player1Coin.tx_p1Coin.text = (string)stream.ReceiveNext();
                Player2Coin.tx_p2Coin.text = (string)stream.ReceiveNext();
            }
        }
        catch (System.InvalidCastException)
        {
            Debug.Log("ㅁㄴㅇㅁㅇ");
        }
    }
}
