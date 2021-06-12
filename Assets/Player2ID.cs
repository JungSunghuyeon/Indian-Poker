using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System;

public class Player2ID : MonoBehaviourPunCallbacks, IPunObservable
{
    Text tx_player2ID;
    public static string player2ID;
    // Start is called before the first frame update
    void Start()
    {
        tx_player2ID = GetComponent<Text>();
        player2ID = Login.player_id;
        tx_player2ID.text = player2ID;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {


        if (stream.IsWriting)
        {
            try
            {
                stream.SendNext(player2ID);
                stream.SendNext(tx_player2ID.text);
                
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
                player2ID = (string)stream.ReceiveNext();
                tx_player2ID.text = (string)stream.ReceiveNext();
                
            }
            catch (NullReferenceException ex)
            {
                Debug.Log("");
            }
        }


    }
}
