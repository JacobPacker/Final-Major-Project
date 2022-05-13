using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target3 : MonoBehaviour
{
    public Area3EnemyScript EnemyGoal3;
    public bool Occupied { get { return EnemyGoal3 != null && EnemyGoal3.target3 == this; } }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.3f);

    }
}
