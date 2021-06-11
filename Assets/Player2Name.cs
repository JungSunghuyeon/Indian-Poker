using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Player2Name : MonoBehaviourPunCallbacks, IPunObservable
{
    public static Text tx_p2Name;
    public static string p2Name;
    void Start()
    {
        tx_p2Name = GetComponent<Text>();
        p2Name = Login.name;
        tx_p2Name.text = p2Name;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        try
        {
            if (stream.IsWriting)
            {
                stream.SendNext(tx_p2Name.text);
             
                stream.SendNext(Login.name);
                
            }
            else
            {
                tx_p2Name.text = (string)stream.ReceiveNext();
                
                Login.name = (string)stream.ReceiveNext();
                

            }
        }
        catch (System.NullReferenceException)
        {

        }
    }
}
