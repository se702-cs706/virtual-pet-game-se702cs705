# virtual-pet-game-se702cs705

<b>A Video Game for Testing User Affection and Attachment based on Visual Perception of Virtual Pets</b><br />
by @afon072, @AoMedium, @JoelDsouza01, @jzho987, @lche262, @Plak-xD, @timelesswanderder24.

## Motivation
This virtual-pet game was developed to support a research study of "How does people's perception of virtual-pets affect their ability to form attachments and get movtivated to interact with them". Such a goal was sought after as an extension of findings on the Uncanny Valley: a theory stating that the human likeness of a virtual character and perception of familiarity from the audience are positively correlated, with the exception of a drastic dip of familiarity just before full realism as shown in Fig 1.<br /><br />
![alt text](https://ars.els-cdn.com/content/image/1-s2.0-S1071581917301593-gr1.jpg)<br />Figure 1 - The Uncanny Valley, a Drop of Familiarity when Character Appearance is Nearly Realistic, but Slightly Off (https://www.sciencedirect.com/science/article/pii/S1071581917301593)<br /><br />The referenced paper inspected realisticness against familiarty in static images, however it did not extend the research into the domain of video games, the target field that our team wishes to push the established research into. Additionally, the focus was shifted from measuring familiarity to affection and user attachments to align better with common research directions in the sub-domain of virtual pets.<br /><br />
We believe our research can help encourage a wider usage of virtual pets by helping people get motivated to interact with them and form attachments with them, providing users with benefits such as mental health, education, and relaxation and companionship.

## System Prerequisites
As the game is rendered with unity's HDRP, only these following systems work with the requirement. (Taken from Unity's Website https://unity.com/how-to/getting-started-with-hdrp)
- Windows and Windows Store, with DirectX 11 or DirectX 12 and Shader Model 5.0
- Modern consoles (minimum Sony PlayStation 4 or Microsoft Xbox One)
- MacOS (minimum version 10.13) using Metal graphics
- Linux and Windows platforms with Vulkan

For optimal game experience and performance, we suggest to use the following configuraion:
- Processor: Intel Core i5 or equivalent
- Memory: 8 GB RAM
- Storage: 1 GB available space
- Graphic Card: optional

## Technology
We are using Unity-Engine version 2022.3.8f1 as the current latest LTS version.
We are using Firestore Database to persist interaction data. One using this repository should be able to connect up their own Firebase account to the game.

## How to run
TODO

## Playing the Game
The game will give you a small environment to play with the dog, but first there are some options given to the player. <br /><br />
When you enter the game, you will begin with a menu as seen in Fig z. If you press play, you will be allowed to choose between the two models, and your choice will lead you straight into the game with the model of your choosing. You can also select mode to switch between Practice and Study, where Study will actively read data about the game while you play for the sake of the study, while practice will not.<br /><br />
![image](https://github.com/se702-cs706/virtual-pet-game-se702cs705/assets/79771780/05653fe7-9771-4a58-8b1a-403431378f8a)<br />Figure z - Main Menu Where You Can Choose the Mode and Start Playing<br /><br />
In the game, you will find a small park with the dog and some other items for the environment. The dog will act on its own by walking around and eating, but you can call to yourself by holding <b>V</b> and pressing <b>2</b>, like in Fig a. Alternatively, holding <b>V</b> and pressing <b>1</b> will instruct the dog to sit down.<br /><br />
![image](https://github.com/se702-cs706/virtual-pet-game-se702cs705/assets/79771780/476e59ae-e98e-443d-a96b-f3cf06082a90)<br />Figure a - Player Holding Down <b>V</b> to Open the Instruction Popup<br /><br />
While you are close enough to the dog and looking at it, you can press <b>Left Click</b> to pet the dog, displayed in Fig b. There will also be a ball in the map which you can pick up by pressing <b>Left Click</b> and throw by pressing <b>Q</b>.<br /><br />
![image](https://github.com/se702-cs706/virtual-pet-game-se702cs705/assets/79771780/6037462e-89c3-4f47-b994-4d969cc141c1)<br />Figure b - User Interacting with Dog. Ball is Also Shown in the Background.<br /><br />
At any moment, you can press <b>P</b> to open the menu, which you can use to either go to the main menu, or change the dog model on the fly.

## Future Work
As this project was completed within the time frame of a bit over 1 month, a lot more work can be done on the project as well as the research study. This section will go over how to add to the code base and follow "best practice".

### Character
#### How to Add Controls
Adding new player controls requires modifying the files "CharacterPresenter" and "PlayerController" located in the folder "Assets/Scripts/Character/". Key binds can be added/modified in "KeyBindings" and "InputView".

The "CharacterPresenter" handles incoming key presses then calls the appropriate function in the "PlayerController". Key presses come from "InputView".

The "PlayerController" handles all the physics and movement of the player (what the player can do). This can be movement dictated by key presses (e.g. WASD for walking), or physics (e.g. player can walk up slopes).

### Dog

#### Adding Models
Adding new models is done by adding new objects under the <i>DogPrefab</i> object inside the Scene. Within this object, there is a hierarchy of Unity objects called "Retriever_Color_1", which contains every bone of the dog model. A portion of this hierarchy is shown in Fig y.<br /><br />
![image](https://github.com/se702-cs706/virtual-pet-game-se702cs705/assets/79771780/9f93966c-95a7-4e11-aeb7-9a3b44d18281)<br />Figure y - Snippet of the Hierarchy of Retriever_Color_1, Where Any Element Starting with "Capsule" is a Part of the Bad Model, While all Others are a Part of the Good Model<br /><br />These bones are what creates the dog model, and you can add your own Unity objects such as capsules or spheres under them as you desire. They will then follow the movement and rotation of the bone they are attached to. Using this, you can create your own low-fidelity dog models. Keep in mind that each object in the hierarchy have had their <i>Layer</i> parameter set to define which of the models they are apart of (All of the bones of the good model are in the "BetterDog" layer, and all of the capsules of the bad model are in the "CapsuleDog" layer.) The Player Camera can then choose which layer it can and cannot currently see to change between the models. So, in other words, all of the models always exist, the camera simply changes which ones it can and cannot see to change the dog model.

#### How to Add States
States are the driving force making the dog perform all of its actions. Examples are: "ActionState" can play an animation from the dog's animator, and "WaitingState" will have the dog sit still and follow the playing around.

Adding a new state requires creating new "Concrete States" in the folder "Assets/Scripts/States
/ConcreteStates/". For each new Concrete State to be added, a new State Parameter class should be defined along with it. This parameter is how the State Factory will use to instantiate a new state.

Each State has a State Enter, State Update, and State Exit function that defines the State. Abstract States define some of these. Any state using "Goal State" as a base state has to define a goal condition in which the state will run the new Update function until the goal condition returns true. Any state using "Timed State" as a base state overrides the goal condition as the pre-allocated time running out. The Exit condition can also be defined by returning a non-null State object during the Update. This way the state can be exited before the goal is completed.

### Point Of Interest
Point of Interests (POIs) are how Dog Interactions are handled. Each object the dog can interact with has a PointOfInterest component. This component stores relevant parameters for defining the interaction. 

If the point of interest should also have a specific interaction to be performed, that can be defined by adding a DogInteraction Object to the GameObject. DogInteraction is not a full class and each new interaction should inherit the DogInteraction class and implement the on Start, on Update and on Exit functions, which define the interaction. 

Note: the current implementation does not allow for the interaction to define an exit and the time has to run out. The interaction is played by the InteractionState, and the dog will start in that state when trying to interact with the POI.

#### Navigation
The dog cannot navigate the environment on it's own, and needs help to let it know where it can go and how. This is done through two separate parts: the NavMesh baked into the scene and the NavMeshAgent attached to the dog. The NavMesh will be discussed in the Scene section, and is recommended to understand before changing the dog's navigation.<br/><br/>
The NavMeshAgent on the dog is the element that allows it to register a NavMesh baked into a world and utilise it for navigation. It is essentially a built-in navigation package into Unity that simply requires you to bake a NavMesh of your choosing into a world and attach a NavMeshAgent onto an object, and uses these both to automatically perform pathfinding for the object it is attached to. You can give NavMeshAgents target coordinates to travel towards, and it will make use of the NavMesh to determine the shortest path to the target while abiding to the restrictions of the NavMesh. For example, if you create a maze, give it a NavMesh and put a capsule with a NavMeshAgent on one side of the maze, setting the target destination of your NavMeshAgent to the other side of the maze will automatically make the capsule navigate the maze to make it to the target as efficiently as possible.<br /><br />
The project uses a script to control the dog's agent, found in the folder "Assets/Resources". It contains a variable called target which is used to define where the NavMeshAgent's target is. You only need to define this variable to your chosen location to make the dog move there. As it is a public variable, this assignment is usually done in external scripts such as behaviour states.

### Scene

#### NavMesh
The NavMesh is a map attached to the scene to tell the dog where it can and cannot walk. It allows you to take separate objects in the scene and individually declare them as walkable terrain or unwalkable obstacles. Through these tools, you can create a map of the game world and make your code-controlled entities avoid obstacles along with the space near them, while telling them which parts of the game world they are allowed to walk along. Fig x. shows a NavMesh baked into the world to define paths the dog can walk along. Keep in mind that the NavMesh only defines where code-controlled entities such as the dog can and cannot walk; they have no impact on where the player is allowed to walk.<br /><br />
![image](https://github.com/se702-cs706/virtual-pet-game-se702cs705/assets/79771780/204ba93d-5b41-4862-8ba5-eee621f45d18)<br />Figure x - NavMesh Baked into the World, Where the Light Blue Region is Walkable Land for Entities, and Obstacles Cut Their Own Unwalkable Regions Around Them<br /><br />To create a NavMesh for objects in a scene, open the scene in Unity and go to <i>Window > AI > Navigation (Obsolete)</i>. This will open a window on the right which allows you to define what NavMesh properties items have. Simply click on an item, then go to the <i>Object</i> tab in the window, and tick the <i>Navigation Static</i> field. This will make the chosen object contribute to the NavMesh, and the <i>Navigation Area</i> field can allow you to choose how it affects the NavMesh (E.g walkable, unwalkable etc...). Do this for whatever objects you want to contribute to the NavMesh, then change to the <i>Bake</i> tab in the window. From here, you can choose parameters such as the radius or height of denial unwalkable objects contribute. When you press <i>Bake</i>, your specified objects will have their NavMesh properties added to the world.

## Differences between the initial project plan and the implementation

Our initial project plan outlined the primary objectives and provided a general framework for our project. Since then, we have developed a more detailed virtual pet game to gauge user perception.
Below are the distinctions between our initial project plan and the final implementation:
*	New interactions that were not specified in the project plan were introduced. These include feeding the pet and the ability to issue voice commands like "sit, boy!" and "come here, boy!", as well as enabling the player to jump up and down.
*	Some specific interactions detailed in the project plan, such as filling water and scooping poop, were not implemented.
*	Other interactions detailed in the project plan, like throwing the ball and petting the dog, were successfully implemented.
*	We remained consistent with our choice of Unity as our game engine and used Firebase to store our data.


## Licences
