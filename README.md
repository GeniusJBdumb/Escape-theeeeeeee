# Escape-theeeeeeee repository for Escape the B
Escape the B is a small escape room 3D game. It was developed as a project for Introduction to Unity SS 2023 and serves as a submission for Group 42.
Followed up, we provide a description about our features, how to play the game and the way of building and programming our game.

NOTE: The game as Unity project has the name "Main and options escape thee Test". Initially we had an other thought about how we both are going to work on the project, but it turned out differently (see work flow). In the end we did not dare to change the file name and thereby risking that our project is gone.

## Table of Contents

- [Game Description](#game-description)
- [Features and Implementations](#featuresandimplementations)
- [Installation](#installation)
- [Usage](#usage)
- [Work flow](#workflow)
- [Some notes](#somenotes)
- [License](#license)

## Game Description

Game-Engine: Unity
Editor Version: 2021.3.2f1
Scaling/ screen size 16:9
Made as computer game for windows

Name: Escape the B
(B for Burger)

The Theme:
You are the Manager of the Restaurant "The big B" and you decided to take a quick nap. As you wake up you notice that it smells like fire. Fires are everywhere and one is blocking the exit. Your task is to escape the restaurant and save yourself by extinguishing all fires.

How?
Find the right fire extinguisher for each fire within the given time.

Movement:
- You can move with the "WASD" keys and rotate with the mouse.
- With the curser and by holding the left key you can drag and drop objects from the inventory.
- Collector objects can be collected by colliding with them.
- Interaction objects can be used by clicking "E" (The red Keypad for the main door).
- You can pause and resume with "P".
- You can jump with the "space" key.
- The doors for the toilets will open if you run against them on the side where a door usually would open.
- how to navigate menus: click on the respective buttons in the menus scenes


Caution:
When the time is up, then you have lost because you died from smoke poisoning.

## Features and Implementations

- We use the Player Inputmanager instead of the Unity Engine Inputsystem
- Scenes: Main Menu, Game Scene, Game Over Scene, Win scene
  Scene changes are made by using the buildindex.
- Pause Menu: by pressing "p"; has the same options like win and lose scenes just that it is a canvas in the game scene
- (Main) Menu features
  Options:
  1. Change between canvases of the scenes e.g. options & rules
  2. can quit the game
  3. can start the game
  4. can adjust the volume in options scene
  All scenes and the pause menu in the game scene use TMPro buttons which change their color if hovering or clicking. This is achieved by changing their highlight and click colors respectively. By this we do not need to 
  write extra code for this design feature. The background and color materials can be found in the respective folder.
- Music and sound:
  1. Volume slider in Options Canvas of main menu to adjust the volume
  2. Background Music
  3. Sound if one loses or wins
  4. fire sound if one is near of fire
- door and opening
  1. Hinge joint for the toilet doors
  2. self animated main door to be opened by interacting with a keypad
- Assets: self created fire extinguisher
- inventory
  1. max. 10 items
  2. drag and drop function
  3. text gets displayed when hovering over inventory pictures for objects
  4. slots change color when hovering and pressing (like buttons in menu scenes)
  5. we think the color is original
  6. it is a list
  7. NO prefabs since we do not need to instantiate objects at runtime. We have already everything we need in the scene. For the inventory, we just enable or disable the items
- text
  1. gets displayed when looking at an interactable object using raycast and prompt message as an interaction event
  2. timers get diplayed
  3. Coroutine display when one tries to extinguish fire with the wrong extinguisher or use the keypad before having everything extinguished and after main door opens
- timers:
- 1. counts down until game over: connected to lose condition and if it runs up the game over Scne is started
  2. counting time up needed to complete the game: time of it gets transferred from game scene on to the text field in the win scene to display the time needed to complete the game
- Implementations in order to easily expand the game considering
  1. new events, interaction objects, riddles (event only interactables (see editor folder)): can easily be added using the event interaction scripts
  2. playerinputs: Inputmanager (can easily add new movements and not only from keyboard but e.g. from gamepad controllers)
     -> Playerinput was implemented completely for usage with keypad and mouse but movements also implemented for gamepad (because of time reasons it was not implemented for the other actions)
  3. collector objects: scripts for inventory items are built such that one can easily copy the script of e.g. the fire extinguisher and just needs to adjust name and picture to make the new object available as     
     collector object
  4. Timer: can easily create new timers with and without limit and different possibilities of displaying the time (see: Timer script)
- for editors: the roof is transparent from one side to easily work in the scene but if one plays one sees a roof


## Installation

1. Clone the repository using `git clone [repository URL]`.

Option 1: Double click on the game with the Burger icon and play the game

Option 2:
3. open project in Unity Hub
4. go to MainMenu scene
5. press play.

## Usage

Goal: Find the right fire extinguisher for each fire within the given time.

Movement:
- You can move with the "WASD" keys and rotate with the mouse.
- With the curser and by holding the left key you can drag and drop objects from the inventory.
- Collector objects can be collected by colliding with them.
- Interaction objects can be used by clicking "E" (The red Keypad for the main door).
- You can pause and resume with "P".
- You can jump with the "space" key.
- The doors for the toilets will open if you run against them on the side where a door usually would open.
- how to navigate menus: click on the respective buttons in the menus scenes

Win:
- If you extinguished all fires, press the key to open the door and ran out of the door within the given time

Lose:
- If the time has run out and you did not run out of the door

## Workflow
We thought It would be good if one works on the game scene and one on the features. And then we would just put the features in the main game at the end. 
I (Johanna) started with the basic functions.
Initially, we had a main Project and my version with the main Menu. In the process of building the base functions and scenes, I noticed that for creating a Main Menu scene I need a game scene. That I need a player for Movement. That I need space and room to test gravity and collision. That I need objects to implement inventory and interact functions……….. Finally, for getting to the different scenes like Win and Game Over, I needed the conditions for it. In the end, I had the base for a game, from start to finish but not the game itself. Just all basic needed functionalities every game needs. We then thought it would be easier to just take my initial thought to be a side project. That is why the project has now the other name.  
From there on Lena took over and used my functions and scripts and expanded them. She added a real scene, assets and actually the game we thought of: the riddle that one needs to extinguish the fires. She implemented the game on the basis of my raw model. She also made our fire extinguisher assets.
Together we fixed the last problems.
Therefore first I made a lot of commits and then Lena.
For the Problems please have a look at the document “Problems and Fixes” in our group folder. There we listed some of the major problems.

## Some notes: 
We still included Debug.Logs which get displayed if one plays the game in the Unity editor to assure that everything works fine during playing. 
In the code, you find comments which explain functions and functionalities.
We commented out some Debug.Log messages. These can be used later if one wants to expand and further develop the game because at these points most changes might be done and most errors might arise. But they are not relevant for the current state of the game and the general checking if the current game works as intended. This provides the feature that one can just simply "decomment" the debugs and use them again and one has directly a clue where to search for possible problems.

Finally, If you have any questions or want further elaboration on any of the points we are glad to answer them.

## License

The project is solely for educational purposes and not for commercial use.
