using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private State enemyState = State.Idle;
    private Animator anim;

    public GameObject target;

    [SerializeField]
    private float attackRange = 3f;

    public enum State
    {
        Idle, Chase, Attack, Hit, Dead
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Chase(target);
    }

    private void Chase(GameObject playerObj)
    {
        float dis = Vector3.Distance(playerObj.transform.position, this.transform.position);

        if (dis < attackRange)
        {
            enemyState = State.Attack;
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<Animator>().SetBool("isWalk", false);
            GetComponent<Animator>().SetBool("isAttack", true);
        }
        else 
        {
            GetComponent<Animator>().SetBool("isWalk", true);
            enemyState = State.Chase;
            GetComponent<NavMeshAgent>().enabled = true;
            GetComponent<NavMeshAgent>().destination = playerObj.transform.position;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;
        if(tag == "Player")
        {
            Chase(collision.gameObject);
        }
    }


    private void OnCollisionStay(Collision collision)
    {
        
    }

}
