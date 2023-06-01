using ChatGPT.Net;
using DMGPT;
using System.Configuration;
using NUnit.Framework;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Xml.Linq;

string apiKey = ConfigurationManager.AppSettings["chatGPTAPIKey"];
ChatGpt chatBot = new ChatGpt(apiKey);
chatBot.Config.MaxTokens = 1000;

Console.WriteLine("Welcome to DMGPT, a tool that can help the DM use ChatGPT to create a number of random items including standard and homebrew, estimate prices for each and export them to JSON to use in FoundryVTT");
Console.WriteLine("Some extra work may be needed to convert damage formulas after importing but this should be a good starting point");
Console.WriteLine("_________________________________________________________________________________________________________________");

int numOfItems = 0;
string itemSource = "";
string rarity = "";
bool includeBackstory = false;

for (bool validNumberOfItems = false; !validNumberOfItems;)
{
    Console.Write("How many items are do you want in the shop? ");
    string numOfItemsStr = Console.ReadLine();

    if (int.TryParse(numOfItemsStr, out numOfItems) && numOfItems > 0 && numOfItems <= 20)
    {
        validNumberOfItems = true;
    }
    else
    {
        Console.WriteLine("Something's not quite right, this should be an integer and should be between 1 and 20");
    }
}

for (bool validSource = false; !validSource;)
{
    Console.Write("Should the items be official [o], homebrew [h] or both [b]? ");
    string itemSourceStr = Console.ReadLine();

    switch (itemSourceStr)
    {
        case "o":
            itemSource = "from the official DnD source material and include which book it's from";
            validSource = true;
            break;
        case "h":
            itemSource = "and create an item that is not in the official dnd source material and label it as (Homebrew) at the end of the name";
            validSource = true;
            break;
        case "b":
            itemSource = "and decide whether to keep it as it's original description in the official DnD source material or to change something to make it a new homebrew item and choose to keep either the homebrew or the official item, if the item is Homebrew please mention (Homebrew) at the end of the name.";
            validSource = true;
            break;
        default:
            Console.WriteLine("Something's not quite right, the valid responses are o h or b");
            break;
    }
}

for (bool validRarity = false; !validRarity;)
{
    Console.Write("What is the highest level of rarity for the items? Common [c], Uncommon [u], Rare [r], Very Rare [v] or Legendary [l]: ");
    string rarityStr = Console.ReadLine();

    switch (rarityStr)
    {
        case "c":
            rarity = "common";
            validRarity = true;
            break;
        case "u":
            rarity = "uncommon";
            validRarity = true;
            break;
        case "r":
            rarity = "rare";
            validRarity = true;
            break;
        case "v":
            rarity = "very rare";
            validRarity = true;
            break;
        case "l":
            rarity = "legendary";
            validRarity = true;
            break;
        default:
            Console.WriteLine("Something's not quite right, the valid responses are c u r v or l");
            break;
    }
}

Console.Write("Do you want DMGPT to write a backstory for each item and how it got to the shop? [y]/[n]: ");
if (Console.ReadLine() == "y")
    includeBackstory = true;

Console.WriteLine("Enchanting items...");

// Request a number of items and store them in an array of items, these need to be split into individual requests or the response gets cut off for being too long
string[] shopInventoryStr = new string[numOfItems];
MagicItem[] shopInventory = new MagicItem[numOfItems];

Console.WriteLine("_________________________________________________________________________________________________________________");

for (int i = 0; i < numOfItems; i++)
{
    string request = "pick a random magic item for Dungeons and Dragons 5e of rarity " + rarity + " or lower " + itemSource + ". Then print as json string with name, description, type, source and rarity";
    MagicItem newItem = new MagicItem();
    shopInventory[i] = newItem.generateMagicItem(chatBot, request, includeBackstory).Result;

    Console.WriteLine("Name: " + shopInventory[i].name);
    Console.WriteLine("Rarity: " + shopInventory[i].rarity);
    Console.WriteLine("Type: " + shopInventory[i].type);
    Console.WriteLine("Description: " + shopInventory[i].description);
    Console.WriteLine("Price: " + shopInventory[i].price);
    Console.WriteLine("Source: " + shopInventory[i].source);
    if (includeBackstory)
        Console.WriteLine("Backstory: " + shopInventory[i].backstory);
    Console.WriteLine("_________________________________________________________________________________________________________________");
}

Console.Write("Do you want to export these items to json to be imported to Foundry? [y]/[n]: ");
if (Console.ReadLine() == "y")
    MagicItem.exportJson(shopInventory);
