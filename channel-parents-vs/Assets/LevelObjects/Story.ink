VAR independence_meter = 0.1
VAR kid_user = "confused_rogue_6"
VAR friend_user = "udyrin_48"
VAR friend_name = "Sam"
VAR raphael = false
VAR computer_trial = false
VAR played_over_time = false

->icecream_scene

== icecream_scene == 
#knot: icecream_scene
#location: park_day
#timeline: 6
#setting: 1

//(Scene opens up with the father on the bench, relaxing. )

Oh, finally back... #speaker: parent 

//(The child walks into view, head held low. Stops near the parent. ) 

~temp pissed_pants = false

What's the matter, kid? Weren't you having fun? #speaker: parent
No. #speaker: child
Why not? #speaker: parent 
    * [Talk about losing your kite.]
    I lost my kite. #speaker: child
    Oh, no... where'd you lose it? #speaker: parent
    If I knew, I wouldn't have lost it. #speaker: child
    (Smartass, hahaha. ) #speaker: parent 

    * [Talk about the tree.]
    They threw me up a tree. #speaker: child
    What? Who did? #speaker: parent
    I don't know. I was stuck for an hour. #speaker: child
    (An hour?!) #speaker: parent

    * [Talk about the bathrooms.]
    ~pissed_pants = true
    I needed to use the bathroom. #speaker: child
    And? It's right there. #speaker: parent
    I couldn't find it. #speaker: child
    (...Shit. ) #speaker: parent

- I'm sorry, kid. Maybe we should've stayed at home... #speaker: parent 
Can I get some ice-cream? #speaker: child

{ pissed_pants == true:
    No... not with those pants on, you're not. #speaker: parent 
    Can't you get some for me? #speaker: child
    I want to, but I don't have any cash on me. #speaker: parent #animation: parent_stand
- else:
    Sure, why not. Let me...oh. Left the cash back home. #speaker: parent #animation: parent_stand
}

Oh. #speaker: child
I'll get you some tonight, don't worry. #speaker: parent
But I want it now... #speaker: child
Do you wanna rob the stand? #speaker: parent
Huh? #speaker: child
Because there's nothing else we can do. Come on, let's go home. #speaker: parent
(...should I?) #speaker: child #door #door1pos: (-7.48,-1.41) #door2pos: (7.29,-1.41)
-> park_doors

= park_doors 
    + [Rob the stand. ]
    What are you doing? Get over here. #speaker: parent
    -> park_doors
    * [Head to the car. ]
    ->new_computer

== new_computer == 
#location: bedroom_one_no_pc
#setting: 2
#switch: 2
//Kid is lying in bed, staring at the ceiling, as one does. Bedroom door is closed. 

Hey, can you come here real quick? I wanna show you something. #speaker: parent #off screen #sound: knocking
->chilling_in_bed

= intruder_alert
#location: bedroom_one_no_pc
#setting: 3
#timeline: 5
#fade_out #insert_parent #sound: door_opening #fade_in

...are you up? #speaker: parent 

    * [Yes.]
    ~ independence_meter += 0.05
    Then why didn't you say so...? #speaker: parent 
    I was working. #speaker: child #pause: 3.0
    Right... well, come help me set this thing up. You know about these things more than me. #speaker: parent #off screen #sound: building #animation: child_walking_towards_door #fade_out
    * [Ignore him.]
    Sigh... and I was looking forward to this. Sleep well, kid. We'll set up your computer later. #speaker: parent #animation: parent_walking_out
    I'm up. #speaker: child #animation: child_sits_up #animation: parent_stops_mid_walk #pause: 3.0
    ... #speaker: parent 
    Well... there goes the surprise. #speaker: parent #animation: parent_turns_around 
    Sorry... #speaker: child 
    It's alright. Come help me set it up, yeah? #speaker: parent #off screen #sound: building #animation: child_walking_towards_door #fade_out
 
- ->brand_new_pc

