# Master Unity Game Development in 30 Days: 25+ Game Projects

## Setting up the Environment
* Installing Unity Hub via Winget
```bash
winget install Unity.UnityHub
```

* Installing Unity 6.1 (6000.1.4f1) from Unity Hub with required build supports
* Installing Microsoft Visual Studio Community 2022
* Setup both as requried

## Project 1: Carrot Collector Game (2D)
* External Assets Used
  * Sprites from Udemy Course
  * ["Joystick Pack" asset by Fenerax Studios](https://assetstore.unity.com/packages/tools/input-management/joystick-pack-107631)

* Scripts
  * PlayerController handles joystick input, player movement, boundary checking and collision with collectibles
  * CollectiblesController handles spawning of Carrots, keeping track of score and handling win condition
  * UIManager handles quitting game, changing scenes and toggling of UI elements

Windows and Android Build are [HERE](https://github.com/anir183/udemy-unity-30-days/releases/tag/CarrotCollector)

## Project 2: Dodging Game (3D)
* Scripts
  * PlayerController handles touch and ext keyboard/joystick/etc input, movement of player and gradual increase of movement speed
  * ObstaclesSpawner handles spawning of obstacles and game difficulty by gradually increasing number, density and speed of obstacles
  * UIManager handles quitting game, changing scenes and toggling of UI elements

Windows and Android Build are [HERE](https://github.com/anir183/udemy-unity-30-days/releases/tag/DodgingGame)
