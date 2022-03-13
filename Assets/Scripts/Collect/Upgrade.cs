using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : Collect
{
	public void UpgradePicked()
	{
		Debug.Log("You picked up Upgrade");
		Destroy(gameObject);
	}
	private void Start()
	{
		EventManager.UpgradeEvent += UpgradePicked;
	}

	private void OnDisable()
	{
		EventManager.UpgradeEvent -= UpgradePicked;
	}

}
