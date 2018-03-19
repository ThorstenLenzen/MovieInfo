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
    public class ActorForCreate :  IEquatable<ActorForCreate>
    { 
        /// <summary>
        /// Gets or Sets FirstName
        /// </summary>
        [DataMember(Name="firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or Sets MiddleName
        /// </summary>
        [DataMember(Name="middleName")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or Sets LastName
        /// </summary>
        [DataMember(Name="lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or Sets Bio
        /// </summary>
        [DataMember(Name="bio")]
        public string Bio { get; set; }

        /// <summary>
        /// Gets or Sets BirthDate
        /// </summary>
        [DataMember(Name="birthDate")]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ActorForCreate {\n");
            sb.Append("  FirstName: ").Append(FirstName).Append("\n");
            sb.Append("  MiddleName: ").Append(MiddleName).Append("\n");
            sb.Append("  LastName: ").Append(LastName).Append("\n");
            sb.Append("  Bio: ").Append(Bio).Append("\n");
            sb.Append("  BirthDate: ").Append(BirthDate).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ActorForCreate)obj);
        }

        /// <summary>
        /// Returns true if ActorForCreate instances are equal
        /// </summary>
        /// <param name="other">Instance of ActorForCreate to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ActorForCreate other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    FirstName == other.FirstName ||
                    FirstName != null &&
                    FirstName.Equals(other.FirstName)
                ) && 
                (
                    MiddleName == other.MiddleName ||
                    MiddleName != null &&
                    MiddleName.Equals(other.MiddleName)
                ) && 
                (
                    LastName == other.LastName ||
                    LastName != null &&
                    LastName.Equals(other.LastName)
                ) && 
                (
                    Bio == other.Bio ||
                    Bio != null &&
                    Bio.Equals(other.Bio)
                ) && 
                (
                    BirthDate == other.BirthDate ||
                    BirthDate != null &&
                    BirthDate.Equals(other.BirthDate)
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
                    if (FirstName != null)
                    hashCode = hashCode * 59 + FirstName.GetHashCode();
                    if (MiddleName != null)
                    hashCode = hashCode * 59 + MiddleName.GetHashCode();
                    if (LastName != null)
                    hashCode = hashCode * 59 + LastName.GetHashCode();
                    if (Bio != null)
                    hashCode = hashCode * 59 + Bio.GetHashCode();
                    if (BirthDate != null)
                    hashCode = hashCode * 59 + BirthDate.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ActorForCreate left, ActorForCreate right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ActorForCreate left, ActorForCreate right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
