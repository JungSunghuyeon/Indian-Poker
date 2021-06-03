using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Player2Coin : MonoBehaviourPunCallbacks, IPunObservable
{
    Text tx_p2Coin;
    void Start()
    {
        tx_p2Coin = GetComponent<Text>();
        tx_p2Coin.text = Login.coin;
    }
     public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        try{
        if(stream.IsWriting) stream.SendNext(tx_p2Coin.text);
        else tx_p2Coin.text = (string)stream.ReceiveNext();
        }catch(System.NullReferenceException){
            
        }
    }

}
