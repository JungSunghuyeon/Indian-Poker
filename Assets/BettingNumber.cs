using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Player1BettingNumber : MonoBehaviourPunCallbacks, IPunObservable
{
     public static Text tx_p1betnum;
     public static int p1betnum = 0;
    void Start()
    {
        tx_p1betnum = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        tx_p1betnum.text = p1betnum.ToString();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        if(stream.IsWriting) 
        {
            stream.SendNext(p1betnum);
            stream.SendNext(tx_p1betnum.text);
        }
        else 
        {
            p1betnum = (int)stream.ReceiveNext();
            tx_p1betnum.text = (string)stream.ReceiveNext();
        }
    }
}
