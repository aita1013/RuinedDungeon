using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeltonHP : MonoBehaviour
{
    // Start is called before the first frame update
    int maxHP = 155;
    int currentHp;
    public Slider slider;
    
    
    void Start()
    {
        slider.value = 1;
        currentHp = maxHP; 
    }
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("OK");
        if(collider.gameObject.tag == "PlayerAttack")
        {
            int damage = 50;
            currentHp = currentHp - damage;
            slider.value = (float)currentHp / (float)maxHP;
            
        }
    }
    
   
}
