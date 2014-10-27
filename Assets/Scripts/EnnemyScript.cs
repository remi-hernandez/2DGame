using UnityEngine;

/// <summary>
/// Enemy generic behavior
/// </summary>
public class EnemyScript : MonoBehaviour
{
   private WeaponScript weapon;

   void Awake()
   {
      // Retrieve the weapon only once
      print("BWARG\n");
      weapon = GetComponent<WeaponScript>();
   }

   void Start()
   {
      print("Alexis pd\n");
   }

   void Update()
   {
      // Auto-fire
      print("I'm firing SON OF A BITCH\n");
      if (weapon != null && weapon.CanAttack)
      {
         weapon.Attack(true);
      }
   }
}