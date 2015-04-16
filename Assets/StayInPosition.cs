using UnityEngine;
using System.Collections;

public class StayInPosition : MonoBehaviour
{
    public Vector2 DesiredTransform;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.transform.position.y != DesiredTransform.y || this.transform.position.x != DesiredTransform.x)
        {
            this.transform.position = DesiredTransform;
        }
    }
}
