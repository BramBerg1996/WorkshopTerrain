using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    public float timer = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, timer);
    }
}
