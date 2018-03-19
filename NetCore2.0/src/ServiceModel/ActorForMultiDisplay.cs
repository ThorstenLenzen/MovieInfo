using System;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Toto.MovieInfo.ServiceModel
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class ActorForMultiDisplay :  IEquatable<ActorForMultiDisplay>
    { 
        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Age
        /// </summary>
        [DataMember(Name="age")]
        public int? Age { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ActorForMultiDisplay {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Age: ").Append(Age).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((ActorForMultiDisplay)obj);
        }

        /// <summary>
        /// Returns true if ActorForMultiDisplay instances are equal
        /// </summary>
        /// <param name="other">Instance of ActorForMultiDisplay to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ActorForMultiDisplay other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) && 
                (
                    Age == other.Age ||
                    Age != null &&
                    Age.Equals(other.Age)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                    if (Age != null)
                    hashCode = hashCode * 59 + Age.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ActorForMultiDisplay left, ActorForMultiDisplay right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ActorForMultiDisplay left, ActorForMultiDisplay right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
