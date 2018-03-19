using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Toto.MovieInfo.ServiceModel
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class PatchRequest : List<PatchDocument>,  IEquatable<PatchRequest>
    { 
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PatchRequest {\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public  new string ToJson()
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
            return obj.GetType() == GetType() && Equals((PatchRequest)obj);
        }

        /// <summary>
        /// Returns true if PatchRequest instances are equal
        /// </summary>
        /// <param name="other">Instance of PatchRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PatchRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return false;
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
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(PatchRequest left, PatchRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PatchRequest left, PatchRequest right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
