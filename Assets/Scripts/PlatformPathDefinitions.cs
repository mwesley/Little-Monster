﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlatformPathDefinitions : MonoBehaviour {

	public Transform[] Points;

	public IEnumerator<Transform> GetPathEnumerator()
	{
		//throw new NotImplementedException();
		if (Points == null || Points.Length < 1)
			yield break;
		var direction = 1;
		var index = 0;
		while (true) 
		{
			yield return Points[index];

			if(Points.Length == 1)
				continue;

			if(index <= 0)
			{
				direction = 1;
			}
			else if(index >= Points.Length - 1)
			{
				direction = -1;
			}
			index = index + direction;
		}
	}

	public void OnDrawGizmos()
	{
		if (Points == null || Points.Length < 2)
		{
			return;
		}

		for (var i = 1; i < Points.Length; i++)
		{
			Gizmos.DrawLine(Points[i - 1].position, Points[i].position);
		}
	}
}