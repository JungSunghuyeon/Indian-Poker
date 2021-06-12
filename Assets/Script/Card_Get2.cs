using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System;

public class Card_Get2 : MonoBehaviourPunCallbacks, IPunObservable
{

    Image img_card;
    Common_Card card = new Common_Card();
    // Start is called before the first frame update

    [SerializeField]
    private Sprite[] sprites;
    public static int p_card = 0;
    void Start()
    {

        img_card = GetComponent<Image>();
        img_card.sprite = Resources.Load<Sprite>("Images/back");
        p_card = card.start_card();
        if (PhotonNetwork.IsMasterClient)
        {
            Invoke("Show_Card", 2);
        }
    }

    void Update()
    {
        if (Player1Button.p1state == true && Player2Button.p2state == true)
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                Show_Card();
            }
        }
    }


    void Show_Card()
    {
        img_card.sprite = sprites[p_card - 1];

    }

    public static int txt_card_transport()
    {
        return p_card;
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            try
            {
                stream.SendNext(p_card);
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
                p_card = (int)stream.ReceiveNext();
            }
            catch (NullReferenceException ex)
            {
                Debug.Log("");
            }
        }
    }

}