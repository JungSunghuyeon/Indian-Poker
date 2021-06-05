using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Player1Name : MonoBehaviourPunCallbacks, IPunObservable
{
    Text tx_p1Name;
    public static string p1Name;
    void Start()
    {
        tx_p1Name = GetComponent<Text>();
        p1Name = Login.name;
        tx_p1Name.text = p1Name;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        try
        {
            if (stream.IsWriting)
            {
                stream.SendNext(tx_p1Name.text);
        
                stream.SendNext(Login.name);
                
            }
            else
            {
                tx_p1Name.text = (string)stream.ReceiveNext();
          
                Login.name = (string)stream.ReceiveNext();
               

            }
        }
        catch (System.NullReferenceException)
        {

        }
    }
}
