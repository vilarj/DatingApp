using System.ComponentModel.DataAnnotations;

namespace DatingApp.DTOs
{
    public class LoginDTO
    {
        /// <summary>
        ///     Name of the user matching the unique identifer.
        ///     Required.
        /// </summary>
        /// <value>
        ///     string
        /// </value>
        /// <example>
        ///     kingjames
        /// </example>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        ///     Field that stores a plain text password of a <c>User</c>.
        ///     Required.
        /// </summary>
        /// <value>
        ///     string
        /// </value
        [Required]
        public string Password { get; set; }


    }
}