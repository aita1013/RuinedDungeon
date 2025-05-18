using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeltonHP : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int maxHP = 200;
    int currentHp;
    public Slider slider;
    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
        slider.value = 1;
        currentHp = maxHP;


    }
    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "PlayerAttack")
        {
            int damage = 50;
            currentHp = currentHp - damage;
            slider.value = (float)currentHp / (float)maxHP;
            if (currentHp <= 0)
            {
                animator.SetBool("IsDead", true);
                Destroy(gameObject,3.0f); 
            }
        
        }



    }


}
