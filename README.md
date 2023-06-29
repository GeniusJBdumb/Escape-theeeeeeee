# Escape-theeeeeeee
Repository for Escape room game for Introduction to Unity SS 2023 Group 42 CogSci
Escape-theeeeeeee is a small ecape room 3D game. It was developed as a project for Introduction to Unity SS 2023 and serves as a submission for Group 42.
Followed up, we provide a description about our features, how to play the game and the way of building and programming our game.

NOTE: the game as Unity project has the name "Main and options escape thee Test". Initially we had an other thought about how we both are going to work on the project, but it turned out differently (see work flow). In the end we did not dare to change the file name and thereby risking that our project is gone.

## Table of Contents

- [Game Description](#game-description)
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Work flow](#workflow)
- [License](#license)

## Game Description

Game-Engine: Unity
Editor Version: 2021.3.2f1

The Theme:
You are the Manager of the Restaurant "The big B" and you decided to take a quick nap. As you wake up you notice that it smells like fire. Fires are everywhere and one is blocking the exit. Your task is to escape the restaurant and save yourself by extinguishing all fires.

How?
Find the right fire extinguisher for each fire within the given time.

Movement:
- You can move with the "WASD" keys and rotate with the mouse.
- With the curser and left key you can drag and drop objects from the inventory.
- Collector objects can be collected by colliding with them.
- Interaction objects can be used by klicking "E" (The Keypad for the main door).
- You can pause and resume with "P".
- You can jump with the "space" key.
- The doors for the toilet will open if you run against them.

Caution:
When the time is up, then you have lost because you died from smoke poisoning.
Have fun and good luck!

## Features

- We use the Player Inputmanager instead of the Unity Engine Inputsystem
-Scenes: Main Menu, Game Scene, Game Over, Win (scene change using buildindex)
- Main Menu features
  Buttons of Text Mesh Pro: have option to change between canvases of options, rules,
  can quit and start the game
- All scenes and the pause menu in the game scene use TMPro buttons which change their color if hovering or klicking . This is achieved by changing their colors respectively. By this we do not need to write extra code for this feature.
- Main Menu Option: Volume slider
- Music + Sound if lost or won
- Hinge joint for the toilet doors
- self animated main door
- NO prefabs since we do not need to instantiate objects at runtime
- self created fire extinguisher asset
- inventory
  max. 10 items, drag and drop function, text displayed when hovering over inventory objects, pictures for objects, slots change color when hovering and pressing (like buttons in menu scenes), we think the color is original, it is a list
- text displayed when looking at object using raycast and promp message as interaction event
- 2 timers: 1. counts down until game over; 2. counting time needed to complete the game
  1. connected to lose condition. 2. time of it gets transfered from game scene on to text field    in win scene to display the time needed to complete the game
- text if wrong fire extinguisher gets used to try to extinguish the wrong fire
- Implementations in order to easily expand the game considering
  1. new events, interaction objects, riddles (eventonly interactables (see editor folder))
  2. playerinputs: Inputmanager (can easily add new movements e.g. not only from keyboard but from gamepad controlers) -> Playerinput implemented completely for usage with keypad and mouse but movements also implemented for gamepad (because of time reasons it was not implemented for the other actions)
  3. collector objects: scripts for inventory items are build such that one can easily copy the script of e.g. the fire extinguisher and just needs to adjust name and picture to make the object available as collector object
  4. Timer: can easily create new timers with and without limit and different possibilities of displaying (see: Timer script)
- Pause Menu: by pressing "p"; has same options like win and lose scenes just that it is a canvas in the game scene
- for editors: the roof is transparent from one side to easily work in the scene but if one plays one sees a roof


## Installation

Provide instructions on how to install and set up the game locally. This can include:

1. Clone the repository using `git clone [repository URL]`.
Option 1:
Make double klick on the game with the Burger icon and play the game

Option 2:
3. open project in Unity Hub
4. go to MainMenu scene
5. press play.

## Usage

Goal: Find the right fire extinguisher for each fire within the given time.

Movement:
- move with the "WASD" keys
- rotate with the mouse
- With the curser and holding left key you can drag and drop extinguishers from the inventory on fires.
- Collect fire extinguishers by running against them
- focus on the red keypad and klick "E" to open the main door).
- pause and resume with "P"
- jump with the "space" key.
- The doors for the toilet will open if you run against them.
- Instructions on how to navigate menus: klick on the respective buttons in the menus scenes
- Gameplay controls

Win:
- If you extinguished all fires, pressed key for door and ran out of the door within the given time frame

Lose:
- If the time has run out and you did not run out of the door

## Workflow
We thought It would be good if one works on the game scene and one on the features. And then we would just put the features in the main game at the end. 
I (Johanna) started with the basic functions.
Initially we had a main Project and my version with the main Menu. In the process of building the base functions and scenes, I noticed that for creating a Main Menu scene I need a game scene. That I need a player for Movement. That I need space and room to test gravity and collision. That I need objects to implement inventory and interact functions……….. Finally, for getting to the different scenes like Win and lose, I needed the conditions for it. In the end I had the base for a game, from start to finish but not the game. Just all basic needed functionalities. We then thought it would be easier to just take my initial thought to be a side project.  
From there on Lena took over and used my functions and scripts and expanded them. She added a real scene, assets and actually the game we thought of: the riddle that one needs to extinguish the fires. She implemented the game on the basis of my raw model. She also made our fire extinguisher assets.
Together we fixed the last problems.
Therefore first I made a lot of commits and then Lena.
For the Problems please have a look in the document “Problems and Fixes” in our group folder.

Note: We still included Debug.Logs which get displayed if one plays the game in the Unity editor. In the code you find comments which explain functions and functionalities and we commented out some Debug.Logs which can be used later if one wants to expand and further develop the game. This provides the feature that one can just simple "decomment" the debugs and use them again.

## License

The project is solely for educational purposes and not for commercial use.
