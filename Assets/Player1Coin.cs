using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Player1Coin : MonoBehaviourPunCallbacks, IPunObservable
{
    Text tx_p1Coin;
    void Start()
    {
        tx_p1Coin = GetComponent<Text>();
        tx_p1Coin.text = Login.coin;
    }
     public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        try{
        if(stream.IsWriting) stream.SendNext(tx_p1Coin.text);
        else tx_p1Coin.text = (string)stream.ReceiveNext();
        }catch(System.NullReferenceException){
            
        }
    }

   
}
