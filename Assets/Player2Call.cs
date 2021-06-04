using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Player2Call : MonoBehaviourPunCallbacks, IPunObservable
{
    public static Button btn_p2call;
    public static int p2bet;
    void Start()
    {
        btn_p2call = GetComponent<Button>();
        btn_p2call.onClick.AddListener(p2Call);
    }

    public void p2Call(){
        if(BettingCoin.num == 0){
        p2bet = 1;
        BettingCoin.num += p2bet;
        BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
        }
        else{
            p2bet = Player1Call.p1bet;
            BettingCoin.num += p2bet;
            BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
        }
         Player2Call.btn_p2call.interactable = false;
        Player2Half.btn_p2half.interactable = false;
        Player2Die.btn_p2die.interactable = false;

        Player1Call.btn_p1call.interactable = true;
        Player1Half.btn_p1half.interactable = true;
        Player1Die.btn_p1die.interactable = true;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        if(stream.IsWriting) 
        {
           

            stream.SendNext(p2bet);
            stream.SendNext(Player1Call.p1bet);

            stream.SendNext(BettingCoin.num);
            stream.SendNext(BettingCoin.tx_betcoin.text);
         
        }
        else 
        {
           

            p2bet = (int)stream.ReceiveNext();
            Player1Call.p1bet = (int)stream.ReceiveNext();
   
            BettingCoin.num = (int)stream.ReceiveNext();
            BettingCoin.tx_betcoin.text = (string)stream.ReceiveNext();
           
        }
    }

}
