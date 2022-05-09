using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class Area2EnemyScript : MonoBehaviour
{
    protected NavMeshAgent Agent;
    protected StateEnum State;
    protected Target2[] PotentialTargets;
    [HideInInspector]
    [Header("Targets")]
    public Target2 target2;
    Animator anim;
    [Header("Rigidbodies")]
    private Rigidbody rb;
    private Vector3 vel;
    protected float NextState;
    //public Transform playerTransform;
    
    void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        PotentialTargets = FindObjectsOfType<Target2>();
        target2 = PotentialTargets[Random.Range(0, PotentialTargets.Length)];
        State = StateEnum.RUN;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        Agent.updatePosition = false;
        Agent.updatePosition = false;
        Agent.updateUpAxis = false;
        /*if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;
            Physics.Raycast(ray, out hitinfo);
            Agent.SetDestination(hitinfo.point);
        }*/

        NextState -= Time.deltaTime;

        switch (State)
        {
            case StateEnum.RUN:

                if(Agent.desiredVelocity.magnitude < 0.02f)
                {
                    State = StateEnum.SHOOT;
                    NextState = Random.Range(4f, 10f);
                }

                break;
            
            case StateEnum.SHOOT:
                if(NextState < 0)
                {
                    State = StateEnum.RUN;
                    var targetIndex = Random.Range(0, PotentialTargets.Length);
                    for(var i = 0; i < 10 && PotentialTargets[targetIndex].Occupied; i++)
                    {
                        targetIndex = (targetIndex + 1) % PotentialTargets.Length;
                    }
                    target2 = PotentialTargets[targetIndex];
                    target2.EnemyGoal2 = this;
                    Agent.SetDestination(target2.transform.position);
                }
                break;
        }
        
        if (Agent.desiredVelocity.magnitude > 0.01f )
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
        transform.position += Agent.desiredVelocity * Time.deltaTime;
    }

    public enum StateEnum
    {
        RUN,
        SHOOT
    }
}
