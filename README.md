# Unity VR Game – Zombie Collision System

This repository contains a C# script from a Unity-based VR game developed as part of an academic course. The game was designed for the Meta Quest headset and involved real-time player interactions, health tracking, and enemy management.

## ZombieCollision.cs

The `ZombieCollision` script demonstrates object-oriented programming concepts within Unity's component-based architecture. This script is attached to enemy game objects and manages several gameplay mechanics, including:

- **Player collision detection**
- **Health bar management and UI updates**
- **Dynamic color changes based on health percentage**
- **Death state handling**, including stopping enemy and health kit spawns
- **Interacting with other game systems**, such as score tracking and death screen display

## Key OOP Concepts

- **Encapsulation**: Health and UI logic are neatly contained within the class.
- **Interaction Between Objects**: The script interacts with other managers (`ScoreManager`, `DeathScreenManager`) and dynamically accesses spawner scripts and tagged objects in the scene.
- **Event-Driven Behavior**: The `OnTriggerEnter()` method handles real-time player interactions, altering game state based on player health.

## Context

This script is one component of a larger Unity VR game project. Additional scripts handled wave spawning, health kit mechanics, and player movement. While this example doesn't show inheritance hierarchies, it provides insight into how I structured real-time, object-interacting systems using Unity and C#.

