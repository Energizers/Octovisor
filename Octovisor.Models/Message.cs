﻿using Newtonsoft.Json;
using System;

namespace Octovisor.Models
{
    public enum MessageStatus
    {
        DataRequest           = 0,
        DataResponse          = 1,
        ServerError           = 2,
        TargetError           = 3,
        NetworkError          = 4,
        MalformedMessageError = 5,
        ProcessNotFound       = 6,
    }

    public class Message
    {
        [JsonProperty(PropertyName = "id")]
        public ulong ID { get; set; }

        [JsonProperty(PropertyName = "origin")]
        public string OriginName { get; set; }

        [JsonProperty(PropertyName = "target")]
        public string TargetName { get; set; }

        [JsonProperty(PropertyName = "identifier")]
        public string Identifier { get; set; }

        [JsonProperty(PropertyName = "data")]
        public string Data { get; set; }

        [JsonProperty(PropertyName = "status")]
        public MessageStatus Status { get; set; }

        [JsonIgnore]
        public int Length { get => this.Data != null ? this.Data.Length : 0; }

        public static Message Deserialize(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<Message>(json);
            }
            catch (Exception)
            {
                return new Message
                {
                    ID = 0,
                    OriginName = "UNKNOWN_ORIGIN",
                    TargetName = "UNKNOWN_TARGET",
                    Identifier = "UNKNOWN",
                    Data = json,
                    Status = MessageStatus.MalformedMessageError,
                };
            }
        }

        public string Serialize()
            => JsonConvert.SerializeObject(this);
    }
}
