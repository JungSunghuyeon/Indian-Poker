using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Player2Name : MonoBehaviourPunCallbacks, IPunObservable
{
    Text tx_p2Name;
    void Start()
    {
        tx_p2Name = GetComponent<Text>();
        tx_p2Name.text = Login.name;
    }

     public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        
        try{
            if(stream.IsWriting) stream.SendNext(tx_p2Name.text);
        else tx_p2Name.text = (string)stream.ReceiveNext();
        }catch(System.NullReferenceException){
            
        }
    }
}
