using System;
using Newtonsoft.Json;

namespace RuleBasedSystem.Models
{
    public class Room
    {
        [JsonProperty]
        private int id;
        [JsonProperty]
        private string description;

        public Room()
        {
        }

        public int getId(){
            return id;
        }

        public string getDescription(){
            return description;
        }

        public void setId(int newId){
            id = newId;
        }

        public void setDescription(string newDescription) {
            description = newDescription;
        }
    }
}
