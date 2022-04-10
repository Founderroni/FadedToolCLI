using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FadedToolCLI.Utils;

namespace FadedToolCLI
{
    public class Program
    {
		public string DidPtr, McidPtr = "";
        internal static Process proc;

		static void Main(string[] args)
		{
			if (args.Length == 0)
			{
				Console.WriteLine("Invalid args");
				return;
			}

			var command = args[0];

			if (!commandMap.ContainsKey(command))
			{
				Console.WriteLine("Invalid command");
			}

			commandMap[command](args.Skip(1).ToArray());

		}
		private static readonly Dictionary<string, Action<string[]>> commandMap = new Dictionary<string, Action<string[]>>(StringComparer.InvariantCultureIgnoreCase)
		{
			[nameof(Quick)] = Quick,
			[nameof(Spoof)] = Spoof
		};

		static void Quick(string[] args)
		{
			utils Util = new utils();
			Util.SpoofIds("0458F1A8,0,20,0", "045CC590,0,30,20,60,0");
			Console.WriteLine("Spoofed");
		}
		static void Spoof(string[] args)
		{
			Program pg = new Program();
			utils Util = new utils();
			if (args.Length == 2 && args[0] == "-v")
			{
				switch (args[1])
                {
					case "1.16.40":
						pg.DidPtr = "0368EE98,80,0,8,290,0";
						break;
					case "1.16.100":
						pg.DidPtr = "03582140,D0,48,80,0,8,290,0";
						break;
					case "1.16.201":
						pg.DidPtr = "03A17598,10,80,0,8,290,0";
						break;
					case "1.16.210":
						pg.DidPtr = "037C7170,D0,48,218,50,2F0,0";
						break;
					case "1.16.221":
						pg.DidPtr = "03CCB7A8,10,4D0,8,260,20,2E0,0";
						break;
					case "1.17":
						pg.DidPtr = "03FE4618,0,4D0,280,30,40,2E0,0";
						break;
					case "1.17.0":
						pg.DidPtr = "03FE4618,0,4D0,280,30,40,2E0,0";
						break;
					case "1.17.2":
						pg.DidPtr = "03F54B70,D8,10,D0,50,2F0,0";
						break;
					case "1.17.10":
						pg.DidPtr = "040776C8,3F8,218,50,2F0,0";
						break;
					case "1.17.11":
						pg.DidPtr = "040776C8,3F8,218,50,2F0,0";
						break;
					case "1.17.40":
						pg.DidPtr = "041F32E8,0,20,0";
						break;
					case "1.17.41":
						pg.DidPtr = "041F4318,0,20,0";
						pg.McidPtr = "042175D0,0,30,20,60,0";
						break;
					case "1.18":
						pg.DidPtr = "004215D08,0,20,0";
						pg.McidPtr = "04244650,0,30,20,60,0";
						break;
					case "1.18.0":
						pg.DidPtr = "004215D08,0,20,0";
						pg.McidPtr = "04244650,0,30,20,60,0";
						break;
					case "1.18.2":
						pg.DidPtr = "0421B218,0,20,0";
						pg.McidPtr = "04249B70,0,30,18,50,0";
						break;
					case "1.18.10":
						pg.DidPtr = "0458F1C8,0,20,0";
						pg.McidPtr = "045CC5F0,0,30,20,60,0";
						break;
					case "1.18.10.4":
						pg.DidPtr = "0458F1C8,0,20,0";
						pg.McidPtr = "045CC5F0,0,30,20,60,0";
						break;
					case "1.18.12":
						pg.DidPtr = "0458F1A8,0,20,0";
						pg.McidPtr = "045CC590,0,30,20,60,0";
						break;
					case "1.18.12.1":
						pg.DidPtr = "0458F1A8,0,20,0";
						pg.McidPtr = "045CC590,0,30,20,60,0";
						break;
				}
				Util.SpoofIds(pg.DidPtr,pg.McidPtr);
				Console.WriteLine($"Spoofed on version: {args[1]}");
			}
			else
			{
				Console.WriteLine("Invalid args. Expected format: spoof -v <game version>\nExample: spoof -v 1.18.12");
			}
		}
	}
}