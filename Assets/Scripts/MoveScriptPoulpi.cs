using UnityEngine;
using System.Collections;

/// <summary>
/// Déplace l'objet
/// </summary>
public class MoveScriptPoulpi : MonoBehaviour
{
   // 1 - Designer variables

   /// <summary>
   /// Vitesse de déplacement
   /// </summary>
   public Vector2 speed = new Vector2(5, 5);

   /// <summary>
   /// Direction
   /// </summary>
   public Vector2 direction = new Vector2(-1, 0); // sert pour weaponScript - a changer quand change de direction
   private Vector2 directionLeft = new Vector2(-1, 0); // a passer en private
   private Vector2 directionRight = new Vector2(1, 0); // a passer en private

   private Vector2 movement;
   private Vector2 movementLeft;
   private Vector2 movementRight;
   public int cptMvtMax = 150;
   private int cptMvt = 0;

   void calculMvt()
   {
      print("Calcul direction\n");
      movementLeft = new Vector2(
         speed.x * directionLeft.x,
         speed.y * directionLeft.y);

      movementRight = new Vector2(
         speed.x * directionRight.x,
         speed.y * directionLeft.y);
      if (cptMvt == cptMvtMax)
      {
         if (movement == movementLeft)
            movement = movementRight;
         else
            movement = movementLeft;
         cptMvt = 0;
      }
      else
         cptMvt++;
   }

   void Update()
   {
      // 2 - Calcul du mouvement
      calculMvt();
   }

   void FixedUpdate()
   {
      // Application du mouvement
      // rigidbody2D.velocity = movementLeft;
      // System.Threading.Thread.Sleep(1000);
      // rigidbody2D.velocity = movementRight;

      rigidbody2D.velocity = movement;
   }
}