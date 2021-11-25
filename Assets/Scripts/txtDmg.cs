using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class txtDmg : MonoBehaviour
{
    public int value;
    public TextMeshPro text;
    public int textShow;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = Random.Range(-0.2f, -0.5f);

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
