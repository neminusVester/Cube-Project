using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class SimpleCollectibleScript : PoolObject
{

	public enum CollectibleTypes { NoType, Type1, Type2, Type3, Type4, Type5 }; // you can replace this with your own labels for the types of collectibles in your game!

	public CollectibleTypes CollectibleType; // this gameObject's type

	public bool rotate; // do you want it to rotate?

	public float rotationSpeed;

	public AudioClip collectSound;

	public GameObject collectEffect;
	private Vector3 _finalCoinPosition = new Vector3(6.5f, 20f, 9f);
	private float _screenWidth;
	private float _screenHeight;

	// Use this for initialization
	void Start()
	{
		_screenWidth = Screen.width;
		_screenHeight = Screen.height;
	}

	// Update is called once per frame
	void Update()
	{

		if (rotate)
			transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Collect();
		}
	}

	public void Collect()
	{
		if (collectSound)
			AudioSource.PlayClipAtPoint(collectSound, transform.position);
		if (collectEffect)
			Instantiate(collectEffect, transform.position, Quaternion.identity);

		//Below is space to add in your code for what happens based on the collectible type

		if (CollectibleType == CollectibleTypes.NoType)
		{

			//Add in code here;

			Debug.Log("Do NoType Command");
		}
		if (CollectibleType == CollectibleTypes.Type1)
		{

			//Add in code here;

			Debug.Log("Do NoType Command");
		}
		if (CollectibleType == CollectibleTypes.Type2)
		{

			//Add in code here;

			Debug.Log("Do NoType Command");
		}
		if (CollectibleType == CollectibleTypes.Type3)
		{

			//Add in code here;

			Debug.Log("Do NoType Command");
		}
		if (CollectibleType == CollectibleTypes.Type4)
		{

			//Add in code here;

			Debug.Log("Do NoType Command");
		}
		if (CollectibleType == CollectibleTypes.Type5)
		{

			//Add in code here;

			Debug.Log("Do NoType Command");
		}

		Destroy();
		// MoveAfterCollected();
	}

	//перевірить як воно переміщується в дутввіном
	private void MoveAfterCollected()
	{
		Vector3 fPos = new Vector3(_screenWidth - 25f, _screenHeight - 20f);
		this.transform.Translate(fPos, Space.World);
	}
}
