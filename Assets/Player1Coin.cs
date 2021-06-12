using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System;

public class Player1Coin : MonoBehaviourPunCallbacks, IPunObservable
{
    public static Text tx_p1Coin;
    public static string p1Coin;
    void Start()
    {
        tx_p1Coin = GetComponent<Text>();
        if (PhotonNetwork.IsMasterClient)
        {
            p1Coin = Login.coin;
            tx_p1Coin.text = p1Coin;
        }


    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if (stream.IsWriting)
        {
            try
            {
                
                stream.SendNext(tx_p1Coin.text);
                stream.SendNext(p1Coin);
                
            }
            catch (NullReferenceException ex)
            {
                Debug.Log("");
            }
        }
        else
        {
            try
            {
                
                tx_p1Coin.text = (string)stream.ReceiveNext();
                p1Coin = (string)stream.ReceiveNext();
                
            }
            catch (NullReferenceException ex)
            {
                Debug.Log("");
            }
        }

    }


}
