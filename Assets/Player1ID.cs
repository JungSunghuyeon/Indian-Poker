using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System;

public class Player1ID : MonoBehaviourPunCallbacks, IPunObservable
{
    Text tx_player1ID;
    public static string player1ID;
    // Start is called before the first frame update
    void Start()
    {
        tx_player1ID = GetComponent<Text>();
        player1ID = Login.player_id;
        tx_player1ID.text = player1ID;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if (stream.IsWriting)
        {
            try
            {
                stream.SendNext(player1ID);
                stream.SendNext(tx_player1ID.text);
                
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
                player1ID = (string)stream.ReceiveNext();
                tx_player1ID.text = (string)stream.ReceiveNext();
                
            }
            catch (NullReferenceException ex)
            {
                Debug.Log("");
            }
        }

    }
}
