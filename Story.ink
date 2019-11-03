VAR independence_meter = 0.1
VAR kid_user = "confused_rogue_6"
VAR friend_user = "whatevr"
VAR friend_name = "whattowrite"
VAR raphael = false
VAR computer_trial = false


->notes

== notes == 
Ink is fucking amazing. 

Text written in (parenthesis) will describe the scene, background, appearance, etc. This is unfortunate for my normally parenthetical writing, but the sacrifice is mine to make. Please let me know if more detail is needed. By the way, I don't know if this is obvious, but I don't think you should draw the doors as part of the background. 

Stuff in ((double parenthesis)) are my own personal thoughts, notes, and suggestions. 

Stuff following a pound sign are tags. Jared, these will be important when we're programming; keep an eye on them. Check the ink documentation to see what they do and how we can refer to them. 

I'm currently thinking of a more appropriate start to the game than the ice-cream scene; it's just...not a good opener, you know?

I have the game's structure/flowchart written out. That is, I've already decided the order of the scenes.

*	[To the ice-cream scene!]
    ->icecream_notes
 
== icecream_notes ==

(A park where the father and child often relax together. There's a bench near the center of the scene, where the father is currently sitting; a tree offers some shade next to the bench. No need to draw an ice-cream truck, keeping it off screen is fine. In the background, perhaps a street? I'll leave the rest to your imagination, Grace).

