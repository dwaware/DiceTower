# DiceTower

A physics-based dice tower.  Created the tower and a die with pips. Next step is a UI panel to select how many dice to drop.  A dice total will be included as well.  Then metallic shaders for the dice?
 
![dice_tower](https://user-images.githubusercontent.com/74695555/180630549-90d4a66f-fa14-4cdc-b2e5-21a0e9866a3b.png)

The dice aren't displaying a total yet, but below you can see that each die is aware of it's "rolled" value.  This is accomplished by comparing the rolled die's Euler angles against an unrotated reference die.

![dice_tower1](https://user-images.githubusercontent.com/74695555/180630551-019753c5-7633-4b71-b958-4f7331534442.png)

![ref_die](https://user-images.githubusercontent.com/74695555/180630689-5bf73ea2-8be8-467d-9ae0-26e7300bec7c.png)

Western dice all have the same face arrangement as this reference die. They are right-handed, so If the 1-spot is face up and the 2-spot is turned to face the left then the 3-spot is to the right of it. Chinese dice will have the faces the opposite way round. Japanese dice are arranged like Western dice but like other Asian dice they will have a very large and deep 1-spot painted red. Chinese and Korean dice will have a red 4-spot as well as the 1.
