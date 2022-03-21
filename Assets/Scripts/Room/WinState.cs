using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : MonoBehaviour
{
	public GameObject [] UpgradePrefab;


	System.Random RandomUpgrade = new System.Random();


	public void  SpawnUpgrade(Vector3 Position, Quaternion Rotation)
	{
		Instantiate(UpgradePrefab[RandomUpgrade.Next(0, 10)], Position, Rotation);
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
