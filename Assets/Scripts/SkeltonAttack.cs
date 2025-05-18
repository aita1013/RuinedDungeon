using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeltonAttack : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float chaseRange = 8f;     // 追跡を始める距離
    [SerializeField] private float stopDistance = 2f;   // 攻撃を始める距離
    [SerializeField] private float attackInterval = 2f; // 攻撃の間隔
    private float attackTimer;

    private Animator animator;
    private AudioSource audioSource;

    [SerializeField] private Transform player;

    [SerializeField] private AudioClip attack1SE;
    [SerializeField] private AudioClip attack2SE;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // 向きの調整（左右反転）
        if (player.position.x > transform.position.x)
            transform.localScale = new Vector3(2f, 2f, 2f);
        else
            transform.localScale = new Vector3(-2f, 2f, 2f);

        // プレイヤーが追跡範囲内  プレイヤーの距離が最大距離に比べて小さいとき追う範囲にいる
        if (distanceToPlayer <= chaseRange)
        {
            if (distanceToPlayer > stopDistance)
            {
                MoveTowardsPlayer();       // 攻撃範囲外 → 近づく
                attackTimer = 0f;          // タイマーリセット
            }
            else
            {
                // 攻撃範囲内 → タイマーで攻撃間隔管理
                attackTimer += Time.deltaTime;
                if (attackTimer >= attackInterval)
                {
                    Attack();
                    attackTimer = 0f;
                }
            }
        }
        else
        {
            // プレイヤーが離れている → 何もしない
            attackTimer = 0f;
        }
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    void Attack()
    {
        int attackType = Random.Range(0, 2); // 0または1　スケルトンがプレイヤーに向かって行く

        if (attackType == 0)
        {
            animator.SetTrigger("IsSkeltonAttack1");
            audioSource.PlayOneShot(attack1SE);
        }
        else
        {
            animator.SetTrigger("IsSkeletonAttack2");
            audioSource.PlayOneShot(attack2SE);
        }

        Debug.Log("Skeletonが攻撃しました！");
    }
}
