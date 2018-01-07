using System;
using Newtonsoft.Json;

namespace RuleBasedSystem.Models
{
    public class SensorData
    {
        [JsonProperty]
        private DateTime timestamp;
        [JsonProperty]
        private string value;

        public SensorData()
        {
        }

        public void setTimestamp(DateTime time)
        {
            timestamp = time;
        }

        public void setValue(string value)
        {
            this.value = value;
        }

        public DateTime getTimestamp()
        {
            return timestamp;
        }

        public string getValue()
        {
            return value;
        }
    }
}
