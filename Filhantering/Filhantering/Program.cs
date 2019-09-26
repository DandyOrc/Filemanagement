using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Filhantering
{
    class Program
    {
    static void Main(string[] args)
    {
        bool tempCorrectInput = false;
        int tempPlayerChoiceMainMenu = 0;
        
        while (tempCorrectInput == false)
        {
            Console.WriteLine("Choose a path?");
            Console.WriteLine("1. Create a lifeform");
            Console.WriteLine("2. Read a lifeforms file");
            Console.WriteLine("3. Exit program");
            int.TryParse(Console.ReadLine(), out tempPlayerChoiceMainMenu);
            switch (tempPlayerChoiceMainMenu)
            {
                case 1:
                    Console.Clear();
                    ChoosePath();
                    break;

                case 2:
                    Console.Clear();
                    ReadLifeform();
                    break;

                case 3:
                    Environment.Exit(0);
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Choose a number between 1-3");
                    break;
            }
        }
    }

    static void ChoosePath()
    {
            int tempPlayerChoiceJediOrSith = 0;

            Console.WriteLine("Welcome my padawan here is where you are going to choose a path between either the dark side or the light side!");
            Console.WriteLine("1. Create a Jedi");
            Console.WriteLine("2. Create a Sith");
            int.TryParse(Console.ReadLine(), out tempPlayerChoiceJediOrSith);
            switch (tempPlayerChoiceJediOrSith)
            {
                case 1:
                    Console.Clear();
                    CreateLifeform();
                    break;

                case 2:
                    Console.Clear();
                    CreateLifeform();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Choose a number between 1-2");
                    break;
            }
        }

    static void CreateLifeform()
    {
        string[] countries = new string[1];
        string tempForename;
        string tempSurname;
        int tempBirthdate = 0;
        int tempSex;
        int tempRace;
        int tempHomePlanet;
        bool tempCorrectInput = false;

        tempForename = GetName("What's the forename of the person");
            Console.Clear();
        tempSurname = GetName("What's the surname of the person");
            Console.Clear();

        tempBirthdate = GetBirthdate(tempForename, tempSurname);
            Console.Clear();

        do
        {
            tempCorrectInput = false;
            Console.WriteLine("What sex is " + tempForename + " " + tempSurname + "?");
            Console.WriteLine("1. Male");
            Console.WriteLine("2. Women");
            Console.WriteLine("3. Non-binary");

            if (int.TryParse(Console.ReadLine(), out tempSex))
            {
                if (tempSex > 0 && tempSex < 4)
                {
                    tempCorrectInput = true;
                }
                else
                {
                    Console.WriteLine("Answer needs to be 1-3");
                    Console.Clear();
                }
            }
        } while (tempCorrectInput == false);
            Console.Clear();

            do
            {
                tempCorrectInput = false;
                Console.WriteLine("What race is " + tempForename + " " + tempSurname + "?");
                Console.WriteLine("1. Human");
                Console.WriteLine("2. Wookiee");
                Console.WriteLine("3. Ewok");
                Console.WriteLine("4. Geonosian");
                Console.WriteLine("5. Togruta");
                Console.WriteLine("6. Non-binary");

                if (int.TryParse(Console.ReadLine(), out tempRace))
                {
                    if (tempRace > 0 && tempRace < 7)
                    {
                        tempCorrectInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Answer needs to be 1-6");
                        Console.Clear();
                    }
                }
            } while (tempCorrectInput == false);
            Console.Clear();

            do
            {
                tempCorrectInput = false;
                Console.WriteLine("What is your home planet " + tempForename + " " + tempSurname + "?");
                Console.WriteLine("1. Tatooine");
                Console.WriteLine("2. Hoth");
                Console.WriteLine("3. Naboo");
                Console.WriteLine("4. Geonosis");
                Console.WriteLine("5. Aldaraan");
                Console.WriteLine("6. Corusant");
                Console.WriteLine("7. Non-binary");

                if (int.TryParse(Console.ReadLine(), out tempHomePlanet))
                {
                    if (tempHomePlanet > 0 && tempHomePlanet < 8)
                    {
                        tempCorrectInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Answer needs to be 1-7");
                        Console.Clear();
                    }
                }
            } while (tempCorrectInput == false);
            Console.Clear();
        
        string tempFilePath = Path.GetFullPath("Lifeforms/" + tempSurname + "_" + tempForename + ".txt");

            string[] filePaths = Directory.GetFiles(Path.GetFullPath("Lifeforms/"), "*.txt");
        for (int i = 0; i < filePaths.Length; i++)
        {
            if (filePaths[i] == Path.GetFullPath("Lifeforms/" + tempForename + "_" + tempSurname + ".txt"))
            {
                int tempUserInput;
                Console.WriteLine("WARNING!!! A file already exist");
                Console.WriteLine("[{0}] Throwaway this person", 1);
                Console.WriteLine("[{0}] Overwrite the old file", 2);
                if (int.TryParse(Console.ReadLine(), out tempUserInput))
                {
                    switch (tempUserInput)
                    {
                        case 1:
                            return;
                        case 2:
                            tempFilePath = Path.GetFullPath("Lifeforms/" + tempSurname + "_" + tempForename + ".txt");
                            break;
                        default:
                            Console.WriteLine("Choose a number between 1-2");
                            break;
                    }
                }
            }
        }
        using (FileStream tempFileStream = File.Create(tempFilePath))
        {
            AddText(tempFileStream, tempForename + ";" + tempSurname + ";" + tempBirthdate + ";" + tempSex + ";" + tempRace + ";" + tempHomePlanet);
        }
        Console.WriteLine("Your lifeform was saved to " + tempFilePath);
        Console.WriteLine("Press enter to continue");
        Console.ReadKey();
        Console.Clear();
    }

    static void ReadLifeform()
    {
        int tempPlayerChoice = 1;
        Console.WriteLine("Select a lifeforms file");
        string[] filePaths = Directory.GetFiles(Path.GetFullPath("Lifeforms/"), "*.txt");
        if (filePaths.Length < 1)
        {
            Console.WriteLine("There are no files to be found. ERROR 404");
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
            return;
        }
        for (int i = 0; i < filePaths.Length; i++)
        {
            Console.WriteLine("[" + (i + 1) + "] " + filePaths[i]);
        }
        bool tempCorrectInput = false;
        while (tempCorrectInput == false)
        {
            int.TryParse(Console.ReadLine(), out tempPlayerChoice);
            if (tempPlayerChoice > 0 && tempPlayerChoice <= filePaths.Length)
            {
                tempCorrectInput = true;
            }
        }
        using (FileStream tempFileStream = File.OpenRead(filePaths[tempPlayerChoice - 1]))
        {
            byte[] tempArray = new byte[tempFileStream.Length];
            UTF8Encoding tempText = new UTF8Encoding(true);
            while (tempFileStream.Read(tempArray, 0, tempArray.Length) > 0)
            {
                string[] personArray = tempText.GetString(tempArray).Split(';');
                Console.Clear();
                Console.WriteLine("Forename: " + personArray[0]);
                Console.WriteLine("Surname: " + personArray[1]);
                if (personArray[2].Length == 6)
                {
                    Console.WriteLine("Birthdate: " + personArray[2]);
                }
                else if (personArray[2].Length == 5)
                {
                    Console.WriteLine("Birthdate: 0" + personArray[2]);
                }
                switch (Int32.Parse(personArray[3]))
                {
                    case 1:
                        Console.WriteLine("Sex: Male");
                        break;

                    case 2:
                        Console.WriteLine("Sex: Women");
                        break;

                    case 3:
                        Console.WriteLine("Sex: Non-binary");
                        break;
                }
                    switch (Int32.Parse(personArray[3]))
                    {
                        case 1:
                            Console.WriteLine("Race: Human ");
                            break;

                        case 2:
                            Console.WriteLine("Race: Wookiee");
                            break;

                        case 3:
                            Console.WriteLine("Race: Ewok");
                            break;

                        case 4:
                            Console.WriteLine("Race: Geonosian");
                            break;

                        case 5:
                            Console.WriteLine("Race: Togruta");
                            break;

                        case 6:
                            Console.WriteLine("Race: Non-binary");
                            break;    
                    }
                    switch (Int32.Parse(personArray[4]))
                    {
                        case 1:
                            Console.WriteLine("Home Planet: Tatooine");
                            break;

                        case 2:
                            Console.WriteLine("Home Planet: Hoth");
                            break;

                        case 3:
                            Console.WriteLine("Home Planet: Naboo");
                            break;

                        case 4:
                            Console.WriteLine("Home Planet: Geonosis");
                            break;

                        case 5:
                            Console.WriteLine("Home Planet: Alderaan");
                            break;

                        case 6:
                            Console.WriteLine("Home Planet: Corusant");
                            break;

                        case 7:
                            Console.WriteLine("Home Planet: Non-binary");
                            break;
                    }



                }
        }
        Console.WriteLine("Press a button to continue");
        Console.ReadKey();
        Console.Clear();
    }

    static void AddText(FileStream aFileStream, string aStringToAdd)
    {
        byte[] tempTextToWrite = new UTF8Encoding(true).GetBytes(aStringToAdd);
        aFileStream.Write(tempTextToWrite, 0, tempTextToWrite.Length);
    }

    static string GetName(string aString)
    {
        bool tempCorrectInput;
        do
        {
            Console.WriteLine(aString);
            tempCorrectInput = false;
            string tempName = Console.ReadLine();

            foreach (char tempChar in tempName)
            {
                if (char.IsLetter(tempChar))
                {
                    tempCorrectInput = true;
                    return tempName;
                }
                else
                {
                    tempCorrectInput = false;
                    Console.WriteLine("Only letters can be found in the name");
                }
            }
        } while (tempCorrectInput == false);
        return null;
    }

    static int GetBirthdate(string aForename, string aSurname)
    {
        bool tempCorrectBirthdate = false;
        do
        {
            string tempYear;
            bool tempCorrectYear = false;
            do
            {
                Console.WriteLine("What year was " + aForename + " " + aSurname + " born? (YYYY)");
                tempYear = Console.ReadLine();
                if (tempYear.Length < 5 && tempYear.Length > 3)
                {
                    foreach (char tempChar in tempYear)
                    {
                        if (char.IsNumber(tempChar))
                        {
                            tempCorrectYear = true;
                        }
                        else
                        {
                            tempCorrectYear = false;
                            Console.WriteLine("Only numbers can be found in the year");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("A four long number is valid input");
                }
            } while (tempCorrectYear == false);

            string tempMonth;
            bool tempCorrectMonth = false;
            do
            {
                Console.Clear();
                Console.WriteLine("What month was " + aForename + " " + aSurname + " born? (MM)");
                tempMonth = Console.ReadLine();
                if (tempMonth.Length < 3 && tempMonth.Length > 1)
                {
                    foreach (char tempChar in tempMonth)
                    {
                        if (char.IsNumber(tempChar))
                        {
                            tempCorrectMonth = true;
                        }
                        else
                        {
                            tempCorrectMonth = false;
                            Console.WriteLine("Only numbers can be found in the month");
                        }
                    }
                }
            } while (tempCorrectMonth == false);

            string tempDay;
            bool tempCorrectDay = false;
            do
            {
                Console.Clear();
                Console.WriteLine("What day was " + aForename + " " + aSurname + " born? (DD)");
                tempDay = Console.ReadLine();
                if (tempDay.Length < 3 && tempDay.Length > 1)
                {
                    foreach (char tempChar in tempDay)
                    {
                        if (char.IsNumber(tempChar))
                        {
                            tempCorrectDay = true;
                        }
                        else
                        {
                            tempCorrectDay = false;
                            Console.WriteLine("Only numbers can be found in the month");
                        }
                    }
                }
            } while (tempCorrectDay == false);

            string tempBirthdate = tempMonth + "-" + tempDay + "-" + tempYear + " 00:00:00.0";
            if (DateTime.TryParse(tempBirthdate, out DateTime temp) && int.TryParse(tempBirthdate, out int temp2))
                tempCorrectBirthdate = true;

            if (!(int.Parse(tempYear) < DateTime.Now.Year))
            {
                Console.Clear();
                Console.WriteLine("Invalid BirthDate");
            }
            else
            {
                tempCorrectBirthdate = true;
            }
        } while (tempCorrectBirthdate == false);
        return 1;
    }

}
}
