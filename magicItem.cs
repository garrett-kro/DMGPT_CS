using System.Text.RegularExpressions;
using System.Text.Json;
using ChatGPT.Net;

namespace DMGPT
{
    public class MagicItem
    {
        // Name of the item
        public string? name { get; set; }
        // Possible values are weapon, equipment, consumable, tool, loot, background, class, subclass, spell, feature and backpack
        public string? type { get; set; }
        // Path to the image in the local foundry folder
        public string? description { get; set; }
        public string? rarity { get; set; }
        // If the user wants a backstory ask DMGPT to generate a backstory for how the item was created and how it's in the shop
        // This will need to be it's own response or it gets cut off and will break the json
        public string? backstory { get; set; }
        public string? source { get; set; }
        // Price is determined by following the recommending prices in Xanathars Guide to Everything 
        public string? price { get; set; }

        public async Task<MagicItem> generateMagicItem(ChatGpt chatBot, string dmGPTRequestString, bool includeBackstory)
        {
            string response = await chatBot.Ask(dmGPTRequestString);

            // This pattern will match everything between two curly braces, sometimes ChatGPT returns multiple items or will specify the regular version and then the homebrew version
            // Using regex we ensure that this we will only send valid json
            string pattern = "{[^}]+}";

            Regex regex = new(pattern);
            MatchCollection items = regex.Matches(response);

            // We only care about returning a single item since multiple will break the json. ChatGPT always returns the homebrew item last and that's the one we want
            if (isJSON(items[^1].Value))
            {
                MagicItem magicItem = JsonSerializer.Deserialize<MagicItem>(items[^1].Value);

                if (includeBackstory)
                {
                    magicItem.backstory = generateMagicItemBackstory(chatBot, itemName: magicItem.name).Result;
                }

                magicItem.price = magicItem.calculatePrice(magicItem.rarity, magicItem.type).ToString() + " gp";

                return magicItem;
            }
            else
            {
                Console.WriteLine("Invalid json from DMGPT, right now we panic until we ask DMGPT to fix it's mistakes");
                return new MagicItem();
            }
        }

        private async Task<string> generateMagicItemBackstory(ChatGpt chatBot, string itemName)
        {
            return await chatBot.Ask("Generate a backstory for what the " + itemName + " is and how it ended up in a magic item shop in a Dungeons and Dragons 5e campaign");
        }

        // This is based off of XGTE page 126
        private int calculatePrice(string rarity, string type)
        {
            int price = 0;

            switch (rarity.ToLower())
            {
                // Common (1d6 + 1) × 10 gp
                case "common":
                    price = (d(6) + 1) * 10;
                    break;
                // Uncommon	1d6 × 100 gp        
                case "uncommon":
                    price = d(6) * 100;
                    break;
                // Rare	2d10 × 1,000 gp
                case "rare":
                    price = (d(10) + d(10)) * 1000;
                    break;
                // Very rare (1d4 + 1) × 10,000 gp
                case "very rare":
                    price = (d(4) + 1) * 10000;
                    break;
                // Legendary 2d6 × 25,000 gp
                case "legendary":
                    price = (d(6) + d(6)) * 25000;
                    break;
                default:
                    Console.WriteLine(rarity + " is not a valid rarity");
                    break;
            }

            // If the item is consumable the price should be halved, a rare potion should not cost as much as a rare sword
            if (type.ToLower() == "consumable")
                price /= 2;

            return price;
        }

        private int d(int sides)
        {
            Random dice = new Random();
            // This uses <= for the minimum value and > for the max so it should be one greater than the max value
            return dice.Next(1, sides + 1);
        }

        // Verifies if the sting supplied is valid json
        private static bool isJSON(string json)
        {
            try
            {
                JsonDocument.Parse(json);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void exportJson(MagicItem[] magicItems)
        {
            foreach (MagicItem item in magicItems)
            {
                string json = JsonSerializer.Serialize<MagicItem>(item);
                string outputDir = System.IO.Directory.GetCurrentDirectory() + "/" + DateTime.Now.ToString("MM-dd-yy-h-m") + "/";
                System.IO.Directory.CreateDirectory(outputDir);

                File.WriteAllText(outputDir + item.name + ".json", json);
            }
        }
    }
}
