
namespace DatingApp.Entities
{
    /// <summary>
    ///     <c>User</c> class containing two properties of a user:
    ///     1. The unique identifier of a user.
    ///     2. Username for accessing the data in the frontend.
    /// </summary>
    public class User
    {
        /// <summary>
        ///     Unique identifier of a user.
        /// </summary>
        /// <value>
        ///     int
        /// </value
        /// <example>
        ///     1
        /// </example>
        public int Id { get; set;}

        /// <summary>
        ///     Name of the user matching the unique identifer.
        /// </summary>
        /// <value>
        ///     string
        /// </value>
        /// <example>
        ///     kingjames
        /// </example>
        public string UserName { get; set;}

        /// <summary>
        ///     User password that is hashed for security reasons
        /// </summary>
        /// <value>
        ///     byte[]
        /// </value
        public byte[] PasswordHash { get; set; }
        
        /// <summary>
        ///     User password hashed - the password salt method is applied for
        ///     security reasons.
        /// </summary>
        /// <value>
        ///     byte[]
        /// </value>
        public byte[] PasswordSalt {get; set; }
    }
}