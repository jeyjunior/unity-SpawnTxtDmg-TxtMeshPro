using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class txtDmg : MonoBehaviour
{
    public int value;
    public TextMeshPro text;

    public bool crit;
    public int textShow;

    Rigidbody2D rb2d;
    public GameObject imgBG;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = Random.Range(-0.4f, -0.8f);

        if (crit)
        {
            text.color = Color.white;
            imgBG.SetActive(true);
        }
        else
        {
            text.color = Color.yellow;
        }

        text.text = value.ToString();
        Invoke("DestroyThis", 1);
    }


    private void Update()
    {
        text.text = textShow.ToString();
    }

    void DestroyThis(){
        Destroy(this.gameObject);
    }
}
