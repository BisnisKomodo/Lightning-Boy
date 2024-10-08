## 🔴About
Lightning boy remains as my first simple game, inspired by Super Mario Bros where you gotta jump and avoid obstacle in order to reach to your winning places. I built the player movement system, Climbing System, Healthcontroller and the kill system for the player when falling to lava or touch nearby obstacle. Here's a small portion details about Lightning Boy development presented,
<br>

## 🕹️Play Game
The game was built using Unity Engine. Play the game from https://bisniskomodo.itch.io/lightning-boy. 
<br>

## 👤Developer
- Nicholas Van Lukman (Game Programmer)
- Kezia Pricillia Ong (Game Artist)
<br>

## 📂Files description

```
├── Lightning boy                     # Contain everything needed for Lightning Boy to works.
   ├── .vscode                        # Contains configuration files for Visual Studio Code (VSCode) when it's used as the code editor for the project.
      ├── extensions.json             # Contains settings and configurations for debugging, code formatting, and IntelliSense. This folder is related to Visual Studio Code integration.
      ├── launch.json                 # Contains the configuration necessary to start debugging Unity C# scripts within VSCode.                     
      ├── setting.json                # Contains workspace-specific settings for VSCode that are applied when working within the Unity project.
   ├── Assets                         # Contains every assets that have been worked with unity to create the game like the scripts and the art.
      ├── Art                         # Contains all the game art like the sprites, background, even the character.
      ├── Game Animation              # Contains every animation clip and animator controller that played when the game start.
      ├── Game Musics                 # Contains every sound used for the game like music and sound effects.
      ├── Game Scripts                # Contains all scripts needed to make the gane get goings like PlayerMovement scripts.
      ├── Prefabs                     # Contains every pre-configured, reusable game object that you can instantiate (create copies of) in your game scene.
      ├── Scenes                      # Contains all scenes that exist in the game for it to interconnected with each other like MainMenu, Gameplay, etc
      ├── ThirdParty Packages         # Contains the Package Manager from unity registry or unity asset store assets for game purposes.
   ├── Packages                       # Contains game packages that responsible for managing external libraries and packages used in your project.
      ├── Manifest.json               # Contains the lists of all the packages that your project depends on and their versions.
      ├── Packages-lock.json          # Contains packages that ensuring your project always uses the same versions of all dependencies and their sub-dependencies.
   ├── Project Settings               # Contains the configuration of your game to control the quality settings, icon, or even the cursor settings
├── README.md                         # The description of Lightning Boy file from About til the developers and the contribution for this game.
```
<br>

## 📜Lightning Boy Scripts Example (PlayerMovement)
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpingpower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D rb2d;
    private Animator anim;
    private BoxCollider2D boxcollider;
    private float walljumpcooldown;
    private float horizontalinput;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxcollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate() 
    {
        horizontalinput = Input.GetAxis("Horizontal");

        //flipping the character sprite according to our A and D movement
        if(horizontalinput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalinput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //Animator parameter setting
        anim.SetBool("run", horizontalinput != 0);
        anim.SetBool("grounded", isGrounded());
        if (rb2d.velocity.y < -0.1f && isGrounded())
        {
            anim.SetBool("isjumping", false);
        }

        //wall jump kaya mario
        if (walljumpcooldown < 0.2f)
        {
            rb2d.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb2d.velocity.y);

            if (onwall() && !isGrounded())
            {
                rb2d.gravityScale = 0;
                rb2d.velocity = Vector2.zero;
                 anim.SetBool("wallstay", true);
            }
            else
            {
                rb2d.gravityScale = 6f;
                 anim.SetBool("wallstay", false);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }
        }
        else
        {
            walljumpcooldown += Time.deltaTime;
        }
    }

    private void Jump()
    {
        if (isGrounded())
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpingpower);
            anim.SetTrigger("jump");
            anim.SetBool("isjumping", true);
        }
        else if (onwall() && !isGrounded())
        {
            anim.SetBool("wallstay", true);
            if (horizontalinput == 0)
            {
                rb2d.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 80f, 10);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                rb2d.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 0.001f, 6);
            }
            walljumpcooldown = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D ded) 
   {
        if(ded.collider.CompareTag("void"))
        {
            SceneManager.LoadScene("Retrying");
        }
   }

    private bool isGrounded()
    {
        RaycastHit2D raycasthit = Physics2D.BoxCast(boxcollider.bounds.center, boxcollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycasthit.collider != null;
    }

    private bool onwall()
    {
        RaycastHit2D raycasthit = Physics2D.BoxCast(boxcollider.bounds.center, boxcollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycasthit.collider != null;
    }
}
```
