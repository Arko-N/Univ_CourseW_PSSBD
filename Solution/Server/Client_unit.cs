using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Server
{
    class Client_unit
    {
        private int counter;
        private int max_count;

        public delegate void DecreaseCount();
        public event DecreaseCount onDistruct;

        public TcpClient client;
        NetworkStream stream;

        public Client_unit(TcpClient tcpClient, int counter, int max_count)
        {
            client = tcpClient;
            this.counter = counter;
            this.max_count = max_count;
        }

        public void Process()
        {
            DB_Process db = null;
            stream = client.GetStream();
            try
            {
                while (true)
                {
                    string message = Get();
                    Console.WriteLine($"{(db != null ? db.User_name : "-----")}: {message}");

                    string code = message.Substring(0, 3);
                    string text = message.Substring(5).Trim();
                    switch (code)
                    {
                        case "CON": // сообщение подключения
                        {
                            if (counter > max_count)
                            {
                                message = "SERVER OVERFLOW . DISCONNECTED";
                                Send(message);
                                throw new Exception(message);
                            }

                            try
                            {
                                db = new DB_Process
                                (
                                    text.Substring(0, text.IndexOf('~')),
                                    text.Substring(text.IndexOf('~') + 1)
                                );
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(text.Substring(0, text.IndexOf('~')), ex);
                            }

                            var parent_roles = db.One_List.FromSqlRaw("SELECT * FROM get_parent_roles(current_user)").ToList();
                            StringBuilder builder = new StringBuilder("CONNECTED");
                            foreach (var role in parent_roles) builder.Append($"~{(role != null ? role.Field_1 : "null")}");
                            Send(builder.ToString());
                        }
                        break;

                        #region VIEWs

                        case "C00": // текстовое тестовое сообщение
                        {
                            Send(text.ToUpper());
                        }
                        break;
                        case "C01":
                        {
                            try
                            {
                                var list = db.Two_List.FromSqlRaw("SELECT * FROM c01_2_fields").ToList();
                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list) builder.Append($"\r\n~{item.Field_1}~{item.Field_2}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C02":
                        {
                            try
                            {
                                var list = db.Three_List.FromSqlRaw("SELECT * FROM c02_3_fields").ToList();
                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list) builder.Append($"\r\n~{item.Field_1}~{item.Field_2}~{item.Field_3}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C03":
                        {
                            try
                            {
                                var list = db.Two_List.FromSqlRaw("SELECT * FROM c03_2_fields").ToList();
                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list) builder.Append($"\r\n~{item.Field_1}~{item.Field_2}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C04":
                        {
                            try
                            {
                                var list = db.Three_List.FromSqlRaw("SELECT * FROM c04_3_fields").ToList();
                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list) builder.Append($"\r\n~{item.Field_1}~{item.Field_2}~{item.Field_3}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C05":
                        {
                            try
                            {
                                var list = db.Two_List.FromSqlRaw("SELECT * FROM c05_2_fields").ToList();
                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list) builder.Append($"\r\n~{item.Field_1}~{item.Field_2}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C06":
                        {
                            try
                            {
                                var list = db.Three_List.FromSqlRaw("SELECT * FROM c06_3_fields").ToList();
                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list) builder.Append($"\r\n~{item.Field_1}~{item.Field_2}~{item.Field_3}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C07":
                        {
                            try
                            {
                                var list = db.Three_List.FromSqlRaw("SELECT * FROM c07_3_fields").ToList();
                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list) builder.Append($"\r\n~{item.Field_1}~{item.Field_2}~{item.Field_3}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C08":
                        {
                            try
                            {
                                var list = db.Three_List.FromSqlRaw("SELECT * FROM c08_3_fields").ToList();
                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list) builder.Append($"\r\n~{item.Field_1}~{item.Field_2}~{item.Field_3}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C09":
                        {
                            try
                            {
                                var list = db.One_List.FromSqlRaw("SELECT * FROM c09_1_field").ToList();
                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list) builder.Append($"\r\n~{item.Field_1}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;

                        #endregion VIEWs

                        #region FUNCTIONs

                        case "C10":
                        {
                            try
                            {
                                string[] arguments = text.Split(new[] { "~" }, StringSplitOptions.RemoveEmptyEntries);
                                if (arguments.Length < 1) throw new Exception("not enough arguments");
                                var list = db.Two_List.FromSqlRaw($"SELECT * FROM c10_2_fields('{arguments[0]}')").ToList();

                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list) builder.Append($"\r\n~{item.Field_1}~{item.Field_2}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C11":
                        {
                            try
                            {
                                string[] arguments = text.Split(new[] { "~" }, StringSplitOptions.RemoveEmptyEntries);
                                if (arguments.Length < 1) throw new Exception("not enough arguments");
                                var list = db.Four_List.FromSqlRaw($"SELECT * FROM c11_4_fields('{arguments[0]}')").ToList();

                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list)
                                    builder.Append($"\r\n~{item.Field_1}~{item.Field_2}~{item.Field_3}~{item.Field_4}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C12":
                        {
                            try
                            {
                                string[] arguments = text.Split(new[] { "~" }, StringSplitOptions.RemoveEmptyEntries);
                                if (arguments.Length < 1) throw new Exception("not enough arguments");
                                var list = db.Two_List.FromSqlRaw($"SELECT * FROM c12_2_fields('{arguments[0]}')").ToList();

                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list) builder.Append($"\r\n~{item.Field_1}~{item.Field_2}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C13":
                        {
                            try
                            {
                                string[] arguments = text.Split(new[] { "~" }, StringSplitOptions.RemoveEmptyEntries);
                                if (arguments.Length < 1) throw new Exception("not enough arguments");
                                var list = db.Three_List.FromSqlRaw($"SELECT * FROM c13_3_fields('{arguments[0]}')").ToList();

                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list) builder.Append($"\r\n~{item.Field_1}~{item.Field_2}~{item.Field_3}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C14":
                        {
                            try
                            {
                                string[] arguments = text.Split(new[] { "~" }, StringSplitOptions.RemoveEmptyEntries);
                                if (arguments.Length < 1) throw new Exception("not enough arguments");
                                var list = db.Two_List.FromSqlRaw($"SELECT * FROM c14_2_fields('{arguments[0]}')").ToList();

                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list) builder.Append($"\r\n~{item.Field_1}~{item.Field_2}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C15":
                        {
                            try
                            {
                                string[] arguments = text.Split(new[] { "~" }, StringSplitOptions.RemoveEmptyEntries);
                                if (arguments.Length < 1) throw new Exception("not enough arguments");
                                var list = db.Three_List.FromSqlRaw($"SELECT * FROM c15_3_fields('{arguments[0]}')").ToList();

                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list) builder.Append($"\r\n~{item.Field_1}~{item.Field_2}~{item.Field_3}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C16":
                        {
                            try
                            {
                                string[] arguments = text.Split(new[] { "~" }, StringSplitOptions.RemoveEmptyEntries);
                                if (arguments.Length < 1) throw new Exception("not enough arguments");
                                var list = db.Two_List.FromSqlRaw($"SELECT * FROM c16_2_fields('{arguments[0]}')").ToList();

                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list) builder.Append($"\r\n~{item.Field_1}~{item.Field_2}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C17":
                        {
                            try
                            {
                                string[] arguments = text.Split(new[] { "~" }, StringSplitOptions.RemoveEmptyEntries);
                                if (arguments.Length < 1) throw new Exception("not enough arguments");
                                var list = db.Four_List.FromSqlRaw($"SELECT * FROM c17_4_fields('{arguments[0]}')").ToList();

                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list)
                                    builder.Append($"\r\n~{item.Field_1}~{item.Field_2}~{item.Field_3}~{item.Field_4}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C18":
                        {
                        }
                        break;
                        case "C19":
                        {
                        }
                        break;
                        case "C20":
                        {
                        }
                        break;

                        #endregion FUNCTIONs

                        #region OTHER QUERIes

                        case "C21": // SELECT Clients
                        {
                            try
                            {
                                var list = db.Eight_List.FromSqlRaw($"SELECT * FROM c21_8_fields()").ToList();

                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list)
                                    builder.Append($"\r\n~{item.Field_1}~{item.Field_2}~{item.Field_3}~{item.Field_4}~{item.Field_5}~{item.Field_6}~{item.Field_7}~{item.Field_8}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C31": // INSERT Client
                        {
                            try
                            {
                                string[] arguments = text.Split(new[] { "~" }, StringSplitOptions.RemoveEmptyEntries);
                                if (arguments.Length < 6) throw new Exception("not enough arguments");
                                var list = db.One_List.FromSqlRaw(
                                    $"SELECT * FROM c31_1_field('{arguments[0]}', '{arguments[1]}', '{arguments[2]}', '{arguments[3]}', '{arguments[4]}', '{arguments[5]}')");

                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list) builder.Append($"\r\n~{item.Field_1}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C41": // UPDATE Clients
                        {
                            try
                            {
                                string[] sides = text.Split(new[] { " |:| " }, StringSplitOptions.RemoveEmptyEntries);
                                string[] arguments = sides[0].Split(new[] { "~" }, StringSplitOptions.None);
                                string[] ids = sides[1].Split(new[] { "~" }, StringSplitOptions.RemoveEmptyEntries);

                                StringBuilder query = new StringBuilder("WITH rows AS (UPDATE \"Clients\" SET");
                                if (arguments[1].Length > 0) query.Append($", surname='{arguments[1]}'");
                                if (arguments[2].Length > 0) query.Append($", name='{arguments[2]}'");
                                if (arguments[3].Length > 0) query.Append($", fathername='{arguments[3]}'");
                                if (arguments[4].Length > 0) query.Append($", birthday='{arguments[4]}'");
                                if (arguments[5].Length > 0) query.Append($", \"group\"=(SELECT id FROM \"Groups\" WHERE name='{arguments[5]}')");
                                if (arguments[6].Length > 0) query.Append($", address='{arguments[6]}'");
                                query.Replace("SET,", "SET");
                                query.Append(" WHERE id IN (");
                                foreach (string id in ids) query.Append($", {id}");
                                query.Replace("(,", "(");
                                query.Append(") RETURNING 1) SELECT count(*)::text AS field_1 FROM rows;");

                                var list = db.One_List.FromSqlRaw(query.ToString()).ToList();

                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list)
                                    builder.Append($"\r\n~{item.Field_1}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C51": // DELETE Clients
                        {
                            try
                            {
                                string[] ids = text.Split(new[] { "~" }, StringSplitOptions.RemoveEmptyEntries);

                                StringBuilder query = new StringBuilder("WITH rows AS (DELETE FROM \"Clients\" WHERE id IN (");
                                foreach (string id in ids) query.Append($", {id}");
                                query.Replace("(,", "(");
                                query.Append(") RETURNING 1) SELECT count(*)::text AS field_1 FROM rows;");

                                var list = db.One_List.FromSqlRaw(query.ToString()).ToList();

                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list)
                                    builder.Append($"\r\n~{item.Field_1}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C71": // SELECT Clients [alter]
                        {
                            try
                            {
                                var list = db.Two_List.FromSqlRaw($"SELECT * FROM C71_2_fields()").ToList();

                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list)
                                {
                                    builder.Append($"\r\n~{item.Field_1}~{item.Field_2}");
                                }
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;

                        case "C22": // SELECT Barbers
                        {
                            try
                            {
                                var list = db.Seven_List.FromSqlRaw($"SELECT * FROM c22_7_fields()").ToList();

                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list)
                                    builder.Append($"\r\n~{item.Field_1}~{item.Field_2}~{item.Field_3}~{item.Field_4}~{item.Field_5}~{item.Field_6}~{item.Field_7}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C32": // INSERT Barbers
                        {
                            try
                            {
                                string[] arguments = text.Split(new[] { "~" }, StringSplitOptions.RemoveEmptyEntries);
                                if (arguments.Length < 5) throw new Exception("not enough arguments");
                                var list = db.One_List.FromSqlRaw(
                                    $"SELECT * FROM c32_1_field('{arguments[0]}', '{arguments[1]}', '{arguments[2]}', '{arguments[3]}', '{arguments[4]}')");

                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list) builder.Append($"\r\n~{item.Field_1}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C42": // UPDATE Barbers
                        {
                            try
                            {
                                string[] sides = text.Split(new[] { " |:| " }, StringSplitOptions.RemoveEmptyEntries);
                                string[] arguments = sides[0].Split(new[] { "~" }, StringSplitOptions.None);
                                string[] ids = sides[1].Split(new[] { "~" }, StringSplitOptions.RemoveEmptyEntries);

                                StringBuilder query = new StringBuilder("WITH rows AS (UPDATE \"Barbershops\" SET");
                                if (arguments[1].Length > 0) query.Append($", district=(SELECT id FROM \"Districts\" WHERE name='{arguments[1]}')");
                                if (arguments[2].Length > 0) query.Append($", rank=(SELECT id FROM \"Ranks\" WHERE name='{arguments[2]}')");
                                if (arguments[3].Length > 0) query.Append($", ownership=(SELECT id FROM \"Ownerships\" WHERE name='{arguments[3]}')");
                                if (arguments[4].Length > 0) query.Append($", \"starting date\"='{arguments[4]}'::date");
                                if (arguments[5].Length > 0) query.Append($", phone='{arguments[5]}')");
                                query.Replace("SET,", "SET");
                                query.Append(" WHERE id IN (");
                                foreach (string id in ids) query.Append($", {id}");
                                query.Replace("(,", "(");
                                query.Append(") RETURNING 1) SELECT count(*)::text AS field_1 FROM rows;");

                                var list = db.One_List.FromSqlRaw(query.ToString()).ToList();

                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list)
                                    builder.Append($"\r\n~{item.Field_1}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C52": // DELETE Barbers
                        {
                            try
                            {
                                string[] ids = text.Split(new[] { "~" }, StringSplitOptions.RemoveEmptyEntries);

                                StringBuilder query = new StringBuilder("WITH rows AS (DELETE FROM \"Barbershops\" WHERE id IN (");
                                foreach (string id in ids) query.Append($", {id}");
                                query.Replace("(,", "(");
                                query.Append(") RETURNING 1) SELECT count(*)::text AS field_1 FROM rows;");

                                var list = db.One_List.FromSqlRaw(query.ToString()).ToList();

                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list)
                                    builder.Append($"\r\n~{item.Field_1}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C72": // SELECT Barbers [alter]
                        {
                            try
                            {
                                var list = db.Two_List.FromSqlRaw($"SELECT * FROM C72_2_fields()").ToList();

                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list)
                                {
                                    builder.Append($"\r\n~{item.Field_1}~{item.Field_2}");
                                }
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;

                        case "C23": // SELECT Journal
                        {
                            try
                            {
                                var list = db.Seven_List.FromSqlRaw($"SELECT * FROM c23_7_fields()").ToList();

                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list)
                                    builder.Append($"\r\n~{item.Field_1}~{item.Field_2}~{item.Field_3}~{item.Field_4}~{item.Field_5}~{item.Field_6}~{item.Field_7}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C33": // INSERT Journal
                        {
                            try
                            {
                                string[] arguments = text.Split(new[] { "~" }, StringSplitOptions.RemoveEmptyEntries);
                                if (arguments.Length < 3) throw new Exception("not enough arguments");

                                string arg_0 = arguments[0].Substring(0, arguments[0].IndexOf(" [|] "));
                                string arg_1 = arguments[1].Substring(0, arguments[1].IndexOf(" [|] "));
                                var list = db.One_List.FromSqlRaw(
                                    $"SELECT * FROM c33_1_field('{arg_0}', '{arg_1}', '{arguments[2]}')");

                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list) builder.Append($"\r\n~{item.Field_1}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C43": // UPDATE Journal
                        {
                            try
                            {
                                string[] sides = text.Split(new[] { " |:| " }, StringSplitOptions.RemoveEmptyEntries);
                                string[] arguments = sides[0].Split(new[] { "~" }, StringSplitOptions.None);
                                string[] ids = sides[1].Split(new[] { "~" }, StringSplitOptions.RemoveEmptyEntries);

                                StringBuilder query = new StringBuilder("WITH rows AS (UPDATE journal SET");
                                if (arguments[1].Length > 0)
                                {
                                    string arg = arguments[1].Substring(0, arguments[1].IndexOf(" [|] "));
                                    query.Append($", id_client=(SELECT id FROM \"Clients\" WHERE name='{arg}')");
                                }
                                if (arguments[2].Length > 0)
                                {
                                    string arg = arguments[2].Substring(0, arguments[2].IndexOf(" [|] "));
                                    query.Append($", id_barbershop=(SELECT id FROM \"Barbershops\" WHERE name='{arg}')");
                                }
                                if (arguments[3].Length > 0) query.Append($", id_service=(SELECT id FROM \"Services\" WHERE name='{arguments[3]}')");
                                if (arguments[4].Length > 0) query.Append($", date='{arguments[4]}'");
                                query.Replace("SET,", "SET");
                                query.Append(" WHERE id IN (");
                                foreach (string id in ids) query.Append($", {id}");
                                query.Replace("(,", "(");
                                query.Append(") RETURNING 1) SELECT count(*)::text AS field_1 FROM rows;");

                                var list = db.One_List.FromSqlRaw(query.ToString()).ToList();

                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list)
                                    builder.Append($"\r\n~{item.Field_1}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C53": // DELETE Journal
                        {
                            try
                            {
                                string[] ids = text.Split(new[] { "~" }, StringSplitOptions.RemoveEmptyEntries);

                                StringBuilder query = new StringBuilder("WITH rows AS (DELETE FROM journal WHERE id IN (");
                                foreach (string id in ids) query.Append($", {id}");
                                query.Replace("(,", "(");
                                query.Append(") RETURNING 1) SELECT count(*)::text AS field_1 FROM rows;");

                                var list = db.One_List.FromSqlRaw(query.ToString()).ToList();

                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list)
                                    builder.Append($"\r\n~{item.Field_1}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;

                        case "C24": // SELECT Groups
                        {
                            try
                            {
                                var list = db.Two_List.FromSqlRaw($"SELECT * FROM C24_2_fields()").ToList();

                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list)
                                {
                                    if (item.Field_1 != "0") builder.Append($"\r\n~{item.Field_1}~{item.Field_2}");
                                }
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C34": // INSERT Groups
                        {
                            try
                            {
                                string[] arguments = text.Split(new[] { "~" }, StringSplitOptions.RemoveEmptyEntries);
                                if (arguments.Length < 1) throw new Exception("not enough arguments");
                                var list = db.One_List.FromSqlRaw(
                                    $"SELECT * FROM c34_1_field('{arguments[0]}')");

                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list) builder.Append($"\r\n~{item.Field_1}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C54": // DELETE Groups
                        {
                            try
                            {
                                string[] ids = text.Split(new[] { "~" }, StringSplitOptions.RemoveEmptyEntries);

                                StringBuilder query = new StringBuilder("WITH rows AS (DELETE FROM \"Groups\" WHERE id IN (");
                                foreach (string id in ids) query.Append($", {id}");
                                query.Replace("(,", "(");
                                query.Append(") RETURNING 1) SELECT count(*)::text AS field_1 FROM rows;");

                                var list = db.One_List.FromSqlRaw(query.ToString()).ToList();

                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list)
                                    builder.Append($"\r\n~{item.Field_1}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;

                        case "C25": // SELECT Districts
                        {
                            try
                            {
                                var list = db.Two_List.FromSqlRaw($"SELECT * FROM C25_2_fields()").ToList();

                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list)
                                {
                                    builder.Append($"\r\n~{item.Field_1}~{item.Field_2}");
                                }
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;

                        case "C26": // SELECT Ranks
                        {
                            try
                            {
                                var list = db.Two_List.FromSqlRaw($"SELECT * FROM C26_2_fields()").ToList();

                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list)
                                {
                                    builder.Append($"\r\n~{item.Field_1}~{item.Field_2}");
                                }
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;

                        case "C27": // SELECT Ownerships
                        {
                            try
                            {
                                var list = db.Two_List.FromSqlRaw($"SELECT * FROM C27_2_fields()").ToList();

                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list)
                                {
                                    builder.Append($"\r\n~{item.Field_1}~{item.Field_2}");
                                }
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;

                        case "C28": // SELECT Services
                        {
                            try
                            {
                                var list = db.Two_List.FromSqlRaw($"SELECT * FROM C28_2_fields()").ToList();

                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list)
                                {
                                    builder.Append($"\r\n~{item.Field_1}~{item.Field_2}");
                                }
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;

                        case "C61": // SELECT Workers
                        {
                            try
                            {
                                var list = db.One_List.FromSqlRaw($"SELECT * FROM c61_1_fields()").ToList();

                                StringBuilder builder = new StringBuilder();
                                foreach (var item in list)
                                    builder.Append($"\r\n~{item.Field_1}");
                                message = builder.ToString();
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C62": // ADD Worker
                        {
                            try
                            {
                                string[] arguments = text.Split(new[] { "~" }, StringSplitOptions.RemoveEmptyEntries);
                                if (arguments.Length < 2) throw new Exception("not enough arguments");
                                db.Database.ExecuteSqlRaw(
$@"CREATE ROLE {arguments[0]} WITH LOGIN NOSUPERUSER NOCREATEDB NOCREATEROLE INHERIT NOREPLICATION
CONNECTION LIMIT 1 PASSWORD '{arguments[1]}';
GRANT worker_gp TO {arguments[0]};
CREATE TABLE journal_{arguments[0]} PARTITION OF journal FOR VALUES IN ('{arguments[0]}')");

                                message = "SUCCESS";
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C63": // UPDATE Worker
                        {
                            try
                            {
                                string[] sides     = text.Split(new[] { " |:| " }, StringSplitOptions.RemoveEmptyEntries);
                                string[] arguments = sides[0].Split(new[] { "~" }, StringSplitOptions.None);
                                string   login = sides[1].Substring(1);

                                StringBuilder query = new StringBuilder();
                                if (arguments[1].Length > 0) query.Append($"ALTER ROLE {login} RENAME TO {arguments[1]}; ALTER TABLE IF EXISTS journal_{login} RENAME TO journal_{arguments[1]};");
                                if (arguments[2].Length > 0) query.Append($"ALTER ROLE {login} PASSWORD '{arguments[2]}';");

                                db.Database.ExecuteSqlRaw(query.ToString());
                                message = "SUCCESS";
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;
                        case "C64": // DELETE Worker
                        {
                            try
                            {
                                text = text.Substring(1);
                                string query =
$@"DROP ROLE {text};
UPDATE journal SET user_name = user_name || ' [del]' WHERE user_name = '{text}';
DROP TABLE IF EXISTS journal_{text};";
                                var list = db.Database.ExecuteSqlRaw(query.ToString());
                                message = "SUCCESS";
                            }
                            catch (Exception ex)
                            {
                                message = $"{ex.Message} . EXCEPTION";
                                Console.WriteLine($"{db.User_name}: {message}");
                            }
                            Send(message);
                        }
                        break;

                        #endregion OTHER QUERIes

                        case "DIS": // сообщение отключения
                        {
                            throw new Exception("CLOSED");
                        }
                        default:
                        {
                            message = $"unknown command . EXCEPTION";
                            Console.WriteLine($"{db.User_name}: {message}");
                            Send(message);
                        }
                        break;
                    }
                }
            }
            catch (System.IO.IOException ex) when (ex.Message.Contains("требуемое время"))
            {
                string message = "OVERTIME . DISCONNECTED";
                Send(message);
            }
            catch (Exception ex)
            {
                string message = $"{ex.Message} . DISCONNECTED";

                if (ex.Message.Contains("CLOSED"))
                {
                    Console.WriteLine($"{db.User_name}: {message}");
                }
                else
                {
                    if (ex.InnerException != null)
                    {
                        message = $"DataBase . {ex.InnerException.Message} . DISCONNECTED";
                        Console.WriteLine($"{ex.Message}: {message}");
                    }
                    else Console.WriteLine($"{db.User_name}: {message}");

                    Send(message);
                }
            }
            finally
            {
                onDistruct();

                if (stream != null)
                { stream.Close(); }

                if (client != null)
                { client.Close(); }

                if (db != null)
                { db.Dispose(); db = null; }
            }
        }

        private string Get()
        {
            StringBuilder builder = new StringBuilder(); // получаем сообщение
            byte[] data = new byte[64];                  // буфер для данных
            int bytes = 0;
            do
            {
                bytes = stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (stream.DataAvailable);

            builder.Replace("'", "`");
            return builder.ToString();
        }

        private void Send(string message)
        {
            if (message.Length == 0) message = "nothing";
            byte[] data = Encoding.Unicode.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }
    }

    public class DB_Process : DbContext
    {
        public class ToOne
        {
            public string Field_1 { get; set; }
        }
        public class ToTwo
        {
            public string Field_1 { get; set; }
            public string Field_2 { get; set; }
        }
        public class ToThree
        {
            public string Field_1 { get; set; }
            public string Field_2 { get; set; }
            public string Field_3 { get; set; }
        }
        public class ToFour
        {
            public string Field_1 { get; set; }
            public string Field_2 { get; set; }
            public string Field_3 { get; set; }
            public string Field_4 { get; set; }
        }
        public class ToFive
        {
            public string Field_1 { get; set; }
            public string Field_2 { get; set; }
            public string Field_3 { get; set; }
            public string Field_4 { get; set; }
            public string Field_5 { get; set; }
        }
        public class ToSix
        {
            public string Field_1 { get; set; }
            public string Field_2 { get; set; }
            public string Field_3 { get; set; }
            public string Field_4 { get; set; }
            public string Field_5 { get; set; }
            public string Field_6 { get; set; }
        }
        public class ToSeven
        {
            public string Field_1 { get; set; }
            public string Field_2 { get; set; }
            public string Field_3 { get; set; }
            public string Field_4 { get; set; }
            public string Field_5 { get; set; }
            public string Field_6 { get; set; }
            public string Field_7 { get; set; }
        }
        public class ToEight
        {
            public string Field_1 { get; set; }
            public string Field_2 { get; set; }
            public string Field_3 { get; set; }
            public string Field_4 { get; set; }
            public string Field_5 { get; set; }
            public string Field_6 { get; set; }
            public string Field_7 { get; set; }
            public string Field_8 { get; set; }
        }

        public string User_name { get; set; }
        public string Password { get; set; }

        public DbSet<ToOne>   One_List   { get; set; }
        public DbSet<ToTwo>   Two_List   { get; set; }
        public DbSet<ToThree> Three_List { get; set; }
        public DbSet<ToFour>  Four_List  { get; set; }
        public DbSet<ToFive>  Five_List  { get; set; }
        public DbSet<ToSix>   Six_List   { get; set; }
        public DbSet<ToSeven> Seven_List { get; set; }
        public DbSet<ToEight> Eight_List { get; set; }

        public DB_Process(string name, string password)
        {
            User_name = name;
            Password = password;
            Database.CanConnect();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($"Host=localhost;Port=5432;Database=PSSSBD;Pooling=false;Username={User_name};Password={Password}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToOne>  (eb => { eb.HasNoKey(); });
            modelBuilder.Entity<ToTwo>  (eb => { eb.HasNoKey(); });
            modelBuilder.Entity<ToThree>(eb => { eb.HasNoKey(); });
            modelBuilder.Entity<ToFour> (eb => { eb.HasNoKey(); });
            modelBuilder.Entity<ToFive> (eb => { eb.HasNoKey(); });
            modelBuilder.Entity<ToSix>  (eb => { eb.HasNoKey(); });
            modelBuilder.Entity<ToSeven>(eb => { eb.HasNoKey(); });
            modelBuilder.Entity<ToEight>(eb => { eb.HasNoKey(); });
        }
    }
}
