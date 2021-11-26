using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    Animator anim;
    public bool isAtk = false;
    public float delayAtk = 0, atkTimeDuration;

    //hitbox
    public Transform hitBox;
    public float rangeHitBox = 0.6f;
    public LayerMask enemiesLayers;

    //Crit dmg
    public float critRate = 1, maxDmg;

    //atk and crit controll (player)
    public Slider critRateSlider, maxDmgSlider;
    public Text critRateText, maxDmgText;

    private void Start()
    {
        //Sliders controll
        critRateSlider.maxValue = 100;
        maxDmgSlider.maxValue = 100;
        maxDmgSlider.value = 10;

        anim = GetComponent<Animator>();
        AnimationClip[] clipsAnim = anim.runtimeAnimatorController.animationClips;

        foreach(AnimationClip clip in clipsAnim)
        {
            if(clip.name == "playerAtk")
            {
                atkTimeDuration = clip.length;
            }
        }
    }

    private void Update()
    {
        if(delayAtk <= 0)
        {
            isAtk = false;
            delayAtk = 0;
        }
        else
        {
            delayAtk -= Time.deltaTime;
            isAtk = true;
        }

        SliderControll();
    }

    public void Atk() {

        if (!isAtk)
        {
            anim.Play("playerAtk");
            delayAtk = atkTimeDuration;

            HitBox();
        }
    }

    void HitBox()
    {
        //Detectar inimigos na range do atk
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(hitBox.position, rangeHitBox, enemiesLayers);
        foreach (Collider2D i in hitEnemies)
        {
            //Gera dano aleatorio
            int dmg = Mathf.RoundToInt(Random.Range(maxDmg / 1.2f, maxDmg));

            int x = Random.Range(0, 101);

            if(x <= critRate) i.GetComponent<Enemy>().HitTake(dmg * 2, true);
            else i.GetComponent<Enemy>().HitTake(dmg, false);

        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(hitBox.position, rangeHitBox);
    }


    //CONTROLES CRIT RATE MAX ATK
    void SliderControll()
    {
        critRate = critRateSlider.value;
        critRateText.text = $"Crit rate: {Mathf.RoundToInt(critRateSlider.value)}";

        maxDmg = maxDmgSlider.value;
        maxDmgText.text = $"Max dmg: {Mathf.RoundToInt(maxDmgSlider.value)}";
    }


}
