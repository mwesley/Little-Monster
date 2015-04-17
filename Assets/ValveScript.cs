using UnityEngine;
using System.Collections;

public class ValveScript : MonoBehaviour
{

    public Transform _start;
    public Transform _end;

    private LineRenderer _line;
    private string hitTag;
    public bool ValveHitBool = false;
    public ForcePlatform ForcePlatformScript;

    // Use this for initialization
    void Start()
    {
        _line = this.gameObject.AddComponent<LineRenderer>();
        _line.SetVertexCount(2);
    }

    // Update is called once per frame
    void Update()
    {
        if(!ValveHitBool)
        {
            ValveNotHit();
        }
        else if (ValveHitBool)
        {
            ValveHit();
        }
    }

    void DrawLine()
    {
        _line.SetPosition(0, _start.position);
        _line.SetPosition(1, _end.position);
        _line.SetWidth(0.05f, 0.05f);
    }

    void ValveHit()
    {
        Debug.Log("Valvehit");
        ValveHitBool = true;
        ForcePlatformScript.enabled = true;
        _line.enabled = false;
    }

    void ValveNotHit()
    {
        DrawLine();
        RaycastHit2D hit = Physics2D.Linecast(_start.position, _end.position);
        Debug.DrawLine(_start.position, _end.position);
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
                ValveHit();
            }
        }
        hitTag = null;
    }
}
