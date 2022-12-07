namespace FinalExam;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
class Datatier{
    public string connStr = "server=20.172.0.16;user=jkhernandez2;database=jkhernandez2;port=8080;password=jkhernandez2";

    // perform login check using Stored Procedure "LoginCount" in Database based on given user' studentID and Password
    public bool LoginCheck(User user){
        MySqlConnection conn = new MySqlConnection(connStr);
        try
        {  
            conn.Open();
            string procedure = "LoginCount";
            MySqlCommand cmd = new MySqlCommand(procedure, conn);
            cmd.CommandType = CommandType.StoredProcedure; // set the commandType as storedProcedure
            cmd.Parameters.AddWithValue("@inputStaff_username", user.staff_username );
            cmd.Parameters.AddWithValue("@inputStaff_password", user.staff_password );
            cmd.Parameters.Add("@userCount", MySqlDbType.Int32).Direction =  ParameterDirection.Output;
            MySqlDataReader rdr = cmd.ExecuteReader();
           
            int returnCount = (int) cmd.Parameters["@userCount"].Value;
            rdr.Close();
            conn.Close();

            if (returnCount ==1){
                return true;
            }
            else{
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            conn.Close();
            return false;
        }
       
    }

    // perform enrollment check using Stored Procedure "CheckEnrollment" based on user and semester
    public DataTable CheckResidents(User user){
        MySqlConnection conn = new MySqlConnection(connStr);
        Console.WriteLine("Please input a semester in TermYear format, e.g: Fall2022, Spring2021");
        string semester = Console.ReadLine();
        try
        {  
            conn.Open();
            string procedure = "CheckResidents";
            MySqlCommand cmd = new MySqlCommand(procedure, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@inputStaff_username", user.staff_username );
            cmd.Parameters["@inputStaff_username"].Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("@inputResidents", semester);
            cmd.Parameters["@inputResidents"].Direction = ParameterDirection.Input;

            MySqlDataReader rdr = cmd.ExecuteReader();

            DataTable tableEnrollment = new DataTable();
            tableEnrollment.Load(rdr);
            rdr.Close();
            conn.Close();
            return tableResidents;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            conn.Close();
            return null;
        }
    }
}


