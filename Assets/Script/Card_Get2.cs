using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Card_Get2 : MonoBehaviourPunCallbacks, IPunObservable
{

    private Image img_card;
    Common_Card card = new Common_Card();
    // Start is called before the first frame update
    
    [SerializeField]
    private Sprite[] sprites;
    static int p_card=0;
    void Start()
    {
        img_card = GetComponent<Image>();
        p_card = card.start_card();
        Invoke("Show_Card",2);
    }

    void Update() {
       
         
    }

    void Show_Card() {
        img_card.sprite = sprites[p_card-1];
            
    }

    public int txt_card_transport(){
        return p_card;
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