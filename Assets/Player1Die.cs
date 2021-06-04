using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Player1Die : MonoBehaviourPunCallbacks, IPunObservable
{
    public static Button btn_p1die;
    void Start()
    {
        btn_p1die = GetComponent<Button>();
        btn_p1die.onClick.AddListener(p1Die);
    }

    public void p1Die(){
        
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
