
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
    }
}