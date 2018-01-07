using System;
using System.Collections.Generic;

namespace RuleBasedSystem.Models
{
    public class Processor
    {
        DatabaseConnector connector;

        public Processor()
        {
            connector = new DatabaseConnector();
        }

        //Standard DB throughput

        public List<Room> getRoomsOfLevel(int id)
        {
            return connector.getRoomsOfLevel(id);
        }

        public List<Room> getAllRooms(){
            return connector.getAllRooms();
        }

        public List<Sensor> getSensorsByRoom(int roomId){
            return connector.getSensorsInRoom(roomId);
        }

        public List<SensorData> getDataByRoom(int sensor, DateTime begin, DateTime end){
            return connector.getSensorData(sensor, begin, end);
        }
    }
}
