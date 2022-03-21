using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : Collect
{

	[SerializeField] private GameObject WayoutPrefab;

	[SerializeField] private GameObject PlaceForWayout;
	public void UpgradePicked()
	{
		Debug.Log("You picked up Upgrade");

		Destroy(gameObject);

		Instantiate(WayoutPrefab, PlaceForWayout.transform.position, PlaceForWayout.transform.rotation); 

}
	private void Start()
	{
		EventManager.UpgradeEvent += UpgradePicked;
		PlaceForWayout = GameObject.Find("PlaceForWayout");
	}

	private void OnDisable()
	{
		EventManager.UpgradeEvent -= UpgradePicked;
	}

}
