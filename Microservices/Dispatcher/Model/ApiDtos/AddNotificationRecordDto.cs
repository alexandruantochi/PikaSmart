using System;
using System.Net.Mime;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Model.ApiDtos
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class AddNotificationRecordDto
    {
        /// <summary>
        /// Gets or Sets UserId
        /// </summary>
        [DataMember(Name = "userId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "userId")]
        public Guid? UserId { get; set; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name = "text", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "text")]
        public String Text { get; set; }

        /// <summary>
        /// Gets or Sets Time
        /// </summary>
        [DataMember(Name = "Date", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "date")]
        public DateTime? Time { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AddTemperatureRecordDto {\n");
            sb.Append("  UserId: ").Append(UserId).Append("\n");
            sb.Append("  Text: ").Append(Text).Append("\n");
            sb.Append("  Date: ").Append(Time).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

    }
}
