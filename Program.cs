// CPSY 200 - Prototype

using System;
using System.IO;

#pragma warning disable

class Program
{
	static void Main()
	{
		string userList = "C:\\Users\\nicho\\OneDrive\\Documents\\PROJECTS\\other\\csharp-app\\data\\logindata.csv";
		string adminList = "C:\\Users\\nicho\\OneDrive\\Documents\\PROJECTS\\other\\csharp-app\\data\\adminlist.csv";
		string recordList = "C:\\Users\\nicho\\OneDrive\\Documents\\PROJECTS\\other\\csharp-app\\data\\record_list.csv";

		// get userID from Admin / Instructor / Student Lists
		Console.Write("Enter your ID:\n");
		string userID = Console.ReadLine();


		if ( File.Exists( userList ))
		{
			using ( StreamReader login = new StreamReader( userList ))
			{
				string line;

				while (( line = login.ReadLine() ) != null )
				{
					if ( line.Contains( userID ))
					{
						string[] userCheck = line.Split(',');

						// get userID from Admin / Instructor / Student Lists
						Console.Write("Enter your password:\n");
						string userPswd = Console.ReadLine();

						if ( userPswd == userCheck[1] ) {
							Console.WriteLine("\nLogin Successfull\n");

							switch ( userCheck[0][0] )
							{
								case '4':	studentAccess(); 			break;
								case '5':	instructorAccess();			break;
								case '6':	adminAccess( recordList );	break;
								default:	adminAccess( recordList );	break;
							}
							
						} else {
							Console.WriteLine("Invalid Password!");
						}
					}
				}
			}

		} else {
			Console.WriteLine("File not found!");
		}
	}


	public static void studentAccess()		{ Console.WriteLine("path: Student Access Function"); }

	public static void instructorAccess()	{ Console.WriteLine("path: Instructor Access Function"); }

	public static void adminAccess( string recordList ) {

		Console.Write(
			"\nSelect an option:" +
			"\n [1] View Student Information"	+
			"\n [2] Update Student Information"	+
			"\n [3] Manage Student Waitlist"	+
			"\n [4] Register Student to Course	\n"
		);

		string adminOption = Console.ReadLine();

		switch ( adminOption[0] )
		{
			case '1':	get_StudentInfo( recordList );		break;
			case '2':	update_StudentInfo( recordList );	break;
			case '3':	manage_Waitlist();					break;
			case '4':	register_StudentToCourse();			break;

			default:	get_StudentInfo( recordList );		break;
		}
	}

	public static void get_StudentInfo( string recordList ) {
		// get StudentID from StudentList
		Console.Write("Enter the Student ID Number:\n");
		string studentID = Console.ReadLine();

		if ( File.Exists( recordList ))
		{
			using ( StreamReader reader = new StreamReader( recordList ))
			{
				string line;
				while (( line = reader.ReadLine() ) != null )
				{
					if ( line.Contains( studentID ))
					{
						string[] studentData = line.Split(',');

						Console.WriteLine(
							"\nFirst Name:				" + studentData[0] +
							"\nLast Name:				" + studentData[1] +
							"\nContact:					" + studentData[3] +
							"\nEducation Level:			" + studentData[5] +
							"\n\nCurrent Registered Courses: " +
							"\nCourse Number:			" + studentData[8] + "\n"
						);
					}
				}
			}

		} else {
			Console.WriteLine("File not found!");
		}
	}

	public static void update_StudentInfo( string recordList ) {
		Console.Write("Enter the Student ID Number:\n");
		string studentID = Console.ReadLine();

		if ( File.Exists( recordList ))
		{
			using ( StreamReader reader = new StreamReader( recordList ))
			{
				string line;
				while (( line = reader.ReadLine() ) != null )
				{
					if ( line.Contains( studentID ))
					{
						string[] studentData = line.Split(',');

						Console.WriteLine(
							"\nCurrent Student Information:" +
							"\nFirst Name:				" + studentData[0] +
							"\nLast Name:				" + studentData[1] +
							"\nContact:				" + studentData[3] +
							"\nEducation Level:			" + studentData[5]
						);

						
						Console.Write("Enter the Updated Student - First Name :\n");
						string newFirstName = Console.ReadLine();
						string newFN = ( newFirstName.Length	> 0 ) ? newFirstName	: studentData[0];

						Console.Write("Enter the Updated Student - Last Name :\n");
						string newLastName = Console.ReadLine();
						string newLN = ( newLastName.Length		> 0 ) ? newLastName		: studentData[1];

						Console.Write("Enter the Updated Student - Contact :\n");
						string newContact = Console.ReadLine();
						string newCT = ( newContact.Length		> 0 ) ? newContact		: studentData[3];

						Console.Write("Enter the Updated Student - Education Level :\n");
						string newEducation = Console.ReadLine();
						string newED = ( newEducation.Length	> 0 ) ? newEducation	: studentData[5];


						Console.WriteLine(
							"\nUpdated Student Information:" +
							"\nFirst Name:				" + newFN +
							"\nLast Name:				" + newLN +
							"\nContact:				" + newCT +
							"\nEducation Level:			" + newED
						);
					}
				}
			}

		} else {
			Console.WriteLine("Student not found!");
		}
	}

	public static void manage_Waitlist() {
		Console.WriteLine(
			"\nChecking for Courses with waitlists..." +
			"\n - no courses with active waitlists found\n"
		);
	}

	public static void register_StudentToCourse() {
		Console.WriteLine(
			"\nmethod: register_StudentToCourse"			+
			"\n - Used to register a Student for a course"	+
			"\n - Params: StudentID, CourseID"				+
			"\n - return: String [ message confirming student and course information ]"
		);
	}
}