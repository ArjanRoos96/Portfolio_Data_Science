using System;
using System.Data.SqlClient;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Npgsql;
using System.Collections.Generic;

namespace RuleBasedSystem.Models
{
    public class DatabaseConnector
    {
        private string host = "127.0.0.1";
        private string login = "postgres";
        private string password = "geheim";
        private string database = "hhsanalysis";
        private string connString;

        public DatabaseConnector()
        {
            connString = "Host=" + host + ";Username=" + login + ";Password=" + password + ";Database=" + database + ";";
        }

        public List<Room> getAllRooms() {
            List<Room> rooms = new List<Room>();
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand("SELECT id, description FROM octalixnode WHERE description LIKE 'K.%' OR description LIKE '0.%' OR description LIKE '1.%' OR description LIKE '2.%' OR description LIKE '3.%' ORDER BY description;", conn))
                using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                {
                        Room room = new Room();
                        room.setId(reader.GetInt32(0));
                        room.setDescription(reader.GetString(1));
                        rooms.Add(room);
                }
                conn.Close();
            }
            return rooms;
        }

        public List<Room> getRoomsOfLevel(int level){
            List<Room> rooms = new List<Room>();
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                if(level == 0){
                    using (var cmd = new NpgsqlCommand("SELECT id, description FROM octalixnode WHERE description LIKE '0.%' ORDER BY description;", conn))
                    using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        Room room = new Room();
                        room.setId(reader.GetInt32(0));
                        room.setDescription(reader.GetString(1));
                        rooms.Add(room);
                    }
                }
                if(level == 1){
                    using (var cmd = new NpgsqlCommand("SELECT id, description FROM octalixnode WHERE description LIKE '1.%' ORDER BY description;", conn))
                    using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        Room room = new Room();
                        room.setId(reader.GetInt32(0));
                        room.setDescription(reader.GetString(1));
                        rooms.Add(room);
                    }
                }
                if(level == 2){
                    using (var cmd = new NpgsqlCommand("SELECT id, description FROM octalixnode WHERE description LIKE '2.%' ORDER BY description;", conn))
                    using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        Room room = new Room();
                        room.setId(reader.GetInt32(0));
                        room.setDescription(reader.GetString(1));
                        rooms.Add(room);
                    }
                }

                conn.Close();
            }
            return rooms;
        }

        public List<Sensor> getSensorsInRoom(int room){
            List<Sensor> sensors = new List<Sensor>();
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand("SELECT id, owner_id, type, fieldtype_id, description FROM field WHERE owner_id =" + room + "OR owner_id IN(SELECT node_id FROM nodelocation WHERE id IN (SELECT id FROM nodelocation WHERE owner_id=" + room + ")) ORDER BY description", conn))
                using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                {
                    Sensor sensor = new Sensor();
                    sensor.setId(reader.GetInt32(0));
                    sensor.setOwnerId(reader.GetInt32(1));
                    sensor.setType(reader.GetInt32(2));
                    sensor.setFieldTypeId(reader.GetInt32(3));
                    sensor.setDescription(reader.GetString(4));
                    sensors.Add(sensor);
                }
                conn.Close();
            }
            return sensors;
        }

        //Datetime aanpassen vanwege timestamp in DB    
        public List<SensorData> getSensorData(int sensor, DateTime begin, DateTime end){
            List<SensorData> data = new List<SensorData>();

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand("SELECT timestamp, value FROM fieldhistory WHERE field_id=" + sensor + " AND timestamp>=" + begin + " AND timestamp<=" + end + " ORDER BY timestamp", conn))
                using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                {
                    SensorData sensorData = new SensorData();
                    sensorData.setTimestamp((System.DateTime)reader.GetTimeStamp(0));
                    sensorData.setValue(reader.GetString(1));
                    data.Add(sensorData);
                }
                conn.Close();
            }

            return data;
        }

    }
}

