using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BetterAI : MonoBehaviour
{
    public Transform playerTransform;
    Animator anim;
    UnityEngine.AI.NavMeshAgent agent;

    protected Target[] PotentialTargets;
    [HideInInspector]
    [Header("Targets")]
    public Target target;
    // Start is called before the first frame update
    void Awake()
    {
        PotentialTargets = FindObjectsOfType<Target>();
        target = PotentialTargets[Random.Range(0, PotentialTargets.Length)];
    }
    
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", agent.velocity.magnitude);
        //agent.destination = playerTransform.position;
        
    }
}
