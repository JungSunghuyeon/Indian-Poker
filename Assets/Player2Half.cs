using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


public class Player2Half : MonoBehaviourPunCallbacks, IPunObservable
{
    
    public static Button btn_p2half;

    void Start()
    {
        btn_p2half = GetComponent<Button>();
        btn_p2half.onClick.AddListener(p2Half);
    }

      public void p2Half(){
        if(BettingCoin.num== 0){
        Player2Call.p2bet = 2;
        BettingCoin.num += Player2Call.p2bet;
        BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
        }
        else{
            Player2Call.p2bet = Player1Call.p1bet + 2;
            BettingCoin.num += Player2Call.p2bet;
            BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
        }
       
    }
     public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        if(stream.IsWriting) 
        {

           
       

            stream.SendNext(Player2Call.p2bet);
            stream.SendNext(Player1Call.p1bet);

            stream.SendNext(BettingCoin.num);
            stream.SendNext(BettingCoin.tx_betcoin.text);
           
        }
        else 
        {

         
        

            Player2Call.p2bet = (int)stream.ReceiveNext();
            Player1Call.p1bet = (int)stream.ReceiveNext();

            BettingCoin.num = (int)stream.ReceiveNext();
            BettingCoin.tx_betcoin.text = (string)stream.ReceiveNext();
            
        }
    }
}
