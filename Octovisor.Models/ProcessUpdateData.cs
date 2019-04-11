﻿using Newtonsoft.Json;

namespace Octovisor.Messages
{
    public class ProcessUpdateData
    {
        [JsonProperty(PropertyName = "accepted")]
        public bool Accepted { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        public ProcessUpdateData(bool accepted, string name)
        {
            this.Accepted = accepted;
            this.Name = name;
        }

        public static ProcessUpdateData Deserialize(string json)
            => JsonConvert.DeserializeObject<ProcessUpdateData>(json);

        public string Serialize()
            => JsonConvert.SerializeObject(this);
    }
}
