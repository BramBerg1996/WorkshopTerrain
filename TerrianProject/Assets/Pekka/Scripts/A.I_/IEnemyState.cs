using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyState
{
    void OnEnter(Enemy enemy);
    void OnExit();
    void UpdateState();
}
