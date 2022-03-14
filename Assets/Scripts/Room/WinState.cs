using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : MonoBehaviour
{
	public GameObject UpgradePrefab;



	public void  SpawnUpgrade(Vector3 Position, Quaternion Rotation)
	{
		Instantiate(UpgradePrefab, Position, Rotation);
		Destroy(gameObject);
	}

	private void Start()
	{
		EventManager.SpawnUpgradeEvent += SpawnUpgrade;
	}

	private void OnDisable()
	{
		EventManager.SpawnUpgradeEvent -= SpawnUpgrade;
	}





}
