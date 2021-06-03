using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{

    void Start()
    {
        if(PhotonNetwork.IsMasterClient){
            PhotonNetwork.Instantiate("Player1", Vector3.zero, Quaternion.identity);
        }
        else if (!PhotonNetwork.IsMasterClient){
            PhotonNetwork.Instantiate("Player2", Vector3.zero, Quaternion.identity);
        }
    }
}

