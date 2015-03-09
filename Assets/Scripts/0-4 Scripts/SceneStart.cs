using UnityEngine;
using System.Collections;

public class SceneStart : MonoBehaviour {

    private BarricadeOn b;
    void Awake()
    {
        b = GetComponent<BarricadeOn>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        b.bswitch = true;
    }
}
