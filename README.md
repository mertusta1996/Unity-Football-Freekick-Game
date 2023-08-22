# Unity-Football-Freekick-Game
 
This project is the creation of a "football freekick mechanism" similar to the "FIFA 23" video game's freekick mechanism, in Unity 3D game engine by a software developer named Mert Usta.

There are some demo gifs for my project : 

- Freekick Demo :
  
![freekick demo](https://github.com/mertusta1996/Unity-Football-Freekick-Game/assets/70747383/71546018-f8dc-4717-907a-c8c8a2d4a06f)


- Penalty Demo :
  
![penalty demo](https://github.com/mertusta1996/Unity-Football-Freekick-Game/assets/70747383/d49485f3-e008-464a-8672-0c0b062d23ac)


- Angled Freekick Demo :
  
![angled freekick demo](https://github.com/mertusta1996/Unity-Football-Freekick-Game/assets/70747383/cb51cdc2-8952-4522-ae8f-bc8522175e46)


- Long Distance Freekick Demo :
  
![long distance freekick demo](https://github.com/mertusta1996/Unity-Football-Freekick-Game/assets/70747383/bf1e172c-a8a2-406c-b1a2-06e6c240df4c)


- Project's Sounds Demo :



https://github.com/mertusta1996/Unity-Football-Freekick-Game/assets/70747383/e35e2472-fb2b-474d-b7bd-8d9b7b3e1128




## What is freekick ?

- Football "Freekick" is kicking action to ball in the field of play. Players could "shoot" or "pass" the ball to the target for taking an advantage.

## How to play?
 
- In this game project; there are states of freekick mechanism : "freekick position selection", "shoot" and "new freekick". When shooting completed, player could take new freekick again.

### "Freekick Position Selection"
![freekick position selection](https://github.com/mertusta1996/Unity-Football-Freekick-Game/assets/70747383/2e99e1d2-d1f7-41db-8914-5c88884fe769)


- Player could change "ball's position" with using "W","A","S","D" keys and moves the ball position.

- Player could set the finalized "ball's position" with pressing "Enter" key.

### "Shoot"
![shoot](https://github.com/mertusta1996/Unity-Football-Freekick-Game/assets/70747383/46ae7828-1a83-4fb3-b23d-ed6148b2907e)


- Player could set "ball hit point" with using "W","A","S","D" keys.

- Player could change "ball kick angle" with using "Right Arrow" and "Left Arrow" keys.

- Player could shoot with holding "Space" key. For adding more power to ball, holding "Space" button more longer. (Power bar is in Bottom-Right corner of canvas.)

### "New Freekick"

- When shooting completed, player could take a new freekick with pressing "Enter" key.

### Additional Settings
- Player could open/close the visibility of "Football Stadium" with pressing "F" key.

![open or close the visibility Stadium](https://github.com/mertusta1996/Unity-Football-Freekick-Game/assets/70747383/a8937ca5-ed33-4444-bb51-442e4ff79486)


- Player could change the height of freekick camera with using "Mouse Scroll" input.

![height of freekick camera](https://github.com/mertusta1996/Unity-Football-Freekick-Game/assets/70747383/5ceb467c-7026-45ae-84cd-806d36ae415f)


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
