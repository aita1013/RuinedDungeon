using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackColliderController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D boxCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name=="PlayerAttack")
        {
            boxCollider2D.enabled = true;
        }
        
        else if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name=="PlayerAttack2")
        {
            boxCollider2D.enabled = true;
        }
        else
        {
            boxCollider2D.enabled = false;
        }
    }
    
}
