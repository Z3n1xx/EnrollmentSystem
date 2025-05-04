using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment_System
{
	public static class Database
	{
		public static string ConnectionString => @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""C:\Users\seant\OneDrive\Documents\Works\2nd Year 2nd Sem\StudentInformationSystem.accdb"";";

		public static OleDbConnection GetConnection()
		{
			return new OleDbConnection(ConnectionString);
		}

		public static DataTable GetData(string sql, params OleDbParameter[] parameters)
		{
			using (OleDbConnection conn = GetConnection())
			{
				conn.Open();
				using (OleDbCommand cmd = new OleDbCommand(sql, conn))
				{
					if (parameters != null)
					{
						cmd.Parameters.AddRange(parameters);
					}
					using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
					{
						DataTable dt = new DataTable();
						adapter.Fill(dt);
						return dt;
					}
				}
			}
		}
	}
}

