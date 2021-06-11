using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

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

        try
        {
            if (stream.IsWriting)
            {
                stream.SendNext(tx_player2ID.text);
             
                stream.SendNext(player2ID);
                
            }
            else
            {
                tx_player2ID.text = (string)stream.ReceiveNext();
                
                player2ID = (string)stream.ReceiveNext();
                

            }
        }
        catch (System.NullReferenceException)
        {

        }
    }
}
