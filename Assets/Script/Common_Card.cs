using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Common_Card : MonoBehaviour
{
    int num=0;
   // Start is called before the first frame update
    Card card = new Card();
    public int start_card()
    {
        
        card.create();
        try {
           num = card.deal();

        } catch(System.Exception e) {
            // 
        }
     return num;   
    }
    

}
