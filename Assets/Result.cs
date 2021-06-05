using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Result : MonoBehaviourPunCallbacks, IPunObservable
{
    public static Text tx_result;
 
    void Start()
    {
        tx_result = GetComponent<Text>();
        tx_result.text = " ";
        
    }

    void Update()
    {
        
       
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        try
        {
            if (stream.IsWriting)
            {
                stream.SendNext(tx_result.text);
            }
            else
            {
                tx_result.text = (string)stream.ReceiveNext();
            }
        }
        catch (System.NullReferenceException)
        {

        }
    }
}
