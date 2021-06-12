using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Player1Name : MonoBehaviourPunCallbacks, IPunObservable
{
    public static Text tx_p1Name;
    public static string p1Name;
    void Start()
    {
        tx_p1Name = GetComponent<Text>();
        if(PhotonNetwork.IsMasterClient){
            p1Name = Login.name;
            tx_p1Name.text = p1Name;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        try
        {
            if (stream.IsWriting)
            {
                stream.SendNext(tx_p1Name.text);
                stream.SendNext(p1Name);
            }
            else
            {
                tx_p1Name.text = (string)stream.ReceiveNext();
                p1Name = (string)stream.ReceiveNext();
            }
        }
        catch (System.NullReferenceException)
        {

        }
    }
}
