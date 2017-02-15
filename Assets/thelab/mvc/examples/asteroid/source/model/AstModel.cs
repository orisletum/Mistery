using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using thelab.mvc;

/// <summary>
/// Class that handles the application data.
/// </summary>
public class AstModel : Model<AstApplication>
{
	public GameObject Explosion;
	public GUIText TextScore;
	public GUIText TextLife;
	public GUIText TextLose;
	public int curLevel=1;
	public List<int> levelStars=new List<int>(3){0,-1,-1};
	/// <summary>
	/// lifes player
	/// </summary>
	public int lifes=3;
	/// <summary>
	/// lifes player
	/// </summary>
	public int enemies_count;
	/// <summary>
	/// score 
	/// </summary>
	public int score;
    /// <summary>
    /// Win condition.
    /// </summary>
	public int winCondition=10;



}
