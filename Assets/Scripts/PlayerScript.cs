using UnityEngine;
using System.Collections;

/// <summary>
/// Contrôleur du joueur
/// </summary>
public class PlayerScript : MonoBehaviour
{
	/// <summary>
	/// 1 - La vitesse de déplacement
	/// </summary>

	//public Vector2 speed = new Vector2(50, 50);
	
	// 2 - Stockage du mouvement
	// private Vector2 movement;
   private bool 	Jumped = false;
   private int nbJumps = 0;
   private System.DateTime timeJumped = System.DateTime.Now;
   public float speed = 8f;
   public Transform checkSol;
   bool toucheLeSol = false;
   float rayonSol = 0.3f;
   public LayerMask sol;

   void Update()
	{
		// 3 - Récupérer les informations du clavier/manette
		float inputX = Input.GetAxis("Horizontal");
		//float inputY = Input.GetAxis("Vertical");

		if (Input.GetButtonDown("Jump"))
		{
			Jumped = true;
			//rigidbody2D.AddForce(new Vector2(0, 200));
			//transform.Translate (0, 1, 0);
			//print("JUMP LA PUTE");
		}

		// 4 - Calcul du mouvement
		if (inputX > 0) 
		{
			transform.Translate(inputX * speed * Time.deltaTime, 0, 0);
			transform.eulerAngles = new Vector2(0, 0);
		}

		if (inputX < 0)
		{
			transform.Translate(- inputX * speed * Time.deltaTime, 0, 0);
			transform.eulerAngles = new Vector2(0, 180);
		}
		/*
		movement = new Vector2(
			speed.x * inputX,
			speed.y * inputY);
		*/
		// 5 - Tir
		bool shoot = Input.GetButtonDown("Fire1");
		shoot |= Input.GetButtonDown("Fire2");
		// Astuce pour ceux sous Mac car Ctrl + flèches est utilisé par le système
		
		if (shoot)
		{
			WeaponScript weapon = GetComponent<WeaponScript>();
			if (weapon != null)
			{
				// false : le joueur n'est pas un ennemi
				weapon.Attack(false);
			}
		}
		
	}

	void FixedUpdate() // utilisé quand on doit appliquer une force a un rigidbody (modifications physiques mieux pris en charge)
	{
      var seconds = (System.DateTime.Now - timeJumped).TotalSeconds;
      toucheLeSol = Physics2D.OverlapCircle(checkSol.position, rayonSol, sol);
      
		// 5 - Déplacement
      // print("seconds : " + seconds);
      if (seconds >= 0.20)
         nbJumps = 0;
		if (toucheLeSol && Jumped || Jumped && nbJumps >= 1 && nbJumps < 2) 
		{
         nbJumps += 1;
			Jumped = false;
			rigidbody2D.AddForce (new Vector2 (0, 19800));
         timeJumped = System.DateTime.Now;
		}
      if (nbJumps == 2)
         nbJumps = 0;
	}
}