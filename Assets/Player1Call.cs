using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Player1Call : MonoBehaviourPunCallbacks, IPunObservable
{
    Button btn_p1call;
    public static int p1bet;

    void Start()
    {
        btn_p1call = GetComponent<Button>();
        btn_p1call.onClick.AddListener(p1Call);
    }
    public void p1Call(){
        if(int.Parse(Count.tx_count.text) == 0){
            p1bet = 1;
            BettingCoin.num += p1bet;
            BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
        }
        else{
            p1bet = Player2Call.p2bet;
            BettingCoin.num += p1bet;
            BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
        }
        Count.count++;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        if(stream.IsWriting) stream.SendNext(BettingCoin.tx_betcoin.text);
        else BettingCoin.tx_betcoin.text = (string)stream.ReceiveNext();
    }
}
