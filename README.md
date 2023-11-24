# Battle Tank Game

## Overview

The Battle Tank game is a unique adaptation built on Unity's official learning assets. While the foundation is based on Unity's resources, the game has been enhanced and reimagined through the implementation of several design patterns to ensure an efficient, modular, and engaging gameplay experience.

## Gameplay

<p align="center">
<a href="https://youtu.be/8Zoh1zyAK7U">
  <img src="https://github.com/CreatorsDevs/battle-tank-game/blob/master/Images/Battle_Tank_Game.png" alt="Battle Tank Gameplay" width="800">
</a>
</p>

## Core Features

- **MVC Architecture**: Ensures a clean separation between game logic, user interface, and data. Provides a more structured and maintainable codebase.
  
- **Singleton Pattern**: Used for consistent game elements, ensuring that only single instances of particular objects exist, offering a global point of access.

- **State Machine**: Effectively handles various game states, allowing for smoother transitions and gameplay dynamics.

- **Observer Pattern**: Facilitates dynamic game events. With this pattern, different parts of the game can 'listen' and 'react' to specific events, ensuring modularity.

- **Object Pooling**: Optimizes performance by reusing objects that are expensive to instantiate. Especially beneficial for elements frequently created and destroyed, such as bullets or enemies.

## Credits

- Base game assets and tutorials: [Unity's official learning resources](https://learn.unity.com/)
- Created in collaboration with the [Outscal](https://outscal.com/) Team.
