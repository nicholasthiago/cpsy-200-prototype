// CPSY 200 - Prototype

using System;
using System.IO;


class Program
{
	static void Main()
	{
		string adminList = "C:\\Users\\nicho\\OneDrive\\Documents\\PROJECTS\\other\\csharp-app\\data\\adminlist.csv";
		string recordList = "C:\\Users\\nicho\\OneDrive\\Documents\\PROJECTS\\other\\csharp-app\\data\\record_list.csv";

		// get userID from Admin / Instructor / Student Lists
		Console.Write("Enter your ID:\n");
		string userID = Console.ReadLine();


		  SearchStudent(adminList, recordList, userID);

		  
static void SearchStudent(string adminList, string recordList, string userID)
{
    if (File.Exists(adminList))
    {
        using (StreamReader adminReader = new StreamReader(adminList))
        {
            string line;
            while ((line = adminReader.ReadLine()) != null)
            {
                if (line.Contains(userID))
                {
                    Console.WriteLine(line);

                    // Get StudentID from StudentList
                    Console.Write("Enter the Student ID Number:\n");
                    string studentID = Console.ReadLine();

                    if (File.Exists(recordList))
                    {
                        using (StreamReader recordReader = new StreamReader(recordList))
                        {
                            while ((line = recordReader.ReadLine()) != null)
                            {
                                if (line.Contains(studentID))
                                {
                                    Console.WriteLine(line);
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Record list file not found!");
                    }
                }
            }
        }
    }
    else
    {
        Console.WriteLine("Admin list file not found!");
    }
}

		if ( File.Exists( adminList ))
		{
			using ( StreamReader login = new StreamReader( adminList ))
			{
				string line;
				while (( line = login.ReadLine() ) != null )
				{
					if ( line.Contains( userID ))
					{
						Console.WriteLine( line );

						// get StudentID from StudentList
						Console.Write("Enter the Student ID Number:\n");
						string studentID = Console.ReadLine();

						if ( File.Exists( recordList ))
						{
							using ( StreamReader reader = new StreamReader( recordList ))
							{
								// string line;
								while (( line = reader.ReadLine() ) != null )
								{
									if ( line.Contains( studentID ))
									{
										Console.WriteLine( line );
									}
								}
							}

						} else {
							Console.WriteLine("File not found!");
						}
					}
				}
			}

		} else {
			Console.WriteLine("File not found!");
		}

		
	}
}

