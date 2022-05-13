using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target2 : MonoBehaviour
{
    public Area2EnemyScript EnemyGoal2;
    public bool Occupied { get {return EnemyGoal2 != null && EnemyGoal2.target2 == this; } }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 0.3f);

    }
}
