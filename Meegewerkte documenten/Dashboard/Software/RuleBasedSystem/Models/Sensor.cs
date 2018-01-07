using System;
using Newtonsoft.Json;

namespace RuleBasedSystem.Models
{
    public class Sensor
    {
        [JsonProperty]
        private int id;
        [JsonProperty]
        private string description;
        [JsonProperty]
        private int type;
        [JsonProperty]
        private int fieldtypeId;
        [JsonProperty]
        private int ownerId;

        public Sensor()
        {
        }

        public void setId(int id){
            this.id = id;
        }

        public void setDescription(string description){
            this.description = description;
        }

        public void setType(int type){
            this.type = type;
        }

        public void setFieldTypeId(int id){
            this.fieldtypeId = id;
        }

        public void setOwnerId(int id){
            this.ownerId = id;
        }

        public int getId(){
            return id;
        }

        public string getDescription(){
            return description;
        }

        public int getType(){
            return type;
        }

        public int getFiledTypeId(){
            return fieldtypeId;
        }

        public int getOwnerId(){
            return ownerId;
        }
    }
}
