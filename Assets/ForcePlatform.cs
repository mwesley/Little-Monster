using UnityEngine;
using System.Collections;

public class ForcePlatform : MonoBehaviour
{

    private float _lerpTimer;
    public float StayTimer;
    public float UpTimer;
    public float speed;
    public Vector2 UpPosition;
    public Vector2 StayPosition;
    public Transform PlatformTransform;
    private LineRenderer _line;
    private bool _fall;
    private float _timerOne = 0;
    private float _timerTwo = 0;
    public Material LineMat;

    // Use this for initialization
    void Start()
    {
        _lerpTimer = 0;
        _line = this.gameObject.AddComponent<LineRenderer>();
        _line.SetVertexCount(2);
        _line.material = LineMat;
    }

    // Update is called once per frame
    void Update()
    {
        DrawLine();
        if (!_fall)
        {
            MoveUp();
        }
        if (_fall)
        {
            this.rigidbody2D.isKinematic = false;
            if (PlatformTransform.position.y <= StayPosition.y + 0.05f)
            {
                this.rigidbody2D.isKinematic = true;
                _timerTwo += Time.deltaTime;
                if (_timerTwo >= StayTimer)
                {
                    _fall = false;
                    _timerTwo = 0f;
                }
            }
        }
    }

    void MoveUp()
    {
        _lerpTimer += Time.deltaTime;
        float movement = speed * _lerpTimer;
        PlatformTransform.position = Vector2.Lerp(StayPosition, UpPosition, movement);
        if (PlatformTransform.position.y == UpPosition.y)
        {
            _timerOne += Time.deltaTime;
            if (_timerOne >= UpTimer)
            {
                _fall = true;
                _timerOne = 0;
                _lerpTimer = 0;
                movement = 0;
            }
        }
    }

    void DrawLine()
    {
        _line.SetPosition(0, this.transform.position);
        _line.SetPosition(1, this.transform.parent.transform.position);
        _line.SetWidth(1f, 0.05f);
    }
}
