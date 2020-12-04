***MathForGames2020 Assessment!***

**Game.cs**

*public static int CurrentSceneIndex*
    
    this function returns _currentSceneIndex

*public static void SetGameOver(bool value)*

    this function sets _gameOver to "value"

*public static Scene GetCurrentScene()*

    this function returns _scenes[index]

*public static int AddScene(Scene scene)*

    this function tells the program to add a new scene into the Scene tempArray

*public static bool RemoveScene(Scene scene)*

    this function tells the program to remove a specified scene from the Scene tempArray

*public static void SetCurrentScene(int index)*

    this function sets the current scene in the game

*public static bool GetKeyDown(int key)*

    this function checks to see if a key is being held down on the keyboard

*public static bool GetKeyPressed(int key)*

    this function checks to see if a key is being pressed on the keyboard

*public void Start()*

    this function happens instantly when the game is started
    it sets up the Raylib window and target fps
    it sets up the console window to not show the cursor and gibe it a title
    it sets 2 new scenes and adds a Space
    it initializes 15 enemy actors and 1 player actor and sets their scales
    it sets each enemies target to be player
    it sets the player and enemie's rotations
    it puts all the actors into the first scene
    it sets the player speed to 5
    it sets an integer called startingSceneIndex to 0
    finally it adds scene1 and scene2 to startingSceneIndex

*public void Update(float deltaTime)*
    
    this function is called during every frame that the game is running

*public void Draw()*

    this function draws the actors into the raylib window

*public void End()*

    this function is called once the game ends


**scene.cs**

*public Matrix3 World*

    this function returns _transform

*public void AddActor(Actor actor)*

    this function adds an actor to the array of actors and put it into the scene

*pubilc bool RemoveActor(int index)*

    this function removes an actor from the array and from the scene


**Actor.cs**

*public Vector2 forward*

    this returns a new Vector2(_globalTransform.m13, _globalTransform.m23)

*public Vector2 WorldPositon*

    this returns a new Vector2 (_globalTranform.m13, _globalTransform.m23)

*public Vector2 LocalPosition*

    this returns a new Vector2 (_localTransform.m13, _localTransform.m23)
    this then sets _translation.m13 to value.X
    this then sets _translation.m23 to value.Y

*public Vector2 Velocity*

    this returns _velocity and sets it to "value"

*protected Vector2 Acceleration*

    this returns _acceleration and sets it to "value"

*public float MaxSpeed*

    this returns _maxspeed and sets it to "value"

*public float Speed*

    this returns _speed and sets it to "value"

*public Actor(floatx, floaty, char icon = ' ', ConsoleCollr color = ConsoleColor.White)*

    this constructor takes in a _raycolor, _icon, _localTransform, LocalPosition, _velocity, and _color

*public bool AddChild(Actor child)*

    this function will add a "child" actor to a "parent" actor

*public bool RemoveChild(Actor child)*

    this funciton will remove a "child" actor from a "parent" actor and the scene alltogether

*public bool CheckCollision(Actor other)*

    this function checks to see if two sprites have collided

*public virtual void OnCollision(Actor other)*

    this function handles what happens when collision is detected

*public void SetTranslate(Vector2 position)*

    this function sets the translation of an actor

*public void SetRotation(float radians)*

    this function sets the rotation of an actor

*public void SetScale(float x, floaty)*

    this function sets the scale of an actor

*private void UpdateTransforms()*
    
    this function updates the current transforms of current actors


**Player.cs**

*public Player (floatx, floaty, char icon = ' ', ConsoleColor color = ConsoleColor.Magenta)*

    this constructor takes in the base Actor class and then takes in a sprite

*public void CreateProjectile(Laser laser)*

    this function allows the actors to shoot lasers


**Enemy.cs**

*public Actor Target*

    this sets _target to "value"

*public bool CheckTargetInSight(float maxAngle, float maxDistance)*

    this function checks to see if the actor set as target is in their line of sight


**Sprite.cs**

*public int Width*
    
    this sets the width of the sprite

*public int Height*

    this sets the height of the sprite

*public Sprite(Texture2D texture)*

    this initializes the sprites texture

*public Sprite(string path)*

    this tells raylib to load the sprite texture



****MathLibrary!!!****


**Vector2.cs**

*public float X*

    this sets x to "value"

*public float Y*

    this sets y to "value"

*public float Magnitude*

    this sets up the equation to take the square root of (X * X + Y * Y)

