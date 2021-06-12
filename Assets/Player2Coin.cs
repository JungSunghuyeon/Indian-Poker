using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Player2Coin : MonoBehaviourPunCallbacks, IPunObservable
{
    public static Text tx_p2Coin;
    public static string p2Coin;
    void Start()
    {
        tx_p2Coin = GetComponent<Text>();
        if(!PhotonNetwork.IsMasterClient){
        p2Coin = Login.coin;
        tx_p2Coin.text = p2Coin;
        }
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        try
        {
            if (stream.IsWriting)
            {
                stream.SendNext(tx_p2Coin.text);
                stream.SendNext(p2Coin);
            }

            else
            {
                tx_p2Coin.text = (string)stream.ReceiveNext();
                p2Coin = (string)stream.ReceiveNext();
            }
        }
        catch (System.NullReferenceException)
        {

        }
    }

}
