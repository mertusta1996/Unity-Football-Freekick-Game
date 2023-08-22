# Unity-Football-Freekick-Game
 
This project is the creation of a "football freekick mechanism" similar to the "FIFA 23" video game's freekick mechanism, in Unity 3D game engine by a software developer named Mert Usta.

There are some demo gifs for my project : 

- Freekick Demo :
  
![freekick demo](https://github.com/mertusta1996/Unity-Football-Freekick-Game/assets/70747383/2b4be1d3-9170-4b9a-a122-8d88d9603ff0)

- Penalty Demo :
  
![penalty demo](https://github.com/mertusta1996/Unity-Football-Freekick-Game/assets/70747383/02178177-4883-4d7b-b61b-f90dafb634df)

- Angled Freekick Demo :
  
![angled freekick demo](https://github.com/mertusta1996/Unity-Football-Freekick-Game/assets/70747383/df54082a-bcd0-43ee-a602-2d19bd71911f)

- Long Distance Freekick Demo :
  
![long distance freekick demo](https://github.com/mertusta1996/Unity-Football-Freekick-Game/assets/70747383/4aaa25d2-9934-4e99-ab07-de16e7bfd8b4)

- Project's Sounds Demo :



https://github.com/mertusta1996/Unity-Football-Freekick-Game/assets/70747383/b0368640-137f-4c6c-9275-b17f25fd8c2d



## What is freekick ?

- Football "Freekick" is kicking action to ball in the field of play. Players could "shoot" or "pass" the ball to the target for taking an advantage.

## How to play?
 
- In this game project; there are states of freekick mechanism : "freekick position selection", "shoot" and "new freekick". When shooting completed, player could take new freekick again.

### "Freekick Position Selection"
![freekick position selection](https://github.com/mertusta1996/Unity-Football-Freekick-Game/assets/70747383/e6f6decf-20f9-462a-94ba-d892b07098c5)

- Player could change "ball's position" with using "W","A","S","D" keys and moves the ball position.

- Player could set the finalized "ball's position" with pressing "Enter" key.

### "Shoot"
![shoot](https://github.com/mertusta1996/Unity-Football-Freekick-Game/assets/70747383/02102295-5ab4-4d03-ae4f-b5d529aa9356)

- Player could set "ball hit point" with using "W","A","S","D" keys.

- Player could change "ball kick angle" with using "Right Arrow" and "Left Arrow" keys.

- Player could shoot with holding "Space" key. For adding more power to ball, holding "Space" button more longer. (Power bar is in Bottom-Right corner of canvas.)

### "New Freekick"

- When shooting completed, player could take a new freekick with pressing "Enter" key.

### Additional Settings
- Player could open/close the visibility of "Football Stadium" with pressing "F" key.

![open or close the visibility Stadium](https://github.com/mertusta1996/Unity-Football-Freekick-Game/assets/70747383/1810bced-ac81-4c66-bf2a-d1721ae216a8)

- Player could change the height of freekick camera with using "Mouse Scroll" input.

![height of freekick camera](https://github.com/mertusta1996/Unity-Football-Freekick-Game/assets/70747383/59a81f7c-49ea-4ec0-b198-84e24c64249f)

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
