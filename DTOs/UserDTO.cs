using System.ComponentModel.DataAnnotations;

namespace DatingApp.DTOs
{
    public class UserDTO
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
        ///     JWT token used for valid access to the website.
        ///     Required.
        /// </summary>
        /// <example>
        ///     2323dfdfdjh12e43jhrj
        /// </example>
        [Required]
        public string Token { get; set; }

    }
}