using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ← シーン切り替えに必要！

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] int maxHP = 3;
    [SerializeField] SpriteRenderer[] hearts;
    int currentHp;

    void Start()
    {
        currentHp = maxHP;
        RefreshHpUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (currentHp < maxHP)
            {
                currentHp++;
                RefreshHpUI();
                Debug.Log("HP回復 現在のHP: " + currentHp);
            }
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (currentHp < maxHP)
            {
                currentHp = maxHP; // HPを最大に回復
                RefreshHpUI();
                Debug.Log("HP全回復 現在のHP: " + currentHp);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "SkeletonAttack")
        {
            Debug.Log("攻撃を受けた");

            int damage = 1;
            currentHp -= damage;

            if (currentHp < 0)
                currentHp = 0;

            RefreshHpUI();

            // ★ HPが0になったらGameOverシーンに移動
            if (currentHp == 0)
            {
                Debug.Log("プレイヤー死亡GameOverシーンへ");
                SceneManager.LoadScene("GameOver"); // ← シーン名に注意！
            }
        }
    }

    private void RefreshHpUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHp)
            {
                hearts[i].color = new Color32(255, 0, 0, 255); // 表示
            }
            else
            {
                hearts[i].color = new Color32(255, 0, 0, 0);   // 非表示
            }
        }

    }
    void OnTriggerExit2D(Collider2D collider2D)
    {
        Debug.Log(collider2D.gameObject.tag);
    }
}
