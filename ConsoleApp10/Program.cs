using ClickHouse.Ado;
using ClickHouse.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            Select();
        }

        private static ClickHouseConnection GetConnection(string cstr = "Compress=True;CheckCompressedHash=False;Compressor=lz4;Host=192.168.32.239;Port=9334;Database=jcyj10;User=default;Password=")
        {
            var settings = new ClickHouseConnectionSettings(cstr);
            var cnn = new ClickHouseConnection(settings);
            cnn.Open();
            return cnn;
        }
        /*查询*/
        public static void Select()
        {
            ClickHouse.Net.ClickHouseDatabase clickHouseDatabase = new ClickHouse.Net.ClickHouseDatabase(new ClickHouseConnectionSettings("Compress=True;CheckCompressedHash=False;Compressor=lz4;Host=192.168.32.239;Port=9334;Database=jcyj10;User=default;Password="), new ClickHouseCommandFormatter(), new ClickHouseConnectionFactory(),new ClickHouseQueryLogger(), new DefaultPropertyBinder());
            clickHouseDatabase.Open();
            var datas=clickHouseDatabase.ExecuteSelectCommand("SELECT * FROM tbl_jc_deviceinfo3 limit 100");
            using (var cnn = GetConnection())
            {
                var reader = cnn.CreateCommand("SELECT * FROM test").ExecuteReader();
            }
        }
        /*增加*/
        public static void Insert()
        {
            using (var cnn = GetConnection())
            {
                var cmd = cnn.CreateCommand("INSERT INTO test (date,x, arr)values ('2017-01-01',1,['a','b','c'])");
                cmd.ExecuteNonQuery();
            }
        }
        /*批量新增*/
        public static void InsertBulk()
        {
            using (var cnn = GetConnection())
            {
                var cmd = cnn.CreateCommand("INSERT INTO test (date,x, values.name,values.value)values @bulk;");
                cmd.Parameters.Add(new ClickHouseParameter
                {
                    DbType = DbType.Object,
                    ParameterName = "bulk",
                    Value = new[]
                    {
                        new object[] {DateTime.Now, 1, new[] {"aaaa@bbb.com", "awdasdas"}, new[] {"dsdsds", "dsfdsds"}},
                        new object[] {DateTime.Now.AddHours(-1), 2, new string[0], new string[0]},
                    }
                });
                cmd.ExecuteNonQuery();
            }
        }

    }
}
