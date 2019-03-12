using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IEnemyState
{
    Enemy enemy;
    Transform player;

    public void OnEnter(Enemy enemy)
    {
        this.enemy = enemy;
        player = GameObject.Find("Player").transform;
        enemy.PlayerSpotted();

        enemy.Invoke("ChasePlayer", 1f);
    }

    public void OnExit()
    {
        enemy.CancelInvoke();
        enemy.chasePlayer = false;
    }

    public void UpdateState()
    {
        if (enemy.chasePlayer)
        {
            enemy.agent.destination = player.transform.position;
        }
    }


}
