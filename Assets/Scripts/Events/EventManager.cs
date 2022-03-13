using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EventManager : MonoBehaviour
{
	public static event Action UpgradeEvent;
	public static event Action<Vector3, Quaternion> SpawnUpgradeEvent;


	public static void CallUpgradeEvent()
	{
		UpgradeEvent();
	}



	public static void CallSpawnUpgradeEvent(Vector3 Position, Quaternion Rotation)
	{
		SpawnUpgradeEvent(Position, Rotation);
	}


}
