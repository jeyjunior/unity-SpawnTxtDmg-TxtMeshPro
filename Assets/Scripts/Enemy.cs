using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    public GameObject lifeBar;

    public int life, maxLife = 1000;
    public int dmgReceive = 0;

    public Transform posTxtHit;
    public GameObject txtDmg;

    private void Start()
    {
        lifeBar.SetActive(true);

        lifeBar.GetComponent<Slider>().maxValue = maxLife;
        lifeBar.GetComponent<Slider>().minValue = 0;
        life = maxLife;
    }

    void Update()
    {
        lifeBar.GetComponent<Slider>().value = life;

        if(life <= 0)
        {
            life = maxLife;
        }
    }

    public void HitTake(int value, bool crit)
    {
        life -= value;
        txtDmg.GetComponent<txtDmg>().textShow = value;
        txtDmg.GetComponent<txtDmg>().crit = crit;

        Instantiate(txtDmg, posTxtHit.position, Quaternion.identity);
    }
}
