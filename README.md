# Ball Breaker Game

This is a 2D "Ball Breaker" style game where you control a paddle to bounce a ball and break bricks. The game includes power-ups, different ball types, and progression through levels. This project is built using Unity and involves game mechanics such as ball movement, paddle control, brick destruction, and power-ups.

## Features

- **Ball Mechanics**: Control the ball's direction and speed with mouse input.
- **Brick Destruction**: Break bricks by bouncing the ball off them.
- **Power-ups**: Collect power-ups such as paddle size increase and additional balls.
- **Progression**: Levels with increasing difficulty. Complete a level by destroying all bricks.
- **UI**: Win and Game Over panels to display results.
- **Physics**: Use Unity's physics engine to handle ball collisions and movement.

## Scripts Overview

### `BallManager.cs`

- **Purpose**: Controls the overall game logic related to the ball and brick interactions.
- **Key Functions**:
  - `BrickCounter()`: Decreases brick count and checks for win condition.
  - `Nextbutton()`: Loads the next level.
  - `RetryBtn()`: Placeholder for retry functionality.
  - `HomeBtn()`: Returns to the home screen.
  - `Update()`: Handles mouse input to control ball launch direction and speed.

### `Brick.cs`

- **Purpose**: Manages the brick behavior when it is hit by the ball.
- **Key Functions**:
  - `BrickDestroyManagement()`: Decreases brick health and destroys it when health reaches 0.
  - `PowerDropper()`: Drops a power-up when the brick is destroyed.

### `PaddleManager.cs`

- **Purpose**: Controls the paddle movement and interactions with the ball.
- **Key Functions**:
  - `Update()`: Handles paddle movement based on mouse input.
  - `OnCollisionEnter2D()`: Interactions with power-ups and additional ball spawning.
  - `IEnumerator PaddleSizeIncrease()`: Temporarily increases paddle size when collecting a power-up.

### `Walls.cs`

- **Purpose**: Sets up the boundaries of the game world (walls).
- **Key Functions**:
  - `WallsSetup()`: Configures the positions and colliders for the game walls.

### `Ball.cs`

- **Purpose**: Handles the ball's physics interactions and behavior upon collision with walls and the paddle.
- **Key Functions**:
  - `OnCollisionEnter2D()`: Reflects ball movement based on collision with walls, paddle, or other objects.

## Installation

1. **Clone this repository**:
    ```bash
    git clone https://github.com/gaurav01112/ball-breaker.git
    ```

2. **Open the project in Unity**:
   - Open Unity Hub and click on "Open Project".
   - Navigate to the project folder and open it.

3. **Set up Unity**:
   - Make sure Unity is set up with the correct version (the project was built using Unity 2022.3.5f1).
   - Ensure any dependencies like TextMeshPro are installed via the Unity Package Manager.

## Game Controls

- **Mouse**: Click and drag to launch the ball.
- **Paddle**: Move the paddle left or right by dragging the mouse.
- **Power-ups**: Collect power-ups dropped by destroyed bricks.

## Development

- The game uses Unity's built-in physics system for handling collisions and movement.
- The game objects interact with each other through colliders and Rigidbody2D components.
- The script logic is structured to manage ball movement, power-ups, and the game's progression.

### Code Structure

- `BallManager.cs`: Main game logic for ball and brick interactions.
- `Brick.cs`: Handles individual brick behavior and destruction.
- `PaddleManager.cs`: Manages paddle movement and power-up collection.
- `Walls.cs`: Configures the game world boundaries.
- `Ball.cs`: Manages ball collision and movement logic.
