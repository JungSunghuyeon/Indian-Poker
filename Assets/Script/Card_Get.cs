using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card_Get : MonoBehaviour
{

    private Image img_card;
    Button btn_card1;
    Card card = new Card();
    // Start is called before the first frame update
    int p1_card = 0;
    int p2_card = 0;
    [SerializeField]
    private Sprite[] sprites;

    private int index;
    void Start()
    {
        img_card = GetComponent<Image>();
        card.create();
        p1_card = card.deal();
    }

  

    void Update() {
        Invoke("Show_Card",2);
         
    }

    void Show_Card() {
        img_card.sprite = sprites[p1_card];    
    }

}
