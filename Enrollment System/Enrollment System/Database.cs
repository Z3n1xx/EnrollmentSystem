using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment_System
{
	public static class Database
	{
		public static string ConnectionString => @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""C:\Users\seant\OneDrive\Documents\Works\2nd Year 2nd Sem\StudentInformationSystem.accdb";

		public static OleDbConnection GetConnection()
		{
			return new OleDbConnection(ConnectionString);
		}
	}

}

