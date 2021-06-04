using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;



public class GameManager : MonoBehaviourPunCallbacks
{

    public void Start()
    {
        
        if(PhotonNetwork.IsMasterClient){
            PhotonNetwork.Instantiate("Player1", Vector3.zero, Quaternion.identity);
        }
        else if (!PhotonNetwork.IsMasterClient){
            PhotonNetwork.Instantiate("Player2", Vector3.zero, Quaternion.identity);
            PhotonNetwork.Instantiate("Player1_Card", Vector3.zero, Quaternion.identity);
            PhotonNetwork.Instantiate("Player2_Card", Vector3.zero, Quaternion.identity);

        }
        
    }


 
}

