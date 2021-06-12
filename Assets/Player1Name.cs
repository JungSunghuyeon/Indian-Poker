using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System;

public class Player1Name : MonoBehaviourPunCallbacks, IPunObservable
{
    public static Text tx_p1Name;
    public static string p1Name;
    void Start()
    {
        tx_p1Name = GetComponent<Text>();
        if (PhotonNetwork.IsMasterClient)
        {
            p1Name = Login.name;
            tx_p1Name.text = p1Name;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if (stream.IsWriting)
        {
            try
            {
                stream.SendNext(p1Name);
                stream.SendNext(tx_p1Name.text);
                
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
                p1Name = (string)stream.ReceiveNext();
                tx_p1Name.text = (string)stream.ReceiveNext();
                
            }
            catch (NullReferenceException ex)
            {
                Debug.Log("");
            }
        }

    }
}
