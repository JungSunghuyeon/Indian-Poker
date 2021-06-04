using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Player1Half : MonoBehaviourPunCallbacks, IPunObservable
{
    public static Button btn_p1half;

    void Start()
    {
        btn_p1half = GetComponent<Button>();
        btn_p1half.onClick.AddListener(p1Half);
    }

      public void p1Half(){
        if(BettingCoin.num == 0){
        Player1Call.p1bet = 2;
        BettingCoin.num += Player1Call.p1bet;
        BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
        }
        else{
            Player1Call.p1bet = Player2Call.p2bet + 2;
            BettingCoin.num +=  Player1Call.p1bet;
            BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
        }
        
    }
     public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        if(stream.IsWriting) 
        {
       
          
           

            stream.SendNext(Player1Call.p1bet);
            stream.SendNext(Player2Call.p2bet);
  
            stream.SendNext(BettingCoin.num);
            stream.SendNext(BettingCoin.tx_betcoin.text);
           
        }
        else 
        {
            
        

            Player1Call.p1bet = (int)stream.ReceiveNext();
            Player2Call.p2bet = (int)stream.ReceiveNext();

            BettingCoin.num = (int)stream.ReceiveNext();
            BettingCoin.tx_betcoin.text = (string)stream.ReceiveNext();
           
        }
    }
}
