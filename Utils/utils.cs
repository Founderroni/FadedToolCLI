using System;
using System.Linq;
using System.Diagnostics;
using Memory;
using System.IO;

namespace FadedToolCLI.Utils
{
    public class utils
	{
		readonly string McDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Packages\Microsoft.MinecraftUWP_8wekyb3d8bbwe\LocalState\games\com.mojang\minecraftpe\";
		readonly Mem m = new Mem();

		public void AttachProcess()
		{
			Mem m = new Mem();
			try
			{
				Program.proc = Process.GetProcessesByName("Minecraft.Windows")[0];
			}
			catch
			{
				Console.WriteLine("Game wasn't found running");
			}
			if (!m.OpenProcess("Minecraft.Windows"))
			{
				Console.WriteLine("Failed to attach to process");
			}
		}

		public void SpoofIds(string Did, string Mcid)
        {
			Guid NewGuid = Guid.NewGuid();
			try
			{
				AttachProcess();
				if (!Directory.Exists(McDirectory))
				{
					Console.WriteLine("Minecraft Directory not found, are you using a custom launcher or not have Minecraft installed?");
				}
				else
				{
					File.Delete(McDirectory + "clientId.txt");
					Console.WriteLine("Deleted Client ID");
				}
				if (m.OpenProcess("Minecraft.Windows"))
				{
					if (Did == "") return;
					m.WriteMemory("base+" + Did, "string", NewGuid.ToString(), "", null, true);
					Console.WriteLine("Spoofed DID");
					if (Mcid == "") return;
					m.WriteMemory("base+" + Mcid, "string", RandomMcid(), "", null, true);
					Console.WriteLine("Spoofed MCID");
				}
			} catch (Exception ex)
            {
				Console.WriteLine(ex.Message);
            }
		}

		public string RandomMcid()
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			var random = new Random();
			var randomString = new string(Enumerable.Repeat(chars, 16).Select(s => s[random.Next(s.Length)]).ToArray());
			return randomString;
		}

	}
}