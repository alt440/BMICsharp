using System;
using System.Text;

namespace SecretBMIDecoder
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Enter the secret BMI result: ");

			//stringbuilder makes only one string object, more efficient.
			StringBuilder encodedString = new StringBuilder(Console.ReadLine ());

			//used the byte to do the recursion. takes less space than the int
			for (byte i = 0; i < encodedString.Length; i++) {
				encodedString.Replace (encodedString [i], (char)(encodedString [i] - 13));
			}

			Console.WriteLine ("\n" + encodedString.ToString ());
		}
	}
}
