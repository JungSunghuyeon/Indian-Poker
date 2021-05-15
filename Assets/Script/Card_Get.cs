using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card_Get : MonoBehaviour
{

    private Image img_card;
    public int txt_card;
    Common_Card card = new Common_Card();
    // Start is called before the first frame update
    int p_card = 0;

    [SerializeField]
    private Sprite[] sprites;

    private int index;
    void Start()
    {
        img_card = GetComponent<Image>();
        p_card = card.start_card();

    }

    void Update() {
        Invoke("Show_Card",2);
         
    }

    void Show_Card() {
        img_card.sprite = sprites[p_card-1];
            
    }

    public int txt_card_transport(){
        txt_card = card.start_card();
        return txt_card;
    }

}