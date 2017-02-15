using UnityEngine;
using System.Collections;
using thelab.mvc;
using UnityEngine.UI;
/// <summary>
/// Class that describes the falling ball.
/// </summary>
public class AsteroidView : View<AstApplication> 
{
	public Image Art;
	void Awake(){
		Art=transform.GetChild(0).GetComponent<Image>();
	}
	/// <summary>
	/// Callback called upon collision.
	/// </summary>
	/// <param name="p_collision"></param>
	public void OnCollisionEnter(Collision p_collision)
	{
		string thisName=this.gameObject.name;
		Notify((thisName+".hit"), "playerCollider");
	}

}
