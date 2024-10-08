using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathvoid : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D ded) 
   {
        if(ded.collider.CompareTag("void"))
        {
            SceneManager.LoadScene("Retrying");
        }
   }
}
