# Unity-Football-Freekick-Game
 
This project is the creation of a "football freekick mechanism" similar to the "FIFA 23" video game's freekick mechanism, in Unity 3D game engine by a software developer named Mert Usta.

## What is freekick ?

- Football "Freekick" is kicking action to ball in the field of play. Players could "shoot" or "pass" the ball to the target for taking an advantage.

## How to play?
 
- In this game project; there are states of freekick mechanism : "freekick position selection", "shoot" and "new freekick". When shooting completed, player could take new freekick again.

### "Freekick Position Selection"

- Player could change "ball's position" with using "W","A","S","D" keys and moves the ball position.

- Player could set the finalized "ball's position" with pressing "Enter" key.

### "Shoot"

- Player could set "ball hit point" with using "W","A","S","D" keys.

- Player could change "ball kick angle" with using "Right Arrow" and "Left Arrow" keys.

- Player could shoot with holding "Space" key. For adding more power to ball, holding "Space" button more longer. (Power bar is in Bottom-Right corner of canvas.)

### "New Freekick"

- When shooting completed, player could take a new freekick with pressing "Enter" key.

### Additional Settings

- Player could open/close the visibility of "Football Stadium" with pressing "F" key.
- Player could change the height of freekick camera with using "Mouse Scroll" input.

## What were the subjects focused on?

- Creating a game mechanism clearly playable. (In my opinion, "FIFA 23" has wonderful "freekick mechanism" and I played so much time in this, I wanted design and code a game module like this.)
- Goal's "Net" is an important part of a football game. I used Unity's "Cloth" feature for it.
- Easy implementation of UI and making canvas simple.
- Adding sounds and handling the sound's "pitch" value with ball's "power" variable and "distance with camera". (For calculating and generating sounds everytime and using sounds more realistic)
- Creating a trajectory line renderer for bezier lines.
- Designed a curve movement of gameObject (for the ball's movement), with not a complicated programming solution.
- Finding and using free 3D models, free textures, free sound effects for any usage. (Sources : sketchfab.com, textures.com, creazilla.com, pixabay.com, flaticon.com)
- Thinking and understanding how a game module could work, then I designed and coded this game module with my own ways.

## Author

- Mert Usta