= chilling_in_bed 

    + [Ignore him. ]
      Come on, I know you can hear me.  #speaker: parent 
      ->chilling_in_bed2
    * [In a minute. ]
      Your loss. It's pretty cool. #speaker: parent
      ... In a second. #speaker: child
    * [Coming. ]
 
- There's a good kid. You're gonna have to help me set it up, though... #speaker: parent #off screen #sound: building_pc #animation: child_walking_towards_door #fade_out

->brand_new_pc

= chilling_in_bed2

    + [Ignore him. ]
      Hello? Are you in there? #speaker: parent 
      ->chilling_in_bed3
    * [In a minute. ]
      Your loss. It's pretty cool. #speaker: parent
      ... In a second. #speaker: child
    * [Coming. ]
 
- There's a good kid. You're gonna have to help me set it up, though... #speaker: parent #off screen #sound: building_pc #animation: child_walking_towards_door #fade_out

->brand_new_pc

= chilling_in_bed3

    + [Ignore him. ]
      C'mon, you really wanna do this? #speaker: parent 
      ->chilling_in_bed4
    * [In a minute. ]
      Your loss. It's pretty cool. #speaker: parent
      ... In a second. #speaker: child
    * [Coming. ]
 
- There's a good kid. You're gonna have to help me set it up, though... #speaker: parent #off screen #sound: building_pc #animation: child_walking_towards_door #fade_out

->brand_new_pc

= chilling_in_bed4

    + [Ignore him. ]
      I'm coming in. #speaker: parent 
      -> intruder_alert
    * [In a minute. ]
      Your loss. It's pretty cool. #speaker: parent
      ... In a second. #speaker: child
    * [Coming. ]
 
- There's a good kid. You're gonna have to help me set it up, though... #speaker: parent #off screen #sound: building_pc #animation: child_walking_towards_door #fade_out

->brand_new_pc

= brand_new_pc
#location: bedroom_one_pc #fade_in
#setting: 4
#timelineset: 5
...that was quick! You know your stuff! #speaker: parent 
I was saving up for one. #speaker: child 
(I know.) #speaker: parent 
Well... do you like it? #speaker: parent

    * [Thanks, dad.]
        Don't worry about it. This is your birthday gift for the next few years. #speaker: parent
        You can have it back. #speaker: child 
        Cold! Hahaha! I'll let you start setting it up now. #speaker: parent
    * [I have to try it first. ]
        ~computer_trial = true
        Oh, of course. Uhm... I'll leave you to it... #speaker: parent
 
- Just, be responsible, okay? You're old enough to know better. And don't play on it for too long. Those screens can hurt your eyes. #speaker: parent #animation: exiting_room_stops_door
I'll be in my room if you need me. #speaker: parent #animation: exiting_room #timeline: 5
#fade_out #fade_in 

//Because the tags don't say shit, the parent now leaves the room and the child starts the computer. 
(What should I do first?) #speaker: child 
(...) #speaker: child 
(...) #speaker: child 
(...) #speaker: child 
(I guess that game everyone's playing. Let's download it...) #speaker: child #fade_out

-> virtual_one

== virtual_one ==
#location: virtual_one
#switch: 7
#setting: 12
//Kid-avatar should blip into existence, with a pop sound effect.

(No one's in the lobby. Is this the wrong game?) #speaker: child
(Should I ask...?) #speaker: child #animation: sits_on_bench #pause: 2.0
(...) #speaker: child #animation: sits_on_bench
{kid_user}: hello? #speaker: child_chat 
{kid_user}: anyone here? #speaker: child_chat 
{kid_user}: i dont know how to play #speaker: child_chat 
(...) #speaker: child
(Yep, wrong game...) #speaker: child

//Friend blips into existence 

{friend_user}: hellooo! #speaker: friend_chat #fblip
{friend_user}: I heard your call for help, and im here... to help! #speaker: friend_chat
{kid_user}: thanks :) #speaker: child_chat
{friend_user}: Now, where to start... #speaker: friend_chat #fade_out #animation: friend_sit
 
