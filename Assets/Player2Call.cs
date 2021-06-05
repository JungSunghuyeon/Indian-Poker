using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Player2Call : MonoBehaviourPunCallbacks, IPunObservable
{
    public static Button btn_p2call;
    public static int p2bet;
    //public static bool p2callstate = false;
    void Start()
    {
        btn_p2call = GetComponent<Button>();
        btn_p2call.onClick.AddListener(p2Call);
    }

    public void p2Call()
    {
        if (BettingCoin.num == 0)
        {
            p2bet = 1;
            BettingCoin.num += p2bet;
            BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
        }
        else
        {
            p2bet = Player1Call.p1bet;
            BettingCoin.num += p2bet;
            BettingCoin.tx_betcoin.text = BettingCoin.num.ToString();
        }
        //p2callstate = true;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {


            stream.SendNext(p2bet);
            stream.SendNext(Player1Call.p1bet);

            stream.SendNext(BettingCoin.num);
            stream.SendNext(BettingCoin.tx_betcoin.text);

            //stream.SendNext(p2callstate);

        }
        else
        {
            p2bet = (int)stream.ReceiveNext();
            Player1Call.p1bet = (int)stream.ReceiveNext();

            BettingCoin.num = (int)stream.ReceiveNext();
            BettingCoin.tx_betcoin.text = (string)stream.ReceiveNext();
            
            //p2callstate = (bool)stream.ReceiveNext();
        }
    }

}
