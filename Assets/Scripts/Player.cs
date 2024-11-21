using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEditor.Animations;
using UnityEngine;

public class Player : MonoBehaviour 
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    private Rigidbody2D rd;
    private bool Grounded;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(2f,2f,2f); //3Dの場合反転する必要があるから大きさを変換する処理を入れている(28要参照）
        
            transform.position += new Vector3(moveSpeed,0,0);
            animator.SetBool("isRunning",true);
        }
        else if(Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("isRunning",false);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-2f,2f,2f);
            transform.position += new Vector3(-moveSpeed,0,0);
            animator.SetBool("isRunning",true);
        }      
        else if(Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("isRunning",false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && Grounded == true)    //ジャンプは地面についているときじゃないとできないため、
        {
            rd.AddForce(Vector2.up * jumpSpeed);
            animator.SetBool("isJumping",true);
        }
       
       }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Grounded = true;    //地面についているときにtrue（ジャンプ可能）
            animator.SetBool("isJumping",false);
        }
    
    }
    
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Ground")
        {
            Grounded = false;   //地面から離れているときにfalse(ジャンプ不可)にする
        }
    }

}
