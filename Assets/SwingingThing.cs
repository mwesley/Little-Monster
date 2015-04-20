using UnityEngine;
using System.Collections;

public class SwingingThing : MonoBehaviour
{

    public LineRenderer BallToFixed;
    public LineRenderer BallToBreak;

    RaycastHit2D hit;
    string hitTag;
    bool cut = false;

    // Use this for initialization
    void Start()
    {
        BallToFixed.SetVertexCount(2);
        BallToBreak.SetVertexCount(2);
        BallToFixed.SetWidth(0.05f, 0.05f);
        BallToBreak.SetWidth(0.05f, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        DrawToFixed();
        if(cut)
        {
            this.rigidbody2D.isKinematic = false;
            BallToBreak.enabled = false;
        }
        else if (!cut)
        {
            DrawToBreak();
            RopeCut();
        }
    }

    void DrawToFixed()
    {
        BallToFixed.SetPosition(0, this.transform.position);
        BallToFixed.SetPosition(1, new Vector3(33, 57, 0));
    }

    void DrawToBreak()
    {
        BallToBreak.SetPosition(0, this.transform.position);
        BallToBreak.SetPosition(1, new Vector3(43, 57, 0));
    }

    void RopeCut()
    {
        hit = Physics2D.Linecast(this.transform.position, new Vector3(43,57,0));
        Debug.DrawLine(this.transform.position, new Vector3(43,57,0));

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
            }
        }
        hitTag = null;
    }
}
