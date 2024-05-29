-> start

===start===
Evening, after a hard day at the shop, a policeman showed up knocking at the front door.
"Hello sir, are you mister Teri Borgia?"
*[Nod]
->accept
*[Confirm]
"Yes, that is me"
->accept

===accept===
"I have an arrest order for your name" said the policeman
*[Look confused]
->look_confused
*[Deny]
"I am not sure what you are talking about"
->look_confused
===look_confused===
"You may be wondering what we have on you. You have not paid your taxes correctly for this bussiness and that led us to your whole criminal activity" explained the policeman.
*[Panic]
->arrest
*[Trie to lie]
->lie
===lie===
"I have no idea what you are talking about. This is a legitimate bussiness started by me beacuse of my mother's last wish."
"You do not need to lie to me. The arrest order is here and records show clearly you are a real piece of work." resisted policeman
->arrest
===arrest===
"The jail is waiting for you. You have no chance to avoid it. Only if yo have paid your taxes corretly... You can avoid police, but not the IRS." finished policeman as he put handcuffs on Teri.
->END