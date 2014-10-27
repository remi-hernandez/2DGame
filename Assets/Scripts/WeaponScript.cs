using UnityEngine;

/// <summary>
/// Crée des projectiles
/// </summary>
public class WeaponScript : MonoBehaviour
{
	//--------------------------------
	// 1 - Designer variables
	//--------------------------------
	
	public Transform shotPrefab; // prefab du projectile
   public float shootingRate = 0.25f; // temps de rechargement entre deux tirs
   public PlayerScript player; // sert pour la direction du tir
   public MoveScriptPoulpi poulpi; // sert pour la direction du tir
	public bool playerUser;
   public bool poulpiUser;
	
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
      if (player == null)
      {
         print("the player is null \n");
      }
		if (CanAttack)
		{
			shootCooldown = shootingRate;
			var shotTransform = Instantiate(shotPrefab) as Transform; // Création d'un objet copie du prefab
			shotTransform.position = transform.position; // position

         if (playerUser == true)
         {
            print("I'm the player\n");
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
         }
         else if (poulpiUser == true)
         {
            print("I'm the poulpi\n");
            if (poulpi.rightDirection == true)
            {
               shootPosition.x = transform.position.x + 3;
               shootPosition.y = transform.position.y;
               shotTransform.position = shootPosition;
            }
            else
            {
               shootPosition.x = transform.position.x - 3;
               shootPosition.y = transform.position.y;
               shotTransform.position = shootPosition;
            }
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