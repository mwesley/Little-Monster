using UnityEngine;
using System.Collections;

public class RopeTie : MonoBehaviour
{
    private Transform _startPoint;
    private Transform _midPoint;
    private Transform _endPoint;
    private LineRenderer _line;
    MeshRenderer sideBound;
    RaycastHit2D hit;
    string hitTag;

    // Use this for initialization
    void Start()
    {
        _startPoint = GameObject.FindWithTag("StartPoint").GetComponent<Transform>();
        _midPoint = this.transform;
        _endPoint = GameObject.FindWithTag("EndPoint").GetComponent<Transform>();

        _line = this.GetComponent<LineRenderer>();
        _line.SetVertexCount(3);

        sideBound = GameObject.FindWithTag("StartPoint").GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _line.SetPosition(0, _startPoint.position);
        _line.SetPosition(1, _midPoint.position);
        _line.SetPosition(2, _endPoint.position);

        hit = Physics2D.Linecast(_midPoint.position, _endPoint.position);
        Debug.DrawLine(_midPoint.position, _endPoint.position);

        if (hit.transform != null)
        {
            if (hit.transform.Find("ClawSwingR(Clone)") != null)
            {
                hitTag = hit.transform.Find("ClawSwingR(Clone)").Find("ClawSwing").tag;
            }
            else if (hit.transform.Find("ClawSwingL(Clone)") != null)
            {
                hitTag = hit.transform.Find("ClawSwingL(Clone)").Find("ClawSwing").tag;
            }
            if (hitTag == "Claw")
            {
                Debug.Log("A thing has been done");
            }
        }
        hitTag = null;
        
    }
}
