using System;
using System.Text;

namespace SecretBMI
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//measuring performance
			var begin = DateTime.Now;

			Console.WriteLine ("Welcome to the secret BMI calculator.\n");
			Console.WriteLine ("----------------------------------------");
			Console.WriteLine ("Select the BMI you want to receive:\nfalse > USA \ntrue > Metric");

			//diminished the size of the variable (from int to bool), had to add a second variable for entering the while loop.
			bool selection = false;
			bool firstTry = true;

			String inputReceived = "";

			while (firstTry || (selection != false && selection !=true)) {
				try {
					inputReceived = Console.ReadLine ();
					selection = Convert.ToBoolean (inputReceived);

					if (selection != false && selection != true) {
						Console.WriteLine ("\nPlease enter a numeric value that is either 1 or 0.\n");
					} else {
						Console.WriteLine ("You entered '{0}'", selection);
					}

					//must complete without errors for the firstTry to be changed
					firstTry = false;
				} catch (FormatException ex) { //putting the exception as precise as possible
					Console.WriteLine ("\nPlease enter a numeric value that is either 1 or 0.\n");
				}

			}

			//putting all the variables here to remove the need to create other objects.
			//replaced these double objects by floats
			float weight;
			float height;
			//removed this variable because of inline operation
			//double BMI;


			//replaced by a stringbuilder object to create one object less
			StringBuilder returnValue = new StringBuilder();

			if (selection == true) {

				//increasing temporal locality, thus increasing speed. Put the same methods right next to each other.
				Console.WriteLine ("Please enter your weight in kg: ");
				Console.WriteLine ("Please enter your height in meters: ");
				weight = -1;
				height = -1;

				while (weight <= 0 || height <= 0) {
					try {
						//increasing temporal locality, thus increasing speed. Put the same methods right next to each other.
						inputReceived = Console.ReadLine ();
						inputReceived = Console.ReadLine ();
						weight = Convert.ToSingle (inputReceived);
						height = Convert.ToSingle (inputReceived);
						if (weight <= 0 || height <= 0) {
							Console.WriteLine ("\nPlease enter a numeric value that is bigger than 0 for both height and weight.\n");
						}

					} catch (FormatException ex) {
						Console.WriteLine ("\nPlease enter a numeric value.\n");
					}
				
				}
					

				//calculate BMI
				//BMI = weight/(height*height);

				//put the result of the equation in one statement to avoid the memory to be consumed by the double variable BMI
				returnValue.Append ("Your BMI is " + (weight / (height * height)));

				//Did not use foreach, and did not create any Strings because they are immutable, thus consume unnecessary space.
				//changed i variable to byte
				for (byte i = 0; i < returnValue.Length; i++) {
					returnValue.Replace (returnValue [i], (char)(returnValue [i] + 13));
				}

				Console.WriteLine (returnValue.ToString ());

			} else if (selection == false) {

				//increasing temporal locality, thus increasing speed. Put the same methods right next to each other.
				Console.WriteLine ("Please enter your weight in lb: ");
				Console.WriteLine ("Please enter your height in inches: ");
				weight = -1;
				height = -1;

				while (weight <= 0 || height <= 0) {
					try {
						//increasing temporal locality, thus increasing speed. Put the same methods right next to each other.
						inputReceived = Console.ReadLine ();
						inputReceived = Console.ReadLine ();
						weight = Convert.ToSingle (inputReceived);
						height = Convert.ToSingle (inputReceived);
						if (weight <= 0 || height <= 0) {
							Console.WriteLine ("\nPlease enter a numeric value that is bigger than 0 for both height and weight.\n");
						}

					} catch (FormatException ex) {
						Console.WriteLine ("\nPlease enter a numeric value.\n");
					}

				}


				//calculate BMI
				//BMI = weight/(height*height);

				//put the result of the equation in one statement to avoid the memory to be consumed by the double variable BMI
				returnValue.Append ("Your BMI is " + ((weight*703) / (height * height)));

				//Did not use foreach, and did not create any Strings because they are immutable, thus consume unnecessary space.
				//changed i variable to byte
				for (byte i = 0; i < returnValue.Length; i++) {
					returnValue.Replace (returnValue [i], (char)(returnValue [i] + 13));
				}

				Console.WriteLine (returnValue.ToString ());
			}

			var end = DateTime.Now;
			Console.WriteLine ("The program took {0} ms to execute.", (end - begin).TotalMilliseconds);
		}
	}
}