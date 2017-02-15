using UnityEngine;
using System.Collections;
using thelab.mvc;
using UnityEngine.SceneManagement;
using UniRx.Triggers;
using UniRx;

public class AstController : Controller<AstApplication>
{
//	[System.Serializable]
//	public class Done_Boundary 
//	{
//		public float xMin, xMax, zMin, zMax;
//	}
//	public float speed;
//	public float tilt;
//	public Done_Boundary boundary;
//	public IObservable<Vector3> movement { get; private set; }
//	public GameObject shot;
//	public Transform shotSpawn;
//	public float fireRate;
//
//	private float nextFire;
	void Awake(){
		app.model.curLevel=PlayerPrefs.GetInt("CurLevel",0);
	
//		Rigidbody PlayerRig=app.view.player.GetComponent<Rigidbody>();
//		movement=this.FixedUpdateAsObservable()
//		.Select(_ => {
//			var x = Input.GetAxis("Horizontal");
//			var y = Input.GetAxis("Vertical");
//				PlayerRig.velocity = new Vector3 (x*speed, y*speed, 0.0f);
//				return new Vector3 (x*speed, y*speed, 0.0f);
//		});
//		
//
////		PlayerRig.velocity = movement.TakeLast(1);
//		PlayerRig.position = new Vector3
//			(
//			Mathf.Clamp (PlayerRig.position.x, boundary.xMin, boundary.xMax), 
//			Mathf.Clamp (PlayerRig.position.y, boundary.zMin, boundary.zMax),
//				0.0f
//			);
//
//		PlayerRig.rotation = Quaternion.Euler (0.0f, 0.0f, PlayerRig.velocity.x * -tilt);
			
	}
    /// <summary>
    /// Handle notifications from the application.
    /// </summary>
    /// <param name="p_event"></param>
    /// <param name="p_target"></param>
    /// <param name="p_data"></param>
    public override void OnNotification(string p_event, Object p_target, params object[] p_data)
    {
        switch(p_event)
        {
            case "scene.load":                
                Log("Scene [" + p_data[0] + "]["+p_data[1]+"] loaded");
                break;

            case "game.complete":
                Log("Victory!");
				PlayerPrefs.SetInt("CurLevel", app.model.curLevel);
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;

            case "asteroid.trigger.enter":
            {                    
				Log("asteroid Enter!");
				GameObject f =p_data[0] as GameObject;
				if(app.model.lifes>=1)
				{
					app.model.lifes--;
					app.model.TextLife.text="lifes: "+app.model.lifes;
					if (app.model.Explosion != null)
					{
						Instantiate(app.model.Explosion, f.transform.position, f.transform.rotation);
					}
				}
				else
				{
					Instantiate(app.model.Explosion, f.transform.position, f.transform.rotation);
					Instantiate(app.model.Explosion, app.view.player.transform.position, f.transform.rotation);
					app.view.player.enabled=false;
					app.view.player.transform.position=new Vector3(0,100,0);
					app.model.TextLose.gameObject.SetActive(true);
				}
				f.transform.position+=Vector3.up*23;

            }
            break;

			case "Move@trigger.enter":
            {
				Log("Move@trigger.enter");
				GameObject f =p_data[0] as GameObject;
				f.transform.position+=Vector3.up*22;
				app.model.score++;
				app.model.TextScore.text="score: "+app.model.score;
				if(app.model.score>=app.model.winCondition*app.model.curLevel)
				{
					app.model.curLevel++;
					Notify("game.complete");

				}
			
            }
            break;
			case "Bullet@trigger.enter":
			{
				Log("Bullet@trigger.enter");
				GameObject f =p_data[0] as GameObject;
				f.transform.position+=Vector3.up*22;
				app.model.score+=2;

				GameObject bullet =p_data[1] as GameObject;
				Instantiate(app.model.Explosion, bullet.transform.position, f.transform.rotation);
				Destroy(bullet,0);
				app.model.TextScore.text="score: "+app.model.score;
				if(app.model.score>=app.model.winCondition*app.model.curLevel)
				{
					app.model.curLevel++;
					Notify("game.complete");

				}

			}
			break;
		

        }
    }
	
}
