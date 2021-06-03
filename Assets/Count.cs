using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Count : MonoBehaviourPunCallbacks, IPunObservable
{
    public static Text tx_count;
    public static int count = 0;
    void Start()
    {
        tx_count = GetComponent<Text>();
        tx_count.text = count.ToString();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        if(stream.IsWriting) stream.SendNext(tx_count.text);
        else tx_count.text = (string)stream.ReceiveNext();
    }
}
