using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using thelab.mvc;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Class that describes the falling ball.
/// </summary>
public class PoolView : View<AstApplication> 
{
	List<AsteroidView> poolObj=new List<AsteroidView>();
	/// <summary>
	/// Callback called upon collision.
	/// </summary>
	/// <param name="p_collision"></param>
	public void OnCollisionEnter(Collision p_collision)
	{
		string thisName=this.gameObject.name;
		Notify((thisName+".hit"), "asteroidCollider");
	}
	void Awake(){
		for (int i = 0; i < 10; i++) {
			CreateAsteroid(i);
		}
	}
	void Update(){
		if(app.model.TextLose.gameObject.activeSelf && Input.GetButton("Fire1"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
	public void CreateAsteroid(int index){
		AsteroidView aster = Instantiate(app.view.asteroid,this.transform) as AsteroidView;
		aster.name="asteroid";
		aster.transform.position=new Vector3(Random.Range(-5f,5f),5+index*5,0);
		aster.GetComponent<Rigidbody>().velocity=Vector3.down*3;
		poolObj.Add(aster);
	}
	public void MoveAsteroid(GameObject asteroid){
		asteroid.transform.position+=new Vector3(0,-10,0);
	}
	public void DestroyAsteroid(AsteroidView asteroid){
		asteroid.enabled=false;
	}
	public void DestroyAsteroid(GameObject asteroid){
		asteroid.GetComponent<AsteroidView>().Art.enabled=false;
	}
}
