# virtual-pet-game-se702cs705

<b>A Video Game for Testing User Affection and Attachment based on Visual Perception of Virtual Pets</b><br />
by @afon072, @AoMedium, @JoelDsouza01, @jzho987, @lche262, @Plak-xD, @timelesswanderder24.

## Motivation
This virtual-pet game was developed to support a research study of "How does people's perception of virtual-pets affect their ability to form attachments and get movtivated to interact with them". Such a goal was sought after as an extension of findings on the Uncanny Valley: a theory stating that the human likeness of a virtual character and perception of familiarity from the audience are positively correlated, with the exception of a drastic dip of familiarity just before full realism as shown in Fig 1.<br /><br />
![alt text](https://ars.els-cdn.com/content/image/1-s2.0-S1071581917301593-gr1.jpg)<br />Figure 1 - The Uncanny Valley, a Drop of Familiarity when Character Appearance is Nearly Realistic, but Slightly Off (https://www.sciencedirect.com/science/article/pii/S1071581917301593)<br /><br />The referenced paper inspected realisticness against familiarty in static images, however it did not extend the research into the domain of video games, the target field that our team wishes to push the established research into. Additionally, the focus was shifted from measuring familiarity to affection and user attachments to align better with common research directions in the sub-domain of virtual pets.<br /><br />
We believe our research can help encourage a wider usage of virtual pets by helping people get motivated to interact with them and form attachments with them, providing users with benefits such as mental health, education, and relaxation and companionship.

## System Prerequisites
Stuff someone needs to run this

## Technology
We are using Unity-Engine version 2022.3.8f1 as the current latest LTS version.
We are using Firestore Database to persist interaction data. One using this repository should be able to connect up their own Firebase account to the game.

## How to run
TODO

## Playing the Game
What can they do while playing

## Future Work
As this project was completed within the time frame of a bit over 1 month, a lot more work can be done on the project as well as the research study. This section will go over how to add to the code base and follow "best practice".

### Character
#### How to Add Controls
Adding new player controls requires modifying the files "CharacterPresenter" and "PlayerController" located in the folder "Assets/Scripts/Character/". Key binds can be added/modified in "KeyBindings" and "InputView".

The "CharacterPresenter" handles incoming key presses then calls the appropriate function in the "PlayerController". Key presses come from "InputView".

The "PlayerController" handles all the physics and movement of the player (what the player can do). This can be movement dictated by key presses (e.g. WASD for walking), or physics (e.g. player can walk up slopes).

### Dog
#### How to Add States
States are the driving force making the dog perform all of its actions. Examples are: "ActionState" can play an animation from the dog's animator, and "WaitingState" will have the dog sit still and follow the playing around.

Adding a new state requires creating new "Concrete States" in the folder "Assets/Scripts/States
/ConcreteStates/". For each new Concrete State to be added, a new State Parameter class should be defined along with it. This parameter is how the State Factory will use to instantiate a new state.

Each State has a State Enter, State Update, and State Exit function that defines the State. Abstract States define some of these. Any state using "Goal State" as a base state has to define a goal condition in which the state will run the new Update function until the goal condition returns true. Any state using "Timed State" as a base state overrides the goal condition as the pre-allocated time running out. The Exit condition can also be defined by returning a non-null State object during the Update. This way the state can be exited before the goal is completed.

### Point Of Interest
Point of Interests (POIs) are how Dog Interactions are handled. Each object the dog can interact with has a PointOfInterest component. This component stores relevant parameters for defining the interaction. 

If the point of interest should also have a specific interaction to be performed, that can be defined by adding a DogInteraction Object to the GameObject. DogInteraction is not a full class and each new interaction should inherit the DogInteraction class and implement the on Start, on Update and on Exit functions, which define the interaction. 

Note: the current implementation does not allow for the interaction to define an exit and the time has to run out. The interaction is played by the InteractionState, and the dog will start in that state when trying to interact with the POI.

## Licences
