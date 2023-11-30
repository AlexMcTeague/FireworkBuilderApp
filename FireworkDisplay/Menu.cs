using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireworkDisplay {
    public class Menu {
        public List<string> Items { get; set; }

        public void SelectItem(string key) {
            key = key.Replace("Return to ", "");

            switch (key) {
                case "Main Menu":
                    Items = new List<string> { "Add Component", "List Components", "Preview Fireworks", "Exit Program" };
                    break;
                case "Add Component":
                    Items = new List<string> { "Add Rocket", "Add Payload", "Add Firework", "Return to Main Menu" };
                    break;
                case "List Components":
                    Items = new List<string> { "List Rockets", "List Payloads", "List Fireworks", "Return to Main Menu" };
                    break;
                case "Preview Fireworks":
                    Items = new List<string> { "Return to Main Menu" };
                    break;
                case "Exit Program":
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("ERROR: Unrecognized menu click");
                    Items = new List<string> { "Return to Main Menu" };
                    break;
            }
        }
    }
}
