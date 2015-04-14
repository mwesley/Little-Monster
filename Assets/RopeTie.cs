using UnityEngine;
using System.Collections;

public class RopeTie : MonoBehaviour
{
	private Rigidbody2D _startPointRigidbody;
    private Transform _startPoint;
    private Transform _midPoint;
    private Transform _endPoint;
    private LineRenderer _line;
    MeshRenderer sideBound;
    RaycastHit2D hit;
    string hitTag;
	bool cut = false;

    // Use this for initialization
    void Start()
    {
        _startPoint = GameObject.FindWithTag("StartPoint").GetComponent<Transform>();
		_startPointRigidbody = _startPoint.parent.rigidbody2D;
        _midPoint = this.transform;
        _endPoint = GameObject.FindWithTag("EndPoint").GetComponent<Transform>();

        _line = this.GetComponent<LineRenderer>();
        _line.SetVertexCount(3);

        sideBound = GameObject.FindWithTag("StartPoint").GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
		if (!cut) {
			_line.SetPosition (0, _startPoint.position);
			_line.SetPosition (1, _midPoint.position);
			_line.SetPosition (2, _endPoint.position);
		} else if (cut) {
			_line.SetVertexCount (2);
			_line.SetPosition (0, _startPoint.position);
			_line.SetPosition (1, _midPoint.position);
		}

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
				cut = true;
				SetPhysics ();
            }
        }
        hitTag = null;
        
    }

	void SetPhysics()
	{
		_startPointRigidbody.isKinematic = false;
		_startPointRigidbody.gravityScale = 1f;
	}

}
