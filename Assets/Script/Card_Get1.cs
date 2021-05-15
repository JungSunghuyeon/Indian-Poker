using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card_Get1 : MonoBehaviour
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

    }

    void Update() {
        Invoke("Show_Card",2);
         
    }

    void Show_Card() {
        img_card.sprite = sprites[p_card-1];
            
    }

    public int txt_card_transport(){
        return p_card;
    }

}