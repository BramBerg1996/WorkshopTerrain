using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public IEnemyState currentState;

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(new PatrolState());
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState();
    }

    public void ChangeState(IEnemyState playerState)
    {
        if (currentState != null)
            currentState.OnExit();

        currentState = playerState;

        currentState.OnEnter(GetComponent<Enemy>());
    }
}
