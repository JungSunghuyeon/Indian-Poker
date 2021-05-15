using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common_Card : MonoBehaviour
{
   // Start is called before the first frame update
    Card card = new Card();
    public int start_card()
    {
        int num=0;
        card.create();
        try {
           num = card.deal();

        } catch(System.Exception e) {
            // 
        }
     return num;   
    }

}
