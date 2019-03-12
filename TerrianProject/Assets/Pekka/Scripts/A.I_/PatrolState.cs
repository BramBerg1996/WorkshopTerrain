using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState
{
    Enemy enemy;

    public void OnEnter(Enemy enemy)
    {
        this.enemy = enemy;
        enemy.agent.destination = enemy.waypoints[enemy.currentWayPoint].position;
    }

    public void OnExit()
    {
        enemy.agent.isStopped = true;
    }

    public void UpdateState()
    {
        if (enemy.agent.remainingDistance <= enemy.agent.stoppingDistance)
        {
            enemy.currentWayPoint++;

            if (enemy.currentWayPoint >= enemy.waypoints.Length)
                enemy.currentWayPoint = 0;

            enemy.agent.destination = enemy.waypoints[enemy.currentWayPoint].position;
        }

        RaycastHit hit;

        Vector3 p1 = enemy.transform.position + enemy.capsule.center;

        if (Physics.SphereCast(p1, 1f, enemy.transform.forward, out hit))
        {
            if (hit.distance < 10)
            if (hit.transform.CompareTag("Player"))
            {
                enemy.state.ChangeState(new ChaseState());
            }
        }

    }
}
