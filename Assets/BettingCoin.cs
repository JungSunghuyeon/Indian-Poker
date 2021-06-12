using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System;

public class BettingCoin : MonoBehaviourPunCallbacks, IPunObservable
{
    public static Text tx_betcoin;
    public static int num = 0;
    void Start()
    {
        tx_betcoin = GetComponent<Text>();
        tx_betcoin.text = num.ToString();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            try{
            stream.SendNext(num);
            stream.SendNext(tx_betcoin.text);
            }
            catch (NullReferenceException ex)
            {
                Debug.Log("");
            }
        }
        else
        {
            try{
            num = (int)stream.ReceiveNext();
            tx_betcoin.text = (string)stream.ReceiveNext();
            }
            catch (NullReferenceException ex)
            {
                Debug.Log("");
            }
        }
    }
}
