using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Animator anim;
    public bool isAtk = false;
    public float delayAtk = 0, atkTimeDuration;

    //hitbox
    public Transform hitBox;
    public float rangeHitBox = 0.6f;
    public LayerMask enemiesLayers;

    private void Start()
    {
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
            i.GetComponent<Enemy>().HitTake(100);
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(hitBox.position, rangeHitBox);
    }
}
