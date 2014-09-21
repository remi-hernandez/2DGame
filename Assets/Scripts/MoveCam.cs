using UnityEngine;
using System.Collections;

public class MoveCam : MonoBehaviour
{

   public GameObject Player;
   private Vector3 Pos;

	// Use this for initialization
	void Start()
   {
	
	}
	
	// Update is called once per frame
	void Update()
   {
      Pos.x = Player.transform.position.x + 10; // Correspond au décalage de la caméra pour cadrer le joueur a gauche et un peu vers le bas.
      Pos.y = Player.transform.position.y + 3;
      Pos.z = -10;

      transform.position = Pos;
  	}
}
