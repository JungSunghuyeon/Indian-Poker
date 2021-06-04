using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class P2CardNumber : MonoBehaviourPunCallbacks, IPunObservable
{
    Text tx_p2Num;
    int p2Num;
    void Start()
    {
        tx_p2Num = GetComponent<Text>();
        p2Num = Card_Get2.txt_card_transport()+1;
    }

     void Update() {
        tx_p2Num.text = p2Num.ToString();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        if(stream.IsWriting) {
           stream.SendNext(p2Num);
            stream.SendNext(tx_p2Num.text);
        }
        else {
           p2Num = (int)stream.ReceiveNext();
           tx_p2Num.text = (string)stream.ReceiveNext();
        }
    }
}
