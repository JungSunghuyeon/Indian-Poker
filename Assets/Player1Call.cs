using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Player1Call : MonoBehaviourPunCallbacks, IPunObservable
{
    public static Button btn_p1call;
    public static int p1bet;
    

    void Start()
    {
        btn_p1call = GetComponent<Button>();
        btn_p1call.onClick.AddListener(p1Call);
 
    }

    public void p1Call(){
        if(BettingCoin.num == 0){
        p1bet = 1;
        BettingCoin.num += p1bet;
        BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
        }
        else{
            p1bet = Player2Call.p2bet;
            BettingCoin.num += p1bet;
            BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
        }
       
    }

     public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        if(stream.IsWriting) 
        {
        

            stream.SendNext(p1bet);
            stream.SendNext(Player2Call.p2bet);

            stream.SendNext(BettingCoin.num);
            stream.SendNext(BettingCoin.tx_betcoin.text);
            
        }
        else 
        {
           


            p1bet = (int)stream.ReceiveNext();
            Player2Call.p2bet = (int)stream.ReceiveNext();

            BettingCoin.num = (int)stream.ReceiveNext();
            BettingCoin.tx_betcoin.text = (string)stream.ReceiveNext();
          
        }
    }

}
