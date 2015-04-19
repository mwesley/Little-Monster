using UnityEngine;
using System.Collections;

public class FillUp : MonoBehaviour
{
    public ValveScript ValveScript;
    public Vector2 DesiredPos;

    private bool _full;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(ValveScript.ValveHitBool && !_full)
        {
            FillPipe();
        }
    }

    void FillPipe()
    {
        this.transform.Translate(Vector3.up * Time.deltaTime);
        if(this.transform.position.y >= DesiredPos.y)
        {
            _full = true;
        }
    }
}
