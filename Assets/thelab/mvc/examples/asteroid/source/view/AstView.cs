using UnityEngine;
using System.Collections;
using thelab.mvc;

/// <summary>
/// Root class for all views.
/// </summary>
public class AstView : View<AstApplication>
{

   
	/// <summary>
	/// player view
	/// </summary>
	public PlayerView player { get { return m_player = Assert<PlayerView>(m_player); } }
	private PlayerView m_player;
	/// <summary>
	/// asteroid view
	/// </summary>
	public AsteroidView asteroid { get { return m_asteroid = Assert<AsteroidView>(m_asteroid); } }
	private AsteroidView m_asteroid;

//	/// <summary>
//	/// Explosion view
//	/// </summary>
//	public ExplosionView explosion { get { return m_explosion = Assert<ExplosionView>(m_explosion); } }
//	private ExplosionView m_explosion;

	/// <summary>
	/// asteroids pool
	/// </summary>
	public PoolView poolAst { get { return m_poolAst = Assert<PoolView>(m_poolAst); } }
	private PoolView m_poolAst;
    /// <summary>
    /// Reference to the Ball view.
    /// </summary>
    public TimerView timer { get { return m_timer = Assert<TimerView>(m_timer); } }
    private TimerView m_timer;
}
