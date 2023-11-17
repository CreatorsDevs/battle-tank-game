# Battle Tank Game

## Overview

The Battle Tank game is a unique adaptation built on Unity's official learning assets. While the foundation is based on Unity's resources, the game has been enhanced and reimagined through the implementation of several design patterns to ensure an efficient, modular, and engaging gameplay experience.

## Core Features

- **MVC Architecture**: Ensures a clean separation between game logic, user interface, and data. Provides a more structured and maintainable codebase.
  
- **Singleton Pattern**: Used for consistent game elements, ensuring that only single instances of particular objects exist, offering a global point of access.

- **State Machine**: Effectively handles various game states, allowing for smoother transitions and gameplay dynamics.

- **Observer Pattern**: Facilitates dynamic game events. With this pattern, different parts of the game can 'listen' and 'react' to specific events, ensuring modularity.

- **Object Pooling**: Optimizes performance by reusing objects that are expensive to instantiate. Especially beneficial for elements frequently created and destroyed, such as bullets or enemies.

## About

This project is an exploration of enhancing existing game assets with advanced design patterns. It serves as a testament to the potential of integrating traditional software design principles into game development to achieve better results.

## Credits

- Base game assets and tutorials: [Unity's official learning resources](https://learn.unity.com/)
