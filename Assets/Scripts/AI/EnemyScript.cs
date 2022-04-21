using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyScript : MonoBehaviour
{
    protected NavMeshAgent Agent;
    protected StateEnum State;
    protected Target[] PotentialTargets;
    [HideInInspector]
    public Target target;

    protected float NextState;
    
    void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        PotentialTargets = FindObjectsOfType<Target>();
        target = PotentialTargets[Random.Range(0, PotentialTargets.Length)];
        State = StateEnum.RUN;
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
                    target = PotentialTargets[targetIndex];
                    target.EnemyGoal = this;
                    Agent.SetDestination(target.transform.position);
                }
                break;
        }

        transform.position += Agent.desiredVelocity * Time.deltaTime;
    }

    public enum StateEnum
    {
        RUN,
        SHOOT
    }
}
