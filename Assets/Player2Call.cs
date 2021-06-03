using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Player2Call : MonoBehaviourPunCallbacks, IPunObservable
{
    
    Button btn_p2call;
    public static int p2bet;

    void Start()
    {
        btn_p2call = GetComponent<Button>();
        btn_p2call.onClick.AddListener(p2Call);
    }
    public void p2Call(){
        if(int.Parse(Count.tx_count.text) == 0){
            p2bet = 1;
            BettingCoin.num += p2bet;
            BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
        }
          else{
            p2bet = Player1Call.p1bet;
            BettingCoin.num += p2bet;
            BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
        }
        Count.count++;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        if(stream.IsWriting) stream.SendNext(BettingCoin.tx_betcoin.text);
        else BettingCoin.tx_betcoin.text = (string)stream.ReceiveNext();
    }
}
