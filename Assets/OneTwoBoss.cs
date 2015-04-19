using UnityEngine;
using System.Collections;

public class OneTwoBoss : MonoBehaviour
{

    public ValveScript ValveScript;
    public Collider2D ThisCollider;
    public Collider2D OtherCollider;
    public Transform SewageWater;
    public Transform Player;
    public Vector2 DesiredPos;

    private bool _gone;
    private bool _full;
    private SmoothCamera2D _cameraScript;

    // Use this for initialization
    void Start()
    {
        _cameraScript = Camera.main.GetComponent<SmoothCamera2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (ValveScript.ValveHitBool && !_full)
        {
            Physics2D.IgnoreCollision(ThisCollider, OtherCollider, true);
            //Destroy(this.gameObject, 2.0f);
            SewageWater.Translate(Vector3.right * Time.deltaTime);
            _cameraScript.target = this.transform;
            if(SewageWater.position.y >= DesiredPos.y)
            {
                _full = true;
            }
        }

        if(_full)
        {
            _cameraScript.target = Player;
            Destroy(this.gameObject, 2.0f);
        }



    }
}
