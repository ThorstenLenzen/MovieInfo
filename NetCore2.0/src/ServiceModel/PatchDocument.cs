using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Toto.MovieInfo.ServiceModel
{ 
    /// <summary>
    /// A JSONPatch document as defined by RFC 6902
    /// </summary>
    [DataContract]
    public class PatchDocument :  IEquatable<PatchDocument>
    {         /// <summary>
        /// The operation to be performed
        /// </summary>
        /// <value>The operation to be performed</value>
        public enum OpEnum
        { 
            /// <summary>
            /// Enum AddEnum for "add"
            /// </summary>
            [EnumMember(Value = "add")]
            AddEnum = 1,
            
            /// <summary>
            /// Enum RemoveEnum for "remove"
            /// </summary>
            [EnumMember(Value = "remove")]
            RemoveEnum = 2,
            
            /// <summary>
            /// Enum ReplaceEnum for "replace"
            /// </summary>
            [EnumMember(Value = "replace")]
            ReplaceEnum = 3,
            
            /// <summary>
            /// Enum MoveEnum for "move"
            /// </summary>
            [EnumMember(Value = "move")]
            MoveEnum = 4,
            
            /// <summary>
            /// Enum CopyEnum for "copy"
            /// </summary>
            [EnumMember(Value = "copy")]
            CopyEnum = 5,
            
            /// <summary>
            /// Enum TestEnum for "test"
            /// </summary>
            [EnumMember(Value = "test")]
            TestEnum = 6
        }

        /// <summary>
        /// The operation to be performed
        /// </summary>
        /// <value>The operation to be performed</value>
        [Required]
        [DataMember(Name="op")]
        public OpEnum? Op { get; set; }

        /// <summary>
        /// A JSON-Pointer
        /// </summary>
        /// <value>A JSON-Pointer</value>
        [Required]
        [DataMember(Name="path")]
        public string Path { get; set; }

        /// <summary>
        /// The value to be used within the operations.
        /// </summary>
        /// <value>The value to be used within the operations.</value>
        [DataMember(Name="value")]
        public Object Value { get; set; }

        /// <summary>
        /// A string containing a JSON Pointer value.
        /// </summary>
        /// <value>A string containing a JSON Pointer value.</value>
        [DataMember(Name="from")]
        public string From { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PatchDocument {\n");
            sb.Append("  Op: ").Append(Op).Append("\n");
            sb.Append("  Path: ").Append(Path).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  From: ").Append(From).Append("\n");
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
            return obj.GetType() == GetType() && Equals((PatchDocument)obj);
        }

        /// <summary>
        /// Returns true if PatchDocument instances are equal
        /// </summary>
        /// <param name="other">Instance of PatchDocument to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PatchDocument other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Op == other.Op ||
                    Op != null &&
                    Op.Equals(other.Op)
                ) && 
                (
                    Path == other.Path ||
                    Path != null &&
                    Path.Equals(other.Path)
                ) && 
                (
                    Value == other.Value ||
                    Value != null &&
                    Value.Equals(other.Value)
                ) && 
                (
                    From == other.From ||
                    From != null &&
                    From.Equals(other.From)
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
                    if (Op != null)
                    hashCode = hashCode * 59 + Op.GetHashCode();
                    if (Path != null)
                    hashCode = hashCode * 59 + Path.GetHashCode();
                    if (Value != null)
                    hashCode = hashCode * 59 + Value.GetHashCode();
                    if (From != null)
                    hashCode = hashCode * 59 + From.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(PatchDocument left, PatchDocument right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PatchDocument left, PatchDocument right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
