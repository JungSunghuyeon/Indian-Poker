using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class BettingCoin : MonoBehaviourPunCallbacks, IPunObservable
{
    public static Text tx_betcoin;
    public static int num = 0;
    void Start()
    {
        tx_betcoin = GetComponent<Text>();
        
    }
     void Update() {
        tx_betcoin.text = num.ToString();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(num);
            stream.SendNext(tx_betcoin.text);
        }
        else
        {
            num = (int)stream.ReceiveNext();
            tx_betcoin.text = (string)stream.ReceiveNext();
        }
    }
}
