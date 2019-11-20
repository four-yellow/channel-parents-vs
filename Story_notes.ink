VAR independence_meter = 0.1
VAR kid_user = "confused_rogue_6"
VAR friend_user = "whatevr"
VAR friend_name = "whattowrite"
VAR raphael = false
VAR computer_trial = false
VAR sick_lie = false
VAR played_over_time = false

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
#timeline: 360
//(Scene opens up with the father on the bench, relaxing. )

Still down, huh? Even worse than before... #speaker: parent

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
#location: dinner_one
#fade_in
#pause

//Nothing special, just the parent and the child eating. A pause before the parent speaks.
//For sounds, some light eating sounds I suppose. Tap dripping like Jared suggested.
How was school today? #speaker: parent 
Same. #speaker: child
Hey, you don't have to be short... #speaker: parent
... same as always. #speaker: child
Sigh... alright. Well, how are your friends? #speaker: parent 

* [Good.] #speaker: child
    What did I just say about being short? #speaker: parent 
    ... good as always. #speaker: child 
   Sigh... #speaker: parent
* [Same.] #speaker: child
    I get it, I'll stop...
* [We're meeting online today. ] #speaker: child
    Oh, uh, I meant your school friends. #speaker: parent
    (...) #speaker: child 
    ... never mind. #speaker: parent
    
//Parent stands up. Eating sounds stop
- Just do the dishes before you go upstairs, okay? I have a head-ache. #speaker: parent 
Alright. #speaker: child 
And I hate that I keep saying this, but stop wasting so much time playing your games. #speaker: parent 
... alright. #speaker: child 
And keep the volume down. #speaker: parent 
(...) #speaker: child 
//Child should start walking away at this point
And stop talking to those weirdos online. #speaker: parent 
//Child is out of the room 
And... talk to me, will you? #speaker: parent #fade_out //This line needs to change

* [Virtual world two notes.]
-> virtual_two_notes


== virtual_two_notes ==

(Scene should be mostly the same, just slightly differnt to show the passing of time (updates to the game). Player avatars should also be different - they now have higher tier loot. )

* [To the game world.]
-> virtual_two


== virtual_two == 

#location: virtual_two
//Kid blips into existence. Short pause, then friend blinks in.

{kid_user}: yo #speaker: child_chat 
{friend_user}: oh hey! how long have you been online? #speaker: friend_chat
//They sit on the bench
{kid_user}: i just logged in actually #speaker: child_chat 
{friend_user}: wow, again? funny how this keeps happening, hahaha  #speaker: friend_chat
{kid_user}: yeah, lol  #speaker: child_chat 
{friend_user}: anyways, you up for a raid? there's one happening in half an hour #speaker: friend_chat
{kid_user}: nah, don't feel like playing today #speaker: child_chat 
{friend_user}: trash day, huh? #speaker: friend_chat
{kid_user}: very trash. unusually trash, lol #speaker: child_chat 
{kid_user}: id rather just chill and talk tbh #speaker: child_chat 
{kid_user}: dont really wanna think too much  #speaker: child_chat 
{friend_user}: of course. #speaker: friend_chat
{kid_user}: how about you? how was your day? #speaker: child_chat 
{friend_user}: nothing special #speaker: friend_chat
{friend_user}: oh, actually, something hilarious happened the other day #speaker: friend_chat
{friend_user}: wanna hear about it? #speaker: friend_chat
{kid_user}: sure, tell me everything #speaker: child_chat 
{friend_user}: yes! #speaker: friend_chat
{friend_user}: so i went to the con i told you about earlier... #speaker: friend_chat #fade_out
... #fade_in
{friend_user}: ... and then i went home. #speaker: friend_chat
{kid_user}: ... #speaker: child_chat
{kid_user}: that uh, wasnt really funny #speaker: child_chat
{friend_user}: thats cause your laaaaaaaaaaame #speaker: friend_chat
{friend_user}: you're*, shut up #speaker: friend_chat
{kid_user}: you're #speaker: friend_chat
{kid_user}: shit, you got me, lol #speaker: child_chat
{friend_user}: still think you should type properly if your gonna shit on my grammar #speaker: friend_chat
{kid_user}: you're, and it's just a meme, i don't really care #speaker: child_chat
{friend_user}: even as a meme, hahahah #speaker: friend_chat
{friend_user}: hey, so how about we go raiding tomorrow #speaker: friend_chat
{kid_user}: what time? #speaker: child_chat
{friend_user}: afternoon-ish? somethings happening between 1-2 #speaker: friend_chat
{kid_user}: during school hours huh? #speaker: child_chat
{friend_user}: yeah. if you cant make it, thats ok.  #speaker: friend_chat
{kid_user}: how come youre not going #speaker: child_chat
{kid_user}: to school i mean #speaker: child_chat
{friend_user}: you got me, hahaha  #speaker: friend_chat
{friend_user}: parents are out of town, so im getting some much needed rest  #speaker: friend_chat
{friend_user}: just pretend youre sick or something #speaker: friend_chat
{kid_user}: ill think about it #speaker: child_chat
{friend_user}: guess ill know if you log in  #speaker: friend_chat
{friend_user}: anyways i gotta go  #speaker: friend_chat
{friend_user}: see ya  #speaker: friend_chat
{kid_user}: take care #speaker: child_chat
//Friend blips out here. Kid stands up

(... what do I do? ) #speaker: child

 * [<i> Try skipping school. </i>] #door #position: (x, y) 
    (Worth a shot. I don't wanna go to school anyways.) #speaker: child
    -> sick_day_notes
 * [<i> Go to school tomorrow. </i>] #door #position: (x, y) 
    (No, I better not. Dad would be mad. ) #speaker: child
    -> dinner_two_notes


== sick_day_notes == 

(As far as setting goes, it should be the kid's room, but in the morning. Kid should be in bed. Besides that, not much else).

* [To the scene.]
-> sick_day

== sick_day == 
#location: bedroom
//Kid is in bed, waiting for their father to come in 
(Okay, knock in 3, 2, 1...) #speaker: child
//Knocking sound effect here 
Hey, are you up? I'm coming. ##speaker: parent 
//Door opens. Parent walks to bed 
Alright kid, wake up. Time to go. #speaker: parent 
(...) #speaker: child 
Come on, get up, or we'll both be late. #speaker: parent 

* I don't feel so good. #speaker: child 
    ~independence_meter += 0.1
    I don't see any blood. #speaker: parent 
    I have a fever, dad. #speaker: child 
    Let me see... hmmm, you seem okay to me. #speaker: parent 
    I'm really not... #speaker: child 
    Kid, don't lie to me. I know what you're trying to do. #speaker: parent 
    (...) #speaker: child 
    I'm really - #speaker: child
    I know you're lying. C'mon, let's go. #speaker: parent 
    (...sigh) #speaker: child. 
    
* I'm getting up. #speaker: child 

//Kid gets up, parent and child walk to the centerish of the room. 

- Alright. After you. 


 * [<i> Go back to sleep. </i>] #door #position: (x, y) 
    Nope, don't even try. Let's go. #speaker: parent 
    -> sick_day_notes
 * [<i> Go to school tomorrow. </i>] #door #position: (x, y) #fade_out 
    -> dinner_two_notes

== dinner_two_notes == 

(Again, some light aging and changes in the room.)

* [To the dinner scene. ]
->dinner_two 

== dinner_two == 

//For sounds, same as dinner_one, but quieter. 
So... how was school today? #speaker: parent 
Same. #speaker: child
Right, same... #speaker: parent
Do you wanna go to the park with me? We can bring a frisbee with us. #speaker: parent
I'm busy today. #speaker: child
Oh... with what? #speaker: parent 
Work. I guess. #speaker: child 
//Sounds stop
//Kid gets up. Starts walking out
... we haven't talked properly in a long time. #speaker: parent 
Why... what am I doing wrong... #speaker: parent 
Kid... #speaker: parent 
* [To the next scene]
-> virtual_three_notes 

== virtual_three_notes == 

(Again, light ageing. Better gear?)

* [To the next scene]
-> virtual_three 

== virtual_three == 

#location: virtual_three
//Kid blips into existence. Friend is already there. Both standing. 
{friend_user}: you took your time #speaker: friend_chat
{kid_user}: yeah sorry #speaker: child_chat 
{kid_user}: got distracted by something #speaker: child_chat 
{friend_user}: yeah no worries #speaker: friend_chat
{friend_user}: well, shall we? #speaker: friend_chat
{kid_user}: mhm, lets go #speaker: child_chat 
# fade_out
// Some time later, the two walk in the screen from the left. 
{friend_user}: nothing again #speaker: friend_chat
{friend_user}: sigh #speaker: friend_chat
{friend_user}: are we just trash? #speaker: friend_chat
{kid_user}: its just bad luck dw #speaker: child_chat 
{kid_user}: the last update fucked over the game tbh #speaker: child_chat 
{friend_user}: yeah maybe... #speaker: friend_chat
{kid_user}: lets just chill for a bit #speaker: child_chat 
{kid_user}: we can try again tomorrow or something #speaker: child_chat
{friend_user}: but I wanna try noooooooooow #speaker: friend_chat
{friend_user}: we know what to do now #speaker: friend_chat
{kid_user}: cmon dude #speaker: child_chat
{kid_user}: later... #speaker: child_chat
{friend_user}: you got anything to do? #speaker: friend_chat
{kid_user}: dad gets bitchy when i play too much #speaker: child_chat
{kid_user}: pushing my luck here #speaker: child_chat
{friend_user}: one more try #speaker: friend_chat
{friend_user}: pleeeease #speaker: friend_chat
(... should I?) #speaker: child
 * [<i> Continue playing. </i>] #door #position: (x, y) 
    -> continue_playing
 * [<i> Head back to work. </i>] #door #position: (x, y) 
    -> quit_for_now

= continue_playing 

{kid_user}: sigh #speaker: child_chat
{kid_user}: alright #speaker: child_chat
{kid_user}: one more game #speaker: child_chat
#fade_out 
//Five games later
{friend_user}: okay this really is the last one  #speaker: friend_chat
{kid_user}: heard that one before  #speaker: child_chat
{friend_user}: i think ive figure out how to beat the boss, for real this time  #speaker: friend_chat #sudden_out
//While the above sentence is typing, the screen should cut off suddenly
->too_much_game_notes

= quit_for_now

{kid_user}: no, i really should be going #speaker: child_chat
{kid_user}: sorry #speaker: child_chat
{friend_user}: eh  #speaker: friend_chat
{friend_user}: whatever  #speaker: friend_chat
{friend_user}: see ya  #speaker: friend_chat
#fade_out

* [Next scene.]
-> dinner_three_notes

== too_much_game_notes == 

(Should be dark outside. We need the unplugged background for this one)

* [To the scene.]
-> too_much_game

== too_much_game == 
#location: bedroom_unplugged
~played_over_time = true
So this is what you're busy with? #speaker: parent 
(...) #speaker: child 
You'd rather play your game than spend some time with me? #speaker: parent 
Ever since I got you that thing, we've just been... far apart. And you've always been quiet, but now you barely even look at me. #speaker: parent 
Every day, the same routine. I wish you'd stop playing your games. Or just play less, for fuck's sake. Do you know what time it is? #speaker: parent 
(... shit.) #speaker: child 
Get up. You're coming downstairs and we're gonna sit together. I don't care if we talk or not. And this is gonna be a daily thing. Besides dinner. #speaker: parent 
Come on. After you. #speaker: parent 
(...) #speaker: child 
//gets up 
 * [<i> Continue playing. </i>] #door #position: (x, y) 
    Don't even think about it. #speaker: parent
 * [<i> Head back to work. </i>] #door #position: (x, y) 
    
    
- -> dinner_three_notes

== dinner_three_notes == 

(Since only a week has passed, no significant aging to show)

* [To the scene.]
-> dinner_three


== dinner_three == 
#location: dinner_three

~ temp name_given = ""

//Both are sitting at the table, quietly eating. 
... #speaker: parent 
(...) #speaker: child 
(Today's the day. ) #speaker: child 
({friend_name} and I are meeeting today. ) #speaker: child
(Park at night. Weird time, but not a big deal. ) #speaker: child
(...) #speaker: child
(Should I tell dad?) #speaker: child 
{played_over_time: I think he's still mad. | I don't think he'll take it well. }
(What do I do?) #speaker: child 
Something on your mind? #speaker: parent 
Hm? #speaker: child 
You look pretty serious. What's on your mind? #speaker: parent 
... I want to go out today. #speaker: child 
Bit late, don't you think? #speaker: parent 
Why this all of a sudden? #speaker: parent 

* [I'm going to meet someone at the park. ] #speaker: child
    Who? #speaker: parent 
    A friend. #speaker: child 
    Who? #speaker: parent 
    
    ** [Joe. ]#speaker: child
        ~name_given = "Joe"
        Who's Joe? #speaker: parent 
        (... you're better than this. Don't say it, don't say it, don't say it...) #speaker: child 
        Well? #speaker: parent 

    ** [{friend_name}] #speaker: child
        ~name_given = friend_name
        Who's that? #speaker: parent 
        
    ** [Sam.] #speaker: child 
        ~name_given = "Sam"
        Who's that? #speaker: parent 
        
    -- Just, a friend. You don't know them. #speaker: child 
    

* [I just wanna walk. ] #speaker: child
    Since when? Normally you'd just go up to your room. #speaker: parent 
    
* [<i> Say nothing </i> ]
    Don't wanna say, huh? #speaker: parent 
    
- Well, forget it. It's way too late for you to be walking around right now. #speaker: parent 
(... figures. ) #speaker: child 
{ name_given == "":
    ... you're going to meet your online friend, aren't you? #speaker: parent 
    (!) #speaker: child 
    I heard you sleep talking yesterday. Seemed like you were excited. #speaker: parent 
- else:
    ...say, is this {name_given} your online friend? #speaker: parent 
}

(I guess he knows... no point in hiding it now.) #speaker: child 
{ name_given == "":
    Why didn't you just tell me? #speaker: parent 
    ... I don't know. #speaker: child 
    You know I can't let you go. #speaker: parent 
- else:
    I'm glad you were honest with me, but I can't let you go. #speaker: parent 
}
I didn't think you would. #speaker: child
You don't know anything about them. You don't know who they are. #speaker: parent 
I do. We've been friends for years now. #speaker: child 
You're not friends. You play the same game. #speaker: parent 
We are friends. #speaker: child 
... they're my only friend. #speaker: child 
//Kid stands up here 
I'm telling you not to go. #speaker: parent 
... #speaker: child 
You never listen to me. I'm telling you not to go. This is a bad idea. #speaker: parent 

//Lines to add as the player moves 
//Don't you step outside the house, kid. 
//Don't take another step. 
//Blah blah blah 

->END
























