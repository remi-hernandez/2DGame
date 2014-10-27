using UnityEngine;
using System.Collections;

/// <summary>
/// Comportement des tirs
/// </summary>
public class ShotScript : MonoBehaviour
{
	// 1 - Designer variables
	
	public int damage = 1; // points de dégats infligé
	
	/// <summary>
	/// Projectile ami ou ennemi ?
	/// </summary>
	public bool isEnemyShot = false;
	
	void Start()
	{
		// 2 - Destruction programmée
		Destroy(gameObject, 20); // 20sec
	}
}