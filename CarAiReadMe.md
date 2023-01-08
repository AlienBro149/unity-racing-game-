# MarsWin - CarAI
## Project Description:

This AI agent was built using our unity game as environment. The training was achieved using unity's ml agents package and used a combination of imitation learning and reinforcement learning.

## Project requirements and dependencies:

Requirements:
- Unity: version 2021.3.11f1 <a href="https://unity.com/releases/editor/whats-new/2021.3.11">Can be found here!</a>
- Required packages are supplied with the project

## How to run the AI:

- Download or pull the CarAi branch in the Unity Racing Game repository.
- Open Unity Hub and open the project using the directory where you have saved the project and select the project.
- Then when you open it, it will start to import and build the project. This will take quite some time, upwards of 15 minutes.
- When opening the project for the first time navigate to Assets>CarDriver
- If your pc can handle it you can select the `TrainingScene`, otherwise I suggest to use the `TrainingSceneSingleCar`. 
- Then it should be ready and press play! Using the game overview tab you can follow the first car or if you go to the scene tab you can watch from any position.

## Project structure

The files for the AI are as following:

- The trained brains can be found in Assets>Brains
- The checkpoint system for the AI is in Assets>CheckpointSystem
- All files from AI training can be found in results

## AI build in detections used for training:

- If the AI agent applied to car goes through correct or wrong checkpoint.
- If the AI agent had enough speed or not.
- If the AI agent hit an obstacle like a wall.
- If the AI agent stayed on the wall for longer then a supplied amount of time.
- If the AI agent was facing away from the next checkpoint.
- If the AI agent was standing completely still.

All these paramaters were used to adjust the overall reward of the agent. Like hitting a wall would give it a negative reward, if it would go through the correct checkpoint it would get a positive reward. 



