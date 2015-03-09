using UnityEngine;
using System.Collections;

public class RemovePlatform : MonoBehaviour {

    public GameObject target;

    public void removePlatform()
    {
        if (target != null)
        {
            target.transform.DetachChildren();
            Destroy(target);
        }
    }
}
