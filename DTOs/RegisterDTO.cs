namespace DatingApp.DTOs
{
    public class RegisterDTO
    {
        /// <summary>
        ///     Name of the user matching the unique identifer.
        /// </summary>
        /// <value>
        ///     string
        /// </value>
        /// <example>
        ///     kingjames
        /// </example>
        public string UserName { get; set; }

        /// <summary>
        ///     Field that stores a plain text password of a <c>User</c>
        /// </summary>
        /// <value>
        ///     string
        /// </value
        public string Password { get; set; }
    }
}