using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShooterFSM : MonoBehaviour {
    public enum EnemyState { Idle, Chase, Shoot, Dead, Evade, Enroute };
    public EnemyState currentState;

    public GameObject player;

    public Rigidbody bullet;


    public float speed = 2;




    public float attackRange = 10;

    public float sightRange = 10;

    public float duration = 5;

    public float time;

    public float hp = 100;


    public float forward = 100;

    bool inVision = false;

    public float nextFire = 0.4f;
    private float myTime = 0.2f;

   

    // Private variables
    private Rigidbody rBody;
    public GameObject spawn;

    public Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        currentState = EnemyState.Idle;
        player = GameObject.FindGameObjectWithTag("Player");

        rb = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();

        RaycastHit hit;

        Ray landingRay = new Ray(transform.position, player.transform.position - this.transform.position);

        if (Physics.Raycast(landingRay, out hit, 10))
        {
            if (hit.collider.tag == "Player")
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


        //RaycastHit hit2;
        //Ray landingRay2 = new Ray(transform.position, this.transform.position - transform.TransformDirection(Vector3.back) * 10);
        //Debug.DrawLine(this.transform.position, this.transform.position - transform.TransformDirection(Vector3.back) * 10,Color.yellow);
        //if (Physics.Raycast(landingRay2, out hit2, 10))
        //{
        //    if (hit2.collider.tag == "Player")
        //    {
                
        //        //Debug.DrawLine(this.transform.position, this.transform.position - transform.TransformDirection(Vector3.back) * 10, Color.red);
        //        //Debug.Log("see");
        //        Debug.DrawLine(this.transform.position, player.transform.position);
        //    }


        //}






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
        Gizmos.DrawWireSphere(this.transform.position + new Vector3(0, 0, 0), 10);
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


    void Shoot()
    {

        myTime = myTime + Time.deltaTime;

        if (myTime > nextFire)
        {

            Instantiate(bullet, this.transform.position + new Vector3(0,0,0.5f), this.transform.rotation);
            bullet.transform.eulerAngles = new Vector3(0, this.transform.rotation.y, 0);
            myTime = 0.0f;
        }
        // hp -= 1;



    }

    void rotate()
    {
        Vector3 targetDir = player.transform.position - this.transform.position;

		float step = 20 * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDir);
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


                if (inVision == true)
                {
                    ChangeState(EnemyState.Shoot);
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




            case EnemyState.Shoot:
                rotate();
                Shoot();

                if (inVision == false)
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
