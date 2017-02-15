using UnityEngine;
using System.Collections;
using thelab.mvc;

/// <summary>
/// Class that describes the falling ball.
/// </summary>
public class PlayerView : View<AstApplication> 
{
	[System.Serializable]
	public class Done_Boundary 
	{
		public float xMin, xMax, zMin, zMax;
	}
	public float speed;
	public float tilt;
	public Done_Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;


	void OnTriggerEnter(Collider p_collider) 
	{ 
		Debug.Log("enter");

//		p_collider.transform.position+=Vector3.up*20;
//		string thisName=this.gameObject.name;
//		Notify((thisName+".hit"), "asteroidCollider");
		Notify("asteroid.trigger.enter",p_collider.gameObject);
	}
	void Update ()
	{
		
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play ();
		}
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, moveVertical,0.0f );
		GetComponent<Rigidbody>().velocity = movement * speed;

		GetComponent<Rigidbody>().position = new Vector3
			(
				Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
				Mathf.Clamp (GetComponent<Rigidbody>().position.y, boundary.zMin, boundary.zMax),
				0.0f
			);

		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}