((I know I said to not worry about the "dark" ending till the very end, but I can't help but change the story/visuals ever so slightly to accommodate it. I think the park will be the last scene of the game; you meet your online friend here (night version as well?). Perhaps create an identical version of the park, but with a van in the distant background? Or a man standing in the background?))

* [To the real ice-cream scene...]
    ->icecream_scene

== icecream_scene == 
#location: park_day
//(Scene opens up with the father on the bench, relaxing. )

Still down, huh? Even worse than before... #speaker: parent #animation: child_walking

//(The child walks into view, head held low. Stops near the parent. )

What's the matter, kid? Weren't you having fun? #speaker: parent
No. #speaker: child
Well, why not? #speaker: parent 
 * [Talk about losing your kite.]
        I lost my kite. #speaker: child
 Oh, no... where'd you lose it? #speaker: parent
 Lightning hit it. It burned up. #speaker: child
 (...probably just lost it. Right? Regardless...) #speaker: parent_whisper
 ->no_piss_in_pants
 * [Talk about the tree.]
        They threw me up a tree. #speaker: child
 What? Who did? #speaker: parent
 Bullies in my class. It took me an hour to get down. #speaker: child
 (An hour?!) #speaker: parent_whisper
 ->no_piss_in_pants
 * [Talk about the bathrooms.]
        I needed to use the bathroom. #speaker: child
 And? It's right there. #speaker: parent
 I couldn't find it. #speaker: child
 (...Shit. ) #speaker: parent_whisper
 ->piss_in_pants

= no_piss_in_pants
I'm sorry, kid. Maybe we should have stayed at home... #speaker: parent 
Can I get some ice-cream? There's a stand over there. #speaker: child
Sure, why not. Let me...oh. I don't have cash on me. #speaker: parent #animation: parent_standing
->no_icecream_for_you

= piss_in_pants
I'm sorry, kid. Maybe we should have stayed at home... #speaker: parent 
Can I get some ice-cream? There's a stand over there. #speaker: child
No...not with those pants on, you're not. #speaker: parent 
Can't you get some for me? #speaker: child
I want to, but I don't have cash on me. #speaker: parent #animation: parent_standing
->no_icecream_for_you

= no_icecream_for_you
Oh. #speaker: child
I'll get you some tonight, don't worry. #speaker: parent
I want it now... #speaker: child
Do you wanna rob the stand? #speaker: parent
Huh? #speaker: child
Because there's nothing else we can do about it. Come on, we're heading back. #speaker: parent
(Should I?) #speaker: child_thoughts

 * Rob the stand. #door #position: (x, y) #reactive
 What are you doing? Get over here. #speaker: parent
 * Head to the car. #door #position: (x, y) 

- ->new_computer_notes 

== new_computer_notes == 

(I was initially thinking this scene would take place over two rooms (kids room and the computer room), but it's definitely more economical to have just one room — the kid's room. Doesn't have to be anything too fancy — desk, bed, some posters, you get the idea. One note is that there should be a power outlet near where the computer will be set up (for the unplugging scene). And, of course, there should be a version without the computer, and one with (and one with the computer unplugged.))

* [To the computer scene. ]
 -> new_computer

== new_computer == 
#location: bedroom_one_no_pc

//Kid is lying in bed, staring at the ceiling, as one does. Bedroom door is closed. 

Hey, can you come here real quick? I wanna show you something. #speaker: parent #off screen #sound: knocking
->chilling_in_bed

= intruder_alert
#fade_out #insert_parent #sound: door_opening #fade_in

...are you up? #speaker:parent 

 * Yes. #speaker: child 
 ~ independence_meter += 0.05
 Then why didn't you say so...? #speaker: parent 
 I was working. #speaker: child #pause: 3.0
 Right... well, come help me set this thing up. You know about these things more than me. #speaker: parent #off screen #sound: building #animation: child_walking_towards_door #fade_out
 * Ignore him. 
 Sigh... and I was looking forward to this. Sleep well, kid. We'll set up your computer later. #speaker: parent #animation: parent_walking_out
 I'm up. #speaker: child #animation: child_sits_up #animation: parent_stops_mid_walk #pause: 3.0
 Well... there goes the surprise. #speaker: parent #animation: parent_turns_around 
 Sorry... #speaker: child 
 It's alright. Come help me set it up, yeah? #speaker: parent #off screen #sound: building #animation: child_walking_towards_door #fade_out
 
- ->brand_new_pc

= chilling_in_bed 

 + Ignore him. 
    {Come on, I know you can hear me. ->chilling_in_bed | Hello? Are you in there? ->chilling_in_bed| C'mon, you really wanna do this? ->chilling_in_bed| I'm coming in. -> intruder_alert}#speaker: parent #off screen
 * In a minute. #speaker: child
    Your loss. It's pretty cool. #speaker: parent
    ... In a second. #speaker: child
 * Coming. #speaker: child
 
- There's a good kid. You're gonna have to help me set it up, though... #speaker: parent #off screen #sound: building_pc #animation: child_walking_towards_door #fade_out

->brand_new_pc

= brand_new_pc
#location: bedroom_one_pc #fade_in

...that was quick! You sure know your stuff! #speaker: parent 
I was saving up for one. #speaker: child 
(I know.) #speaker: parent_whisper
Well... do you like it? #speaker: parent

* [Hug him. ] Thanks, dad. #animation: hug #speaker: child 
    ...anything for you, buddy. #speaker: parent
     Now, don't let me get in the way of your fun. #speaker: parent
* Thanks, dad. #speaker: child
    Don't worry about it. Think of it as your birthday gift for the next few years. #speaker: parent
    You can have it back. #speaker: child 
    Cold! Hahaha! I'll let you start setting it up now. #speaker: parent
* I have to try it first. #speaker: child
    ~computer_trial = true
    Oh, of course. Uhm... I'll leave you to it... #speaker: parent
 
- Just, be responsible, okay? You're old enough to know better. And don't play on it for too long. Those screens can hurt your eyes. #speaker: parent #animation: exiting_room_stops_door
I'll be in my room if you need me. #speaker: parent #animation: exiting_room 
#fade_out #fade_in 

//Because the tags don't say shit, the parent now leaves the room and the child starts the computer. 
(What should I do first?) #speaker: child 
(...) #speaker: child 
(...) #speaker: child 
(...) #speaker: child 
(I guess that game everyone is playing. Let's download it...) #speaker: child #fade_out

-> virtual_one_notes

== virtual_one_notes == 

(In the interest of time, I've culled most of the interactive stuff that we planned for the virtual world; forget choosing an avatar and playing a minigame. The virtual world will be very much like the a virtual version of the park, but without the ice-cream van and with a different background, I imagine (yes, there is a bench. It's where they'll talk). More fantastical. The theme of the game, if it helps your art, Grace, is D&D. For avatars, the kid should be a human rogue and the friend should be a human wizard. )

((When the characters are typing into the chat-box, let's use a chatboxish looking font, yeah?))

((Not really fond of how I wrote this scene... it feels clunky and off, but I'm not sure how to fix it.))

* [To the virtual world!]
    ->virtual_one
    
== virtual_one ==
#location: virtual_one

//Kid-avatar should blip into existence, with a pop sound effect.

(It's quiet here. Is this the wrong game?) #speaker: child
(Should I ask...?) #speaker: child #animation: sits_on_bench #pause: 2.0
(...) #speaker: child #animation: sits_on_bench
{kid_user}: hello? #speaker: child_chat 
{kid_user}: anyone here? #speaker: child_chat 
{kid_user}: i dont know how to play #speaker: child_chat 
(...) #speaker: child
(I'll just leave...) #speaker: child

//Friend blips into existence 

{friend_user}: hellooo! #speaker: friend_chat
{friend_user}: I heard your call for help, and im here... to help! #speaker: friend_chat
{kid_user}: thanks :) #speaker: child_chat
{friend_user}: Now, where to start... #speaker: friend_chat #fade_out #animation: friend_sit
 
//Fade out, to explain the game and shit...

{friend_user}: ...and thats pretty much it! #speaker: friend_chat #fade_in
{kid_user}: I didn't really get much of that... #spaker: child_chat 
{friend_user}: don't worry, you'll pick it up when we play! #speaker: friend_chat
{kid_user}: you want to play together? #spaker: child_chat 
{friend_user}: yeah! why not? it'll be fun! #speaker: friend_chat
(...) #speaker: child_chat
{friend_user}: what's your name btw? #speaker: friend_chat

* [Raphael Ambrosius Costeau.] 
    ~ raphael = true
    {kid_user}: raphael ambrosius costeau. i think its german? #speaker: child_chat
    {friend_user}: wow, that's a really weird name #speaker: friend_chat
    {friend_user}: not in a bad way of course! #speaker: friend_chat
    {friend_user}: and you didnt have to say the whole thing, hahahah #speaker: friend_chat
* [It's... <i> Tell them your name. </i>]
    {friend_user}: nice to meetcha! #speaker: friend_chat
* [<i> Don't tell them right away. </i>]
    {friend_user}: yeah I get it, dont worry about it #speaker: friend_chat

- {friend_user}: im {friend_name}, by the way #speaker: friend_chat
{friend_user}: do you wanna go to town and stock up? #speaker: friend_chat
{kid_user}: i think my dad is calling, so not now. #speaker: child_chat
{friend_user}: that's okay. add me as a friend, we can play later ! #speaker: friend_chat
{kid_user}: mhm, alright. #speaker: child_chat
(...) #speaker: child_chat 
{kid_user}: thank you for helping me out :D #speaker: child_chat
{friend_user}: my pleasure :) #speaker: friend_chat
{friend_user}: talk to you later! #friend_chat #animation: screen_blip_out

//Screen turns off I guess.

-> talking_about_computer_notes

== talking_about_computer_notes == 

(Nothing much to say, art wise. Just the kid's bedroom again).

* [The next scene. ]
    -> talking_about_computer

== talking_about_computer == 

#location: bedroom_one_pc

Can I come in? #speaker: parent #sound: knocking
Yeah. #speaker: child 

//Parent enters the room 

{computer_trial: Well, is it any good? | Looks like you're having fun. } #speaker: parent 
Yeah, it's really cool. I downloaded a game.  #speaker: child 
Of course that's the first thing you do, hahaha! #speaker: parent 
Sorry... #speaker: child 
I'm just teasing! What else? #speaker: parent 
I met someone online. We talked. #speaker: child 
Did you really? #speaker: parent 
Yeah.  #speaker: child 
What did I say about being responsible? #speaker: parent 

* They seemed nice, though. #speaker: child 
* It's part of the game. #speaker: child 
* Nothing happened. #speaker: child 

- Doesn't matter. You don't really know who you're talking to. You have to be careful. #speaker: parent
(...) #speaker: child 
Come on, I ordered some chinese. #speaker: parent #animation: parent_walking_out #fade_out

-> dinner_one_notes 

== dinner_one_notes == 

(The first of the dinner scenes. Besides a table and two chairs (across each other), feel free to design the rest of the room as you see fit. One thng to keep into account is the time gap - this scene should happen a couple of years after the previous scene. Maybe age the parent slightly. The child should be aged significantly, naturally. )

* [To the dinner scene!]
    -> dinner_one 
    
== dinner_one == 

->END










