VAR independence_meter = 0.1

->icecream_scene

== notes == 
Text written in (paranthesis) will describe the scene, background, appearance, etc. This us unfortunate for my normally parenthetical writing, but the sacrifice is mine to make. Please let me know if more detail is needed. By the way, I don't know if this is obvious, but I don't think you should draw the doors as part of the background. 

Stuff in ((double paranthesis)) are my own personal thoughts, notes, and suggestions. 

Stuff following a pound sign are tags. Jared, these will be important when we're programming; keep an eye on them. Check the ink documentation to see what they do and how we can refer to them. 

I'm currently thinking of a more appropriate start to the game than the ice-cream scene; it's just...not a good opener, you know?

I have the game's structure/flowchart written out. That is, I've already decided the order of the scenes.

*	[To the ice-cream scene!]
    ->icecream_notes
    
== icecream_notes ==

(A park where the father and child often relax together. There's a bench near the center of the scene, where the father is currently sitting; a tree offers some shade next to the bench. No need to draw an ice-cream truck, keeping it offscreen is fine. In the background, perhaps a street? I'll leave the rest to your imagination, Grace).

((I know I said to not worry about the "dark" ending till the very end, but I can't help but change the story/visuals ever so slightly to accomodate it. I think the park will be the last scene of the game; you meet your online friend here (night version as well?). Perhaps create an identical version of the park, but with a van in the distant background? Or a man standing in the background?))

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
    *   [Talk about losing your kite.]
        I lost my kite. #speaker: child
        Oh, no... where'd you lose it? #speaker: parent
        Lightning hit it. It burned up. #speaker: child
        (He probably just lost it. Right? Regardless...) #speaker: parent_thoughts
        ->no_piss_in_pants
    *   [Talk about the tree.]
        They threw me up a tree. #speaker: child
        What? Who did? #speaker: parent
        Bullies in my class. It took me an hour to get down. #speaker: child
        (An hour?! Did they use a catapult?) #speaker: parent_thoughts
        ->no_piss_in_pants
    *   [Talk about the bathrooms.]
        I needed to use the bathroom. #speaker: child
        And? It's right there. #speaker: parent
        I couldn't find it. #speaker: child
        (...Shit. ) #speaker: parent_thoughts
        ->piss_in_pants

= no_piss_in_pants
- I'm sorry, kid. Maybe we should have stayed at home... #speaker: parent 
Can I get some ice-cream? There's a stand over there. #speaker: child
Sure, why not. Let me...oh. I don't have cash on me right now. #speaker: parent 
->no_icecream_for_you

= piss_in_pants
- I'm sorry, kid. Maybe we should have stayed at home... #speaker: parent 
Can I get some ice-cream? There's a stand over there. #speaker: child
No...not with those pants on, you're not. #speaker: parent 
Can't you get some for me? #speaker: child
I want to, but I don't have cash on me right now. #speaker: parent 
->no_icecream_for_you

= no_icecream_for_you
Oh. #speaker: child
I'll get you some tonight, don't worry. #speaker: parent
I want it now... #speaker: child
Do you wanna rob the stand? #speaker: parent
Huh? #speaker: child
Because there's nothing else we can do about it. Come on, we're heading back. #speaker: parent
(Should I?) #speaker: child_thoughts #door #door1pos: (-7.48,-1.41) #door2pos: (7.29,-1.41)

    * Rob the stand. #door #position: (x,y) #reactive
        What are you doing? Get over here. #speaker: parent
    * Head to the car. #door #position: (x,y) 

- ->new_computer_notes 

== new_computer_notes == 

->END


