using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour {
    public enum EnemyState { Idle, Chase, Attack, Dead, Evade, Enroute };
    public EnemyState currentState;

    public GameObject player;

  
    public float speed = 2;




    public float attackRange = 2;

    public float sightRange = 6;

    public float duration = 5;

    public float time;

    public float hp = 100;


    public float forward = 100;

    bool inVision = false;


    // Use this for initialization
    void Start()
    {
        currentState = EnemyState.Idle;
        player = GameObject.FindGameObjectWithTag("Player");




    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();

        
        RaycastHit hit;


        //raycasting///
        //can be used for gun bullet hit detection
        
       Ray landingRay = new Ray(transform.position, player.transform.position -this.transform.position);

       if (Physics.Raycast(landingRay, out hit, 10))
       {
           if(hit.collider.tag == "Player")
           {
                inVision = true;
               Debug.DrawLine(this.transform.position, player.transform.position);
                //Debug.Log("see");
            }
            else
            {
                inVision = false;
            }
       }
       
      

    /*
     Ray landingRay = new Ray(transform.position, Vector3.left);
     Debug.DrawRay(transform.position, Vector3.left * forward,Color.red);

        if (Physics2D.CircleCast(this.transform.position, 10, player.transform.position,out hit))
     {
         if(hit.collider.tag == "Player")
         {
             Debug.DrawLine(this.transform.position, player.transform.position);
             Debug.Log("see");
         }
     }

        */

  }





  //making overlap sphere visible
  private void OnDrawGizmosSelected()
  {


      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(this.transform.position + new Vector3(0,0,0), 10);
  }

  void FixedUpdate()
  {
      /*
      Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 10);
      int i = 0;
      while (i < hitColliders.Length)
      {
          if(hitColliders[i].tag != "enemy")
          {
              Debug.Log(hitColliders[i]);
              Debug.DrawLine(this.transform.position, hitColliders[i].transform.position);

          }

          i++;
      }
      */
    }

    void EnRoute()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();

        agent.destination = player.transform.position;

    }

    void ChasePlayer()
    {
        Vector3 E2T = transform.position - player.transform.position;
        Vector3 newPos = transform.position - speed * Time.deltaTime * E2T.normalized;
        transform.position = newPos;

    }


    void Attacking()
    {
        Debug.Log("Attacking");
        hp -= 1;
    }

  

    void Dead()
    {


    }

    bool InRange()
    {
        Vector3 E2T = transform.position - player.transform.position;
        float dTE = E2T.magnitude;
        // Debug.Log(E2T.magnitude);
        return dTE < attackRange;

    }

  



    bool OutOfRange()
    {
        Vector3 E2T = transform.position - player.transform.position;
        float dTE = E2T.magnitude;
        //Debug.Log(E2T.magnitude);
        return dTE > attackRange;

    }

    bool outOfSight()
    {
        Vector3 E2T = transform.position - player.transform.position;
        float dTE = E2T.magnitude;
        //Debug.Log(E2T.magnitude);
        return dTE > sightRange;
    }


    bool inSight()
    {
        Vector3 E2T = transform.position - player.transform.position;
        float dTE = E2T.magnitude;
        //Debug.Log(E2T.magnitude);
        return dTE < sightRange;
    }


    void ChangeState(EnemyState toState)
    {
        currentState = toState;
    }

    void UpdateState()
    {
        switch (currentState)
        {
            case EnemyState.Chase:

                EnRoute();


                if (InRange())
                {
                    ChangeState(EnemyState.Attack);
                }

                if (inVision == false)
                {
                    ChangeState(EnemyState.Enroute);
                }

                if (hp <= 0)
                {
                    ChangeState(EnemyState.Dead);
                }

              

                break;

           


            case EnemyState.Attack:


                Attacking();

                if (OutOfRange())
                {
                    ChangeState(EnemyState.Chase);
                }
                if (hp <= 0)
                {
                    Debug.Log("You Loose");

                    ChangeState(EnemyState.Dead);
                }



                break;
            case EnemyState.Idle:

                if (inVision == false)
                {
                    ChangeState(EnemyState.Enroute);
                }

                break;

            case EnemyState.Dead:
                Dead();
                break;

            case EnemyState.Enroute:
                EnRoute();
                if (inVision == true)
                {
                    ChangeState(EnemyState.Chase);
                }
                break;

        }
    }

}
