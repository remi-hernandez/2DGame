﻿using UnityEngine;

/// <summary>
/// Crée des projectiles
/// </summary>
public class WeaponScript : MonoBehaviour
{
	//--------------------------------
	// 1 - Designer variables
	//--------------------------------
	
	/// <summary>
	/// Prefab du projectile
	/// </summary>
	public Transform shotPrefab;
   public PlayerScript player;
	
	/// <summary>
	/// Temps de rechargement entre deux tirs
	/// </summary>
	public float shootingRate = 0.25f;
	
	//--------------------------------
	// 2 - Rechargement
	//--------------------------------
	
	private float shootCooldown;
   private Vector2 shootPosition;
	
	void Start()
	{
		shootCooldown = 0f;
	}
	
	void Update()
	{
		if (shootCooldown > 0)
		{
			shootCooldown -= Time.deltaTime;
		}
	}
	
	//--------------------------------
	// 3 - Tirer depuis un autre script
	//--------------------------------
	
	/// <summary>
	/// Création d'un projectile si possible
	/// </summary>
	public void Attack(bool isEnemy)
	{
		if (CanAttack)
		{
			shootCooldown = shootingRate;
			
			// Création d'un objet copie du prefab
			var shotTransform = Instantiate(shotPrefab) as Transform;
			
			// Position
			shotTransform.position = transform.position;
			
         // Modification de la position a l'apparition de la balle
         if (player.rightDirection == true)
         {
            shootPosition.x = transform.position.x + 3;
            shootPosition.y = transform.position.y + (float)0.5;
            shotTransform.position = shootPosition;
         }
         else
         {
            shootPosition.x = transform.position.x - 3;
            shootPosition.y = transform.position.y + (float)0.5;
            shotTransform.position = shootPosition;
            shotTransform.transform.eulerAngles = new Vector2(0, 180);
         }
			// Propriétés du script
			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
			if (shot != null)
			{
				shot.isEnemyShot = isEnemy;
			}
			
			// Direction pour le mouvement
			MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
			if (move != null)
			{
				move.direction = this.transform.right; // ici la droite sera le devant de notre objet
			}            
		}
	}
	
	/// <summary>
	/// L'arme est chargée ?
	/// </summary>
	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
}