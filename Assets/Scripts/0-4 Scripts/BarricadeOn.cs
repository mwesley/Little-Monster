using UnityEngine;
using System.Collections;

public class BarricadeOn : MonoBehaviour {

    public GameObject[] barricades;
    public bool bswitch;

    void Update()
    {
        if (bswitch)
        {
            foreach (GameObject g in barricades)
            {
                CollisionPlatforms temp = g.GetComponent<CollisionPlatforms>();
                temp.moving = true;
            }
            bswitch = false;
        }
    }
}
