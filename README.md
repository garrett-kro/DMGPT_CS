# DMGPT_CS
DMGPT is a proof of concept to test if ChatGPT will be useful when running DMing a campaign. This console app will allow the user to generate a shop inventory of either homebrew or official items by specifying:
- Number of items
- Source of the items
    - Possible values are **o** for official, **h** for homebrew, or **b** for both
- Max Rarity of the items
    - Possible values are **c** for common, **u** for uncommon, **r** for rare, **v** for very rare or **l** for legendary
- If DMGPT should also generate a backstory for the items
- Whether or not to save output as json to be imported to FoundryVTT

**You should always double check the work from DMGPT, it's usually pretty good at determining the rarity but sometimes it likes to label the item incorrectly** 

## Steps to run

There are two easy ways to build and run DMGPT
- Use Visual Studio and build through the UI
- Through the sommand line by calling: 
    - dotnet build
    - dotnet run

## Sample Output

> Welcome to DMGPT, a tool that can help the DM use ChatGPT to create a number of random items including standard and homebrew, estimate prices for each and export them to JSON to use in FoundryVTT
> Some extra work may be needed to convert damage formulas after importing but this should be a good starting point
> _________________________________________________________________________________________________________________
> How many items are do you want in the shop? 2
>
> Should the items be official [o], homebrew [h] or both [b]? h
>
> What is the highest level of rarity for the items? Common [c], Uncommon [u], Rare [r], Very Rare [v] or Legendary [l]: r
>
> Do you want DMGPT to write a backstory for each item and how it got to the shop? [y]/[n]: y
> Enchanting items...
> _________________________________________________________________________________________________________________
> Name: Amulet of the Crimson Phoenix (Homebrew)
>
> Rarity: Rare
>
> Type: Wondrous item
>
> Description: This amulet is adorned with a small ruby that glows like a flame. Once per day, the wearer can activate the amulet to transform into a giant phoenix for up to 1 hour. While in phoenix form, the wearer gains a flying speed of 90 feet and can deal an additional 2d10 fire damage with their attacks. Additionally, the wearer gains resistance to fire damage and can cast the spell Fireball (3rd level) once during their transformation. After the transformation ends, the wearer cannot use this ability again until the next dawn.
>
> Price: 12000 gp
>
> Source: Homebrew
>
> Backstory: Long ago, in a far-off land, there was a powerful sorceress named Xinghua. She was known throughout the land for her incredible magical abilities and her fierce loyalty to the kingdom. Xinghua was the personal advisor to the king, and she used her magic to protect the kingdom from all manner of threats.
>
> One day, Xinghua received a vision from the goddess of fire and rebirth, the Crimson Phoenix. The goddess told Xinghua that the kingdom was in grave danger, and that only a powerful artifact could save them. The artifact was the Amulet of the Crimson Phoenix, and it was said to contain the power of the goddess herself.
>
> Determined to save her kingdom, Xinghua set out on a perilous quest to find the amulet. She traveled across the land, battling monsters and facing great dangers, until she finally found the amulet in a hidden temple deep in the mountains.
>
> With the amulet in her possession, Xinghua returned to the kingdom and used its power to defeat the great evil that threatened it. The amulet became a symbol of hope and protection for the people, and it was passed down through generations of kings and queens.
>
> However, as time passed, the amulet was lost and forgotten. It was eventually discovered by a group of adventurers who stumbled upon it in an old ruin. They recognized its value and took it to a magic item shop to sell, not realizing the true power of the artifact they had found.>
>
> And so, the Amulet of the Crimson Phoenix ended up in a magic item shop, waiting for someone to discover its true potential and use it to protect the kingdom once again.
> _________________________________________________________________________________________________________________
> Name: Ring of Spell Storing (Homebrew)
>
> Rarity: Rare
>
> Type: Ring
>
> Description: This silver ring has a deep blue gemstone set in the center. The ring has 3 charges, and regains all expended charges daily at dawn. While wearing the ring, you can cast a spell into it as an action, choosing one of the following options:
>
> 1. Store a Spell: When you cast a spell that targets only you, you can store the spell in the ring. The spell has no effect but is stored within the ring.
>
> 2. Cast a Spell: While wearing the ring, you can cast any spell stored in it. The spell uses the slot level, spell save DC, spell attack bonus, and spellcasting ability of the original caster, but is otherwise treated as if you cast the spell.
>
> 3. Gift a Spell: You can give the ring to another creature. When you do so, you can choose to transfer any spells stored in the ring to the creature.
>
> The ring can store up to 3 levels worth of spells at a time. When you store a spell, it must be of a level you can cast, and it must target only you (or be a self-targeting spell). Spells cast from the ring have no verbal or somatic components.
> Price: 10000 gp
> Source: Homebrew
> Backstory: Long ago, in a land far away, there was a powerful wizard named Azura. Azura was known throughout the land for her incredible magical abilities and her thirst for knowledge. She spent her life studying ancient tomes and mastering spells that few others could even dream of casting.
>
> One day, Azura discovered an ancient artifact that would change her life forever: the Ring of Spell Storing. This powerful ring allowed Azura to store her spells inside it, allowing her to cast them at a later time without expending any of her own magical energy. With this incredible tool at her > disposal, Azura became even more powerful than she had ever been before.
>
> For years, Azura used the Ring of Spell Storing to protect her kingdom from threats both foreign and domestic. However, as she grew older, she realized that she would not be able to keep the ring forever. She knew that it was too powerful for any one person to possess, and that it needed to be hidden away where it could not fall into the wrong hands.
>
> So, Azura traveled to a distant land and placed the ring in the care of a group of powerful wizards. She instructed them to keep the ring safe, and to only pass it on to someone who was worthy of its power.
>
> Over the centuries, the Ring of Spell Storing passed through many hands, each of whom used its power to protect their people and fight against evil. Eventually, the ring found its way into the hands of a young wizard named Elara.
>
> Elara was just starting her career as an adventurer, and she quickly realized the potential of the Ring of Spell Storing. She used it to great effect, storing powerful spells inside it and unleashing them at just the right moment.
>
> However, one day Elara was captured by a group of bandits. They took everything she had, including the Ring of Spell Storing. Elara was devastated, knowing that the ring was now in the hands of people who would use it for evil.
>
> Years passed, and Elara thought she would never see the ring again. But one day, while browsing a magic item shop, she saw it sitting in a display case. She immediately recognized it, and knew that she had to buy it back.
>
> Now, Elara keeps the Ring of Spell Storing close at all times, using it to protect the innocent and fight against evil wherever she goes.
> _________________________________________________________________________________________________________________
> Do you want to export these items to json to be imported to Foundry? [y]/[n]: y
