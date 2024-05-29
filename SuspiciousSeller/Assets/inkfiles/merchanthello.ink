//Merchant
VAR firstTime=true
VAR nice=false

{
-firstTime:->first_time
-else: ->nextTimes
}

===first_time===
Oh hello humble business man! What can I help you with?
*Oh- hi! I don't know? I just opened a store near here.->services

==services==
Well, I am a humble merchant. My duty in life is to buy stuff, sell it, contact with other humble businessmen like me... Some people like to critique my methods, saying they are unmoral. But as you know business is business in whatever way it comes.
*So you do illegal things?->services_criminal
*Business requires questionable resources sometimes indeed.->services_itiswhatitis

==services_criminal==
Oh dear! How dare you accuse me of such! I don't think we will do good business together...
*Oh you might have misunderstood me... I have unconventional incomes as well.->services2
*Well, that is true ->services2

==services_itiswhatitis==
Ha Ha Ha! Is comfortable seeing people like me around here. Sometimes it gets lonely, you know? 
~nice=true
->services2
==services2==
So what can I offer for you?
*I just opened a second-hand clothing store. At the moment it doesn't look too inviting, so I am intending to repair it and better its functioning.->services3

==services3==
Well I can definetly help you with that. I can bring you a list of upgrade's offers from fellow businessmen and construction workers that can make your store pop! But I wonder, being a new business and all... how could you afford them? Do you have something to sell?
*How do you feel about clothes? ->howtopaynice

==howtopaynice==
That is an interesting idea... I am actually looking for some clothing pieces right now. I am being also a producer for a movie and they want me to find some excellent clothes for a cheap price! How difficult could that be!
*Then you found your solution->end
*I am not sure I find this a secure business...->convince

==convince==
Oh come on! Do you really have any better option? 
~nice=false
*I guess not->end
==end==
Come to me when you want to hire some service or sell me some cool pieces. I will pay for your clothes depending on how cool they are. Best luck with your store! See you around.
{nice:->suprise} 
->END
==suprise==
I see you are a promising young man. I will give you a big discount for your first upgrade. 
-> END
===nextTimes===
Oh hello good man how good to see you here!
*Hello dear merchant!
->END