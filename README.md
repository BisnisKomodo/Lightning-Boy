<table>
  <tr>
    <td align="left" width="50%">
      <img width="100%" alt="gif1" src="https://github.com/user-attachments/assets/c2e75d74-4e36-4b87-b083-e829d74aaec0">
    </td>
    <td align="right" width="50%">
      <img width="100%" alt="gif2" src="https://github.com/user-attachments/assets/60b047cc-980c-4e22-a126-75aa312dbb17">
    </td>
  </tr>
</table>

<p align="center">
  <img width="100%" alt="gif3" src="https://github.com/user-attachments/assets/0041c7f1-6260-4cba-b1b1-31c6fcd7059d">
</p>

##  📜Scripts and Features

You are able to do so many stuff in the game like walking, running, building, crafting, shooting, hunting, and so much more thanks to tons of scripting has been implemented to the game

|  Script       | Description                                                  |
| ------------------- | ------------------------------------------------------------ |
| `PlayerMovement.cs` | Responsible for the playermovement using platformer way horizontally |
| `MainMenu.cs` | Responsible for all the menu like MainMenu, Credit Scene, Tutorial and etc |
| `DeathVoid.cs`  | Responsible the void below that appear as lava so player dies |
| `GameManager.cs`  | Responsible for the player to collide with the winning trigger |
| `etc`  | |

<br>







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

<br>

## 🕹️Game controls

The following controls are bound in-game, for gameplay and testing.

| Key Binding       | Function          |
| ----------------- | ----------------- |
| W,A,S,D           | Standard movement |
| Space             | Jump           |
| Space (Hold)             | Jump Dash             |

<br>
