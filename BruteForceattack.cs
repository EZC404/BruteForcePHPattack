using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPasswordGether.Classes
{
	public class BruteForceattack
	{
		static char[] Match =            {'0','1','2','3','4','5','6','7','8','9','a','b','c','d','e','f','g','h','i','j' ,'k','l','m','n','o','p',
						'q','r','s','t','u','v','w','x','y','z','A','B','C','D','E','F','G','H','I','J','C','L','M','N','O','P',
						'Q','R','S','T','U','V','X','Y','Z','!','?',' ','*','-','+'};
		static string FindPassword;
		static int Combi;
		static string space;
		static int Characters;

		public static string tpass;
		public static bool v = false;

		public BruteForceattack()
		{
			space = " ";
			int Count;

			for (Count = 0; Count <= 15; Count++)
			{
				if (v == false)
				{
					Recurse(Count, 0, "");
				}
			}
		}

		static void Recurse(int Lenght, int Position, string BaseString)
		{
			int Count = 0;
			tpass = BaseString;
			Console.WriteLine(BaseString);
			Program.checkPassword(BaseString);
			for (Count = 0; Count < Match.Length; Count++)
			{
				Combi++;
				if (Position < Lenght - 1)
				{
					Recurse(Lenght, Position + 1, BaseString + Match[Count]);
				}
			}
		}
	}
}

