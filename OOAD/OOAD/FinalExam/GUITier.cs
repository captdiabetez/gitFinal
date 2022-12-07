namespace FinalExam;
using System.Data;
using MySql.Data.MySqlClient;
class GuiTier{
    User user = new User();
    Datatier database = new Datatier();

    // print login page
    public User Login(){
        Console.WriteLine("------Welcome to Package Management Application------");
        Console.WriteLine("Please input Staff ID (staff_username): ");
        user.staff_username  = Console.ReadLine();
        Console.WriteLine("Please input password: ");
        user.staff_password  = Console.ReadLine();
        return user;
    }
    // print Dashboard after user logs in successfully
    public int Dashboard(User user){
        DateTime localDate = DateTime.Now;
        Console.WriteLine("---------------Dashboard-------------------");
        Console.WriteLine($"Hello: {user.staff_username }; Date/Time: {localDate.ToString()}");
        Console.WriteLine("Please select an option to continue:");
        Console.WriteLine("1. Process Konwn Package");
        Console.WriteLine("2. Process Unknown Package");
        Console.WriteLine("3. Package Record History");
        Console.WriteLine("4. Log Out");
        int option = Convert.ToInt16(Console.ReadLine());
        return option;
    }

    // show package records returned from database
    public void DisplayRecordHistory(DataTable tableEnrollment, DataTable tableResidents){
        Console.WriteLine("---------------Record History List-------------------");
        foreach(DataRow row in tableResidents.Rows){
           Console.WriteLine($"ResidentID: {row["id"]} \t CourseName: {row["full_name"]} \t {row["email"]}");
        }
    }
}
