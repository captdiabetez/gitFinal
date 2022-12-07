namespace FinalExam;
using System.Data;
using MySql.Data.MySqlClient;
class BusinessLogic
{
   
    static void Main(string[] args)
    {
        bool _continue = true;
        User user;
        GuiTier appGUI = new GuiTier();
        Datatier database = new Datatier();

        // start GUI
        user = appGUI.Login();

       
        if (database.LoginCheck(user)){

            while(_continue){
                int option  = appGUI.Dashboard(user);
                switch(option)
                {
                    // send email
                    case 1:
                        DataTable tableEnrollment = database.CheckEnrollment(user);
                        if(tableEnrollment != null)
                            appGUI.DisplayEnrollment(tableEnrollment);
                        break;
                    // process picked package
                    case 2:
                        Console.WriteLine("To Be Implemented");
                        break;
                    // process unknown package
                    case 3:
                        Console.WriteLine("To Be Implemented");
                        break;
                    // package history
                    case 4:
                        Console.WriteLine("To Be Implemented");
                        break;
                    // Log Out
                    case 5:
                        _continue = false;
                        Console.WriteLine("Log out, Goodbye.");
                        break;
                    // default: wrong input
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }

            }
        }
        else{
                Console.WriteLine("Login Failed, Goodbye.");
        }        
    }    
}
