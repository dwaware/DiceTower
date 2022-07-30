# DiceTower

A fun weekend project--a physics-based dice tower.  The goal is to create everything from scratch:  all the assets (die textures, etc.) and models (the tower) as well as the game state logic and game "loop" that the player will experience.

PHASE I:

I created the tower and a die with pips. Next step will be a UI panel to select how many dice to drop.  A dice total will be included as well.  Then metallic shaders for the dice?
 
![dice_tower](https://user-images.githubusercontent.com/74695555/180630549-90d4a66f-fa14-4cdc-b2e5-21a0e9866a3b.png)

The dice aren't displaying a total yet, but below you can see that each die is aware of its "rolled" value.  This is accomplished by comparing the rolled die's Euler angles against an unrotated reference die.

![dice_tower1](https://user-images.githubusercontent.com/74695555/180630551-019753c5-7633-4b71-b958-4f7331534442.png)

In the image above, right below the UpperSideValue is a Vector3 that I refer to as ReferencePips.  This records what pip value equates to a positive x, y and z axis.  You can use the script with whatever die pattern you want, you just have to make sure to set the pip values accordingly.  I chose to use a standard "Western" aka "Right Handed" die.  The other assumption here is that opposing die faces add up to seven.

![ref_die](https://user-images.githubusercontent.com/74695555/180630689-5bf73ea2-8be8-467d-9ae0-26e7300bec7c.png)

Western dice all have the same face arrangement as this reference die. They are right-handed, so If the 1-spot is face up and the 2-spot is turned to face the left then the 3-spot is to the right of it.

![western_die](https://user-images.githubusercontent.com/74695555/180631288-574a834e-28bd-4628-a7d6-72c40291b009.jpg)

Chinese dice will have the faces the opposite way round. Japanese dice are arranged like Western dice but like other Asian dice they will have a very large and deep 1-spot painted red. Chinese and Korean dice will have a red 4-spot as well as the 1.

PHASE II:

Added states (IDLE, SELECT, ROLL) and events.  Added some title text that fades after a short IDLE period.  Likewise, the dice have frozen rigidbodies that are  allowed to move as the title text completes its fade.  The SELECT state doesn't do anything as of yet, but eventually you'll be picking your dice before initiating a ROLL.  Some images from phase II:

![dice_tower_01](https://user-images.githubusercontent.com/74695555/180694198-5c912eb1-88d6-4dd0-ad67-e08a10abc004.png)
![dice_tower_02](https://user-images.githubusercontent.com/74695555/180694201-5a4ac7ad-8c2d-4ad4-baa1-a4693140f280.png)
![dice_tower_03](https://user-images.githubusercontent.com/74695555/180694203-18ec0d89-7eb4-435f-835e-4ed1b371c374.png)
![dice_tower_04](https://user-images.githubusercontent.com/74695555/180694206-f9597a22-4d35-4bce-81ca-9ff5a9a8292c.png)
![dice_tower_05](https://user-images.githubusercontent.com/74695555/180694207-e3e273d8-c7b1-4b14-8d8f-73efd3ea74db.png)
![dice_tower_06](https://user-images.githubusercontent.com/74695555/180694208-ec69df2a-bc27-4d3d-bc68-b92751853ae9.png)

continued...

Added a roll button--and will allow for rerolling after I add a "die selection" mechanism.

![dice_tower_roll](https://user-images.githubusercontent.com/74695555/181156395-2d51e1ca-1e23-428f-8f16-eb5b7ebaee59.png)

and ...

added dice increment/deincrement buttons.  Currently allowing up to 4 dice to be rolled.
