using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TakePath : MonoBehaviour {

	public enum TakeType
	{
		MoveTowards,
		Lerp
	}
	public TakeType type = TakeType.MoveTowards;
	public PlatformPathDefinitions path;
	public float speed;
	public float lerpSpeed;
	public float maxDistanceToPoint =.1f;
	public float moveTimer;

	private IEnumerator<Transform> _currentPoint;

	public void Start()
	{
		if(path == null)
		{
			Debug.LogError("Path cannot be null!", gameObject);
			return;
		}
		_currentPoint = path.GetPathEnumerator ();
		_currentPoint.MoveNext ();
		if(_currentPoint.Current == null)
			return;
		moveTimer = 0f;
		transform.position = _currentPoint.Current.position;
	}

	public void Update()
	{
		if (_currentPoint == null || _currentPoint.Current == null)
			return;
		var distanceSqr = (transform.position - _currentPoint.Current.position).sqrMagnitude;

		if (type == TakeType.MoveTowards)
			transform.position = Vector3.MoveTowards (transform.position, _currentPoint.Current.position, Time.deltaTime * speed);

		else if (type == TakeType.Lerp)
		{
			moveTimer += Time.deltaTime * (speed/lerpSpeed);
			transform.position = Vector3.Lerp (transform.position, _currentPoint.Current.position, moveTimer);
		}

		if (distanceSqr < maxDistanceToPoint * maxDistanceToPoint)
		{
			_currentPoint.MoveNext ();
			moveTimer = 0f;
		}
	}
}
