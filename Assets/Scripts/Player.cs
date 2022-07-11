using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Animator playerAnimator = null;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Attack();
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (h == 0 && v == 0)
        {
            GetComponent<Animator>().SetBool("isRun", false);
        }
        else
        {
            this.GetComponent<Animator>().SetBool("isRun", true);
            h = h * moveSpeed * Time.deltaTime;
            v = v * moveSpeed * Time.deltaTime;
            Vector3 vector = new Vector3(h, 0, v);
            this.transform.position += vector;
            if (vector != Vector3.zero)
            {
                transform.forward = vector;
            }
        }
    }

    private void Attack()
    {
        bool but = Input.GetButtonDown("Fire1");

        if(but == true)
        {
            playerAnimator.SetBool("isRun", false);
            playerAnimator.SetBool("isAttack", true);
        }
    }

    public void EndAttackAni()
    {
        playerAnimator.SetBool("isAttack", false);
    }
}
