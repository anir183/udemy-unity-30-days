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
* Create a new Universal 2D (Core) project
* Order things in a folder structure
* Download sprite for the game provided in course
* Download the ["Joystick Pack" asset by Fenerax Studios](https://assetstore.unity.com/packages/tools/input-management/joystick-pack-107631)
* Create the Menu and Game scenes
* Making the scripts for PlayerController, CollectablesController and UIManager
* PlayerController handles joystick input, player movement, boundary checking and collision with collectibles
* CollectiblesController handles spawning of Carrots, keeping track of score and handling win condition
* UI manager handles quitting game, changing scenes and toggling of UI elements

Windows and Android Build are [HERE](https://github.com/anir183/udemy-unity-30-days/releases/tag/CarrotCollector)
