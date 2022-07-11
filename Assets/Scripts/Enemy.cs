using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private State enemyState = State.Idle;

    public enum State
    {
        Idle, Chase, Attack, Hit, Dead
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Chase(GameObject playerObj)
    {
        GetComponent<NavMeshAgent>().destination = playerObj.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;
        if(tag == "Player")
        {
            Chase(collision.gameObject);
        }
    }
}
