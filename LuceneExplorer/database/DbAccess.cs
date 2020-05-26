﻿using LuceneExplorer.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuceneExplorer.database
{
    public class DbAccess
    {
        /**
         * Kiểm tra kết nối database
         */
        public static bool TestConnection()
        {
            using (SqlConnection conn = DbConfiguration.GetDBConnection())
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Kết nối database thành công");
                    return true;
                }
                catch(InvalidOperationException invalid)
                {
                    Console.WriteLine("Kết nối database thất bại");
                    return false;
                }
                catch (SqlException sqle)
                {
                    Console.WriteLine("Kết nối database thất bại");
                    return false;
                }
            }
        }

        /**
         * Lấy tất cả danh sách các loại extension
         */
        public static List<FileType> GetTypes()
        {
            List<FileType> listType = new List<FileType>();
            using (SqlConnection conn = DbConfiguration.GetDBConnection())
            {
                conn.Open();
                var query = "SELECT * FROM FileType";
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            // Console.WriteLine("{0},{1}", sdr.GetString(0), sdr.GetBoolean(1));
                            listType.Add(new FileType(sdr.GetString(0), sdr.GetBoolean(1)));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Không load được dữ liệu");
                    }
                }
            }
            Console.WriteLine("Số type đã load được: {0}", listType.Count);
            return listType;
        }

        public static void setTypes(string[] types)
        {
            int count = 0;
            using (SqlConnection conn = DbConfiguration.GetDBConnection())
            {
                conn.Open();
                var query = "INSERT INTO FileType (TENTYPE, ISUSE) VALUES (@tentype, @isuse)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tentype", SqlDbType.VarChar);
                    cmd.Parameters.Add("@isuse", SqlDbType.Bit);

                    foreach (string type in types)
                    {
                        Console.WriteLine(type);
                        try
                        {
                            cmd.Parameters[0].Value = type;
                            cmd.Parameters[1].Value = 0;
                            cmd.ExecuteNonQuery();
                            count++;
                        }
                        catch(SqlException sqle)
                        {
                            Console.WriteLine("Type đã tồn tại: {0}", type);
                        }
                    }
                }
            }
        }

        public static void UpdateType(string type, bool isuse)
        {
            using (SqlConnection conn = DbConfiguration.GetDBConnection())
            {
                conn.Open();
                var query = "UPDATE FileType SET ISUSE = @isuse where TENTYPE = @tentype";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tentype", SqlDbType.VarChar);
                    cmd.Parameters.Add("@isuse", SqlDbType.Bit);

                    try
                    {
                        cmd.Parameters[0].Value = type;
                        cmd.Parameters[1].Value = isuse;
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException sqle)
                    {
                        Console.WriteLine("Update thất bại");
                    }
                    
                }
            }
        }
    }
}
