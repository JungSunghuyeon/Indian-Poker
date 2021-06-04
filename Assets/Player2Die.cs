using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Player2Die : MonoBehaviourPunCallbacks, IPunObservable
{
    
    public static Button btn_p2die;
    void Start()
    {
        btn_p2die = GetComponent<Button>();
        btn_p2die.onClick.AddListener(p2Die);
    }

    public void p2Die(){
       
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        if(stream.IsWriting) 
        {
       

           
   
        }
        else 
        {
  
      
           
        }
    }
}
