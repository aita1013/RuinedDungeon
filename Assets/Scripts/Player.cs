using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour 
{
    public Rigidbody2D rd;
    private bool Grounded;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(1.7f,1.7f,1.7f);
            transform.position += new Vector3(0.1f,0,0);
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-1.7f,1.7f,1.7f);
            transform.position += new Vector3(-0.1f,0,0);
        }      

        if (Input.GetKeyDown(KeyCode.Space) && Grounded == true)
        {
            rd.AddForce(Vector2.up * 500);
        }
       }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Grounded = true;
        }
    
    }
    
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Ground")
        {
            Grounded = false;
        }
    }

}
