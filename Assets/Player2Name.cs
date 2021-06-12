using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System;

public class Player2Name : MonoBehaviourPunCallbacks, IPunObservable
{
    public static Text tx_p2Name;
    public static string p2Name;
    void Start()
    {
        tx_p2Name = GetComponent<Text>();
        if (!PhotonNetwork.IsMasterClient)
        {
            p2Name = Login.name;
            tx_p2Name.text = p2Name;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {


        if (stream.IsWriting)
        {
            try
            {
                stream.SendNext(p2Name);
                stream.SendNext(tx_p2Name.text);
                
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
                p2Name = (string)stream.ReceiveNext();
                tx_p2Name.text = (string)stream.ReceiveNext();
                
               
            }
            catch (NullReferenceException ex)
            {
                Debug.Log("");
            }
        }


    }
}
