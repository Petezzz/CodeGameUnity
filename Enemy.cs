using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float checkDistance = 8.0f;
    public float attackDistance = 5.0f;
    Vector3 direction;
    private Animator animator;
    private bool dead = false;
    public int hp = 2;
    public GameObject itemToDrop;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            hp--;
        }
    }
    void Update()
    {
        direction = player.position - this.transform.position;
        direction.y = 0;

        if (Vector3.Distance(player.position, this.transform.position) < checkDistance && !dead)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            if(direction.magnitude >= attackDistance)
            {
                animator.SetBool("isAttacking", true);

                if (Input.GetButtonDown("Fire1"))
                {
                    animator.SetBool("isHitting", true);
                    hp--;
                    if (hp <= 0)
                    {
                        animator.SetBool("isHitting", true);
                        dead = true;
                        DropItem();
                    }
                    else
                    {
                        animator.SetBool("isWalking", true);
                        animator.SetBool("isAttacking", true);
                        animator.SetBool("isHitting", false);
                    }
                }
            }
            else
            {
                animator.SetBool("isWalking", true);
                animator.SetBool("isAttacking", false);
                this.transform.Translate(0, 0, 0.05f);
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", false);
        }
    }
    public void DropItem()
    {
        if (itemToDrop != null)
        {
            Instantiate(itemToDrop, transform.position, Quaternion.identity);
        }
    }
}