#location: virtual_one
#setting: 10

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
{kid_user}: i think my dad is calling, so not rn #speaker: child_chat
{friend_user}: that's okay. add me as a friend, we can play later ! #speaker: friend_chat
{kid_user}: mhm, alright. #speaker: child_chat
(...) #speaker: child_chat 
{kid_user}: thank you for helping me out :D #speaker: child_chat
{friend_user}: my pleasure :) #speaker: friend_chat
{friend_user}: talk to you later! #friend_chat #animation: screen_blip_out

//Screen turns off I guess.

-> talking_about_computer

== talking_about_computer == 

#location: bedroom_one_pc
#setting: 5
#switch: 3

Can I come in? #speaker: parent #sound: knocking
Yeah. #speaker: child #timeline: 1 #animation: child_stand_right

{computer_trial: Well, is it any good? | Looks like you're having fun. } #speaker: parent 
Yeah, it's really cool. I downloaded a game.  #speaker: child 
Of course that's the first thing you do, hahaha! #speaker: parent 
Sorry... #speaker: child 
I'm just kidding! What else? #speaker: parent 
I met someone online. We talked. #speaker: child 
Did you really? #speaker: parent 
Yeah.  #speaker: child 
What did I say about being responsible? #speaker: parent 

* They seemed nice, though. #speaker: child 
* It was part of the game. #speaker: child 
* Nothing happened. #speaker: child 

- Doesn't matter. You don't really know who you're talking to. You gotta be careful. #speaker: parent
(...) #speaker: child 
Come on, let's head downstairs. #speaker: parent #animation: parent_walking_out #fade_out

-> dinner_one 

== dinner_one == 
#location: dinner_one
#setting: 6
#switch: 4
#fade_in
#pause

~ temp mentioned_friends = false

//Nothing special, just the parent and the child eating. A pause before the parent speaks.
//For sounds, some light eating sounds I suppose. Tap dripping like Jared suggested.
How was school today? #speaker: parent 
Same. #speaker: child
Hey, you don't have to be short... #speaker: parent
... same as always. #speaker: child
Sigh... alright. Well, how are your friends? #speaker: parent 

* [Good.]
    What did I just say about being short? #speaker: parent 
    ... good as always. #speaker: child 
   Sigh... #speaker: parent
* [Same.]
    I get it, I'll stop...
* [We're meeting online today. ]
    ~mentioned_friends = true
    Oh, uh, I meant your school friends. #speaker: parent
    (...) #speaker: child 
    ... never mind. #speaker: parent
    
//Parent stands up. Eating sounds stop
- Just take out the trash before you go upstairs, okay? I have a head-ache. #speaker: parent 
Alright. #speaker: child 
And I hate that I keep saying this, but stop wasting so much time playing your games. #speaker: parent 
... alright. #speaker: child 
And keep the volume down. #speaker: parent
(...) #speaker: child #timeline: 3
//Child should start walking away at this point
{mentioned_friends: And stop talking to those weirdos online. | ... } #speaker: parent 
//Child is out of the room 
And... talk to me, will you? #speaker: parent #fade_out

-> virtual_two

== virtual_two == 
#location: virtual_two
#switch: 8
#setting: 9
#pause 
#fblip
//Kid blips into existence. Short pause, then friend blinks in.

{kid_user}: yo #speaker: child_chat 
{friend_user}: oh hey! how long have you been online? #speaker: friend_chat
//They sit on the bench
{kid_user}: just logged in actually #speaker: child_chat 
{friend_user}: wow, again? funny how this keeps happening, hahaha  #speaker: friend_chat
{kid_user}: yeah, lol  #speaker: child_chat 
{friend_user}: anyways, you up for a raid? there's one happening in half an hour #speaker: friend_chat
{kid_user}: nah, don't feel like playing today #speaker: child_chat 
{friend_user}: trash day, huh? #speaker: friend_chat
{kid_user}: very trash. unusually trash, lol #speaker: child_chat 
{kid_user}: id rather just chill and talk tbh #speaker: child_chat 
{kid_user}: dont wanna think too much  #speaker: child_chat 
{friend_user}: of course #speaker: friend_chat
{kid_user}: how about you? how was your day? #speaker: child_chat 
{friend_user}: nothing special #speaker: friend_chat
{friend_user}: oh, actually, something hilarious happened the other day #speaker: friend_chat
{friend_user}: wanna hear about it? #speaker: friend_chat
{kid_user}: sure, tell me everything #speaker: child_chat 
{friend_user}: yes! #speaker: friend_chat
{friend_user}: so i went to the con i told you about earlier... #speaker: friend_chat
#location: virtual_two
#setting: 10
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
{kid_user}: during school hours? #speaker: child_chat
{friend_user}: yeah. if you cant make it, thats ok  #speaker: friend_chat
{kid_user}: how come youre not going #speaker: child_chat
{kid_user}: to school i mean #speaker: child_chat
{friend_user}: you got me, hahaha  #speaker: friend_chat
{friend_user}: parents are out of town, so im getting some much needed rest  #speaker: friend_chat
{friend_user}: just pretend youre sick or something #speaker: friend_chat
{kid_user}: ill think about it #speaker: child_chat
{friend_user}: guess ill know if you log in  #speaker: friend_chat
{friend_user}: anyways i gotta go  #speaker: friend_chat
{friend_user}: see ya  #speaker: friend_chat
{kid_user}: take care #speaker: child_chat #funblip
//Friend blips out here. Kid stands up

(... what do I do? ) #speaker: child #door #door1pos: (-7.48,-1.41) #door2pos: (7.29,-1.41)

 * [Try skipping school.]
    (Worth a shot. I don't wanna go to school anyways.) #speaker: child
    -> sick_day
 * [Go to school tomorrow.]
    (I better not skip. Dad would be mad. ) #speaker: child
    -> dinner_two

== sick_day == 
#location: bedroom
#switch: 5
#setting: 7
//Kid is in bed, waiting for their father to come in 
//The 3,2,1 should be a second apart each
(Okay, knock in 3, 2, 1...) #speaker: child 
//Knocking sound effect here 
Hey, are you up? I'm coming. #speaker: parent #timeline: 5
//Door opens. Parent walks to bed 
Alright kid, wake up. Time to go. #speaker: parent 
(...) #speaker: child 
Come on, get up, or we'll both be late. #speaker: parent 
-> Lie 

= Lie
    * I don't feel so good. #speaker: child 
    ~independence_meter += 0.1
    I don't see any blood. #speaker: parent 
    I have a fever, dad. #speaker: child 
    Let me see... hmmm, you seem okay to me. #speaker: parent 
    I'm really not... #speaker: child 
    Kid, don't lie to me. I know what you're trying to do. #speaker: parent 
    (...) #speaker: child 
    I'm really - #speaker: child
    Stop. Just... don't. C'mon, let's go. #speaker: parent 
    (...sigh) #speaker: child. 
    -> Lie
    
    * I'm getting up. #speaker: child 

//Kid gets up, parent and child walk to the centerish of the room. 

- Alright. After you. #speaker: parent child #door #door1pos: (-7.48,-1.41) #door2pos: (7.29,-1.41) #animation: child_stand_right
-> sick_doors

= sick_doors

 + [Go back to sleep.]
    Nope, don't even try. Let's go. #speaker: parent 
    -> sick_doors
 * [Go to school.]
    -> dinner_two

== dinner_two == 
#location: dinner_one
#setting: 8
#switch: 6
//For sounds, same as dinner_one, but quieter. 
So... how was school today? #speaker: parent 
Same. #speaker: child
Right, same... #speaker: parent
Do you wanna go to the park with me? We can bring a frisbee. #speaker: parent
I'm busy today. #speaker: child
Oh... with what? #speaker: parent 
Work. I guess. #speaker: child #timeline: 3
//Sounds stop
//Kid gets up. Walks out
... we haven't talked properly in a long time. #speaker: parent 
... #speaker: parent 

-> virtual_three 

== virtual_three == 
#location: virtual_three
#setting: 11
#cblip
//Kid blips into existence. Friend is already there. Both standing. 
{friend_user}: you took your time #speaker: friend_chat
{kid_user}: yeah sorry #speaker: child_chat 
{kid_user}: got distracted by something #speaker: child_chat 
{friend_user}: yeah no worries #speaker: friend_chat
{friend_user}: well, shall we? #speaker: friend_chat
{kid_user}: mhm, lets go #speaker: child_chat 
#location: virtual_two
#setting: 10
// Some time later, the two walk in the screen from the left. 
{friend_user}: nothing again #speaker: friend_chat
{friend_user}: sigh #speaker: friend_chat
{friend_user}: are we just trash? #speaker: friend_chat
{kid_user}: its just bad luck  #speaker: child_chat 
{kid_user}: the last update fucked the game up tbh #speaker: child_chat 
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
(... should I?) #speaker: child #door #door1pos: (-7.48,-1.41) #door2pos: (7.29,-1.41)
 * [Continue playing.]
    -> continue_playing
 * [Head back to work.]
    -> quit_for_now

= continue_playing 

{kid_user}: sigh #speaker: child_chat
{kid_user}: alright #speaker: child_chat
{kid_user}: one more game #speaker: child_chat
#location: virtual_two
#setting: 10 
{friend_user}: okay this really is the last try  #speaker: friend_chat
{kid_user}: heard that one before  #speaker: child_chat
{friend_user}: i think ive figured out how to beat the boss, for real this time  #speaker: friend_chat #interrupt: 3
//While the above sentence is typing, the screen should cut off suddenly
->too_much_game

= quit_for_now

{kid_user}: no i really should be going #speaker: child_chat
{kid_user}: sorry #speaker: child_chat
{friend_user}: eh  #speaker: friend_chat
{friend_user}: whatever  #speaker: friend_chat
{friend_user}: see ya  #speaker: friend_chat
#fade_out
-> dinner_three

== too_much_game == 
#location: bedroom_unplugged_dark
#setting: 13
~played_over_time = true
... #speaker: child
(What? What happened?) #speaker: child
So this is what you're busy with? #speaker: parent 
(...) #speaker: child 
You'd rather game than spend some time with me? #speaker: parent 
Ever since I got you that thing, we've just been... apart. And you've always been quiet, but now you barely even look at me. #speaker: parent 
Every day, it's the same thing. I wish you'd stop playing your games. Or just play less, for fuck's sake. Do you know what time it is? #speaker: parent 
(... shit, it's late.) #speaker: child 
Get up. We're gonna sit together downstairs. I don't care if we talk or not. And this is gonna be a daily thing, besides dinner. #speaker: parent 
Come on. After you. #speaker: parent 
(...) #speaker: child #door #door1pos: (-7.48,-1.41) #door2pos: (7.29,-1.41)
-> too_much_doors

= too_much_doors
 + [Continue playing.]
    Don't even think about it. #speaker: parent
    -> too_much_doors
 * [Head downstairs.]
    -> dinner_three

== dinner_three == 
#location: dinner_three
#setting: 14
~ temp name_given = ""
//Both are sitting at the table, quietly eating. 
... #speaker: parent 
(...) #speaker: child 
(Today's the day. ) #speaker: child 
({friend_name} and I are meeeting today. ) #speaker: child
(Park at night. Weird time, but whatever. ) #speaker: child
(...) #speaker: child
(Should I tell dad?) #speaker: child 
({played_over_time:I think he's still mad. |I don't think he'll take it well. })
(What do I do?) #speaker: child 
Something on your mind? #speaker: parent 
Hm? #speaker: child 
You look pretty serious. What's on your mind? #speaker: parent 
... I want to go out today. #speaker: child 
Bit late, don't you think? #speaker: parent 
Why this all of a sudden? #speaker: parent 

* [I'm going to meet someone. ]
    Who? #speaker: parent 
    A friend. #speaker: child 
    Who? #speaker: parent 
    
    ** [Joe. ]#speaker: child
        ~name_given = "Joe"
        Who's Joe? #speaker: parent 
        (... you're better than this. Don't say it, don't say it, don't say it...) #speaker: child 
        Well? #speaker: parent 

    ** [{friend_name}]
        ~name_given = friend_name
        Who's that? #speaker: parent 
        
    ** [Just a friend. ]
        ~name_given = "this"

    -- Just a friend. You don't know them. #speaker: child 
    
* [I just wanna walk. ]
    Since when? Normally you'd just go up to your room. #speaker: parent 
    
* [<i> Say nothing </i> ]
    Don't wanna say, huh? #speaker: parent 
    
- Well, forget it. It's way too late for you to be walking around. #speaker: parent 
(... figures. ) #speaker: child 
{ name_given == "":
    ... you're going to meet your online friend, aren't you? #speaker: parent 
    (!) #speaker: child 
    I heard you sleep talking yesterday. Seemed like you were excited. #speaker: parent 
- else:
    ...say, is {name_given} your online friend? #speaker: parent 
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
... they're my only friend. #speaker: child #animation: child_stand_right
//Kid stands up here 
I'm telling you not to go. #speaker: parent  #animation: parent_stand
... #speaker: child 
You never listen to me. This is a bad idea. #speaker: parent #door #door1pos: (-7.48,-1.41) #door2pos: (7.29,-1.41)

//Lines to add as the player moves 
//Don't you step outside the house, kid. 
//Don't take another step. 
//Blah blah blah 

 + [<i> Head out. </i>]
    I'm sorry... #speaker: child 
    -> park_night_end
 * [<i> Stay at home. </i>]
    ... #speaker: parent 
    ... #speaker: child 
    I'm sorry, kid. #speaker: parent 
    One day, you'll get it. #speaker: parent 
    -> virtual_end
    
= park_night_end

~ temp dice_roll = RANDOM(1, 100) 
{ dice_roll >= 6:
    ->meet_friend
- else:
    ->meet_icecream
}

= meet_friend 
#location: park_night
#setting: 17
#switch: 9
#timeline: 10
#timeline_duration: 10
... #speaker: child 
... #speaker: friend_chat
... #speaker: child 
... #speaker: friend_chat 
{ raphael:
    Raphael! #speaker: friend_chat #animation: friend_wave
- else: 
    Hey! #speaker: friend_chat #animation: friend_wave
}
->end_game_1

= meet_icecream
#location: park_night_creepy
#setting: 15
#switch: 10
#pause 
Late... #speaker: child 
Where...? #speaker: child 
... #speaker: child #timeline: 7 #sound: creepy_icecream
Guess I'll wait a bit more. #speaker: child
//peek out and music around here
-> end_game_2


= virtual_end
#location: virtual_four 
#setting: 16
//No music for this scene
{kid_user}: ...
{kid_user}: been a while since you last came online... #speaker: child_chat 
{kid_user}: where did you go? #speaker: child_chat 
{kid_user}: ... #speaker: child_chat 
{kid_user}: i miss you #speaker: child_chat 
{kid_user}: ... #speaker: child_chat 
{kid_user}: ... #speaker: child_chat
#cunblip
->end_game_3

== end_game_1 == 
#location: park_day 
#setting: 18
#switch: 11
#timeline: 12 
#timeline_duration: 15
#endgame: true 
->END

== end_game_2 == 
#location: dinner_three 
#setting: 19
#switch: 12
#timeline: 14
#timeline_duration: 11
#endgame: true 
->END

== end_game_3 == 
#location: Bedroom2
#setting: 20
#switch: 13
#timeline: 9
#timeline_duration: 12
#endgame: true 


->END