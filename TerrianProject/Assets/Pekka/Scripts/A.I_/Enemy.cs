using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject exclamation;
    public LayerMask layer;
    public Transform[] waypoints;
    [HideInInspector] public CapsuleCollider capsule;
    [HideInInspector] public bool chasePlayer = false;
    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public int currentWayPoint = 0;

    [HideInInspector] public StateController state;

    public float attackDistance = 10f;

    private void Awake()
    {
        state = GetComponent<StateController>();
        agent = GetComponent<NavMeshAgent>();
        capsule = GetComponent<CapsuleCollider>();

        if (waypoints.Length == 0)
            Debug.LogError("Error! Enemy has no waypoints added to its list!", this.gameObject);
    }

    public void PlayerSpotted()
    {
        GameObject GO = Instantiate(exclamation);
        GO.transform.position = transform.position + new Vector3(0f, 2f, 0f);
    }

    void ChasePlayer()
    {
        agent.isStopped = false;
        chasePlayer = true;
    }
}
