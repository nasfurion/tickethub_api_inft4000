using System.ComponentModel.DataAnnotations;

namespace TicketHub_API
{
    public class Purchase
    {
        [Required]
        public int concertId { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid Email address")]
        public string email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "The name inserted exceeds the maximum character length")]
        public string name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone is required")]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        public string phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Quantity is required")]
        [RegularExpression(@"^(0|[1-9][0-9]*)$", ErrorMessage = "Please enter a numeric value")]
        [Range(1, 6, ErrorMessage = "The allowed ticket quantity is between 1 and 6")]
        public int quantity { get; set; }

        [Required(ErrorMessage = "Credit card number is required")]
        [CreditCard(ErrorMessage = "Please enter a valid credit card number")]
        public string creditCard { get; set; } = string.Empty;

        [Required(ErrorMessage = "Expiration date is required")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$", ErrorMessage = "Please enter a valid expiration date")]
        public string expiration { get; set; } = string.Empty;

        [Required(ErrorMessage = "Security code is required")]
        [RegularExpression(@"^\d+$", ErrorMessage = "The security code must be numbers only")]
        [StringLength(4, MinimumLength = 3, ErrorMessage = "Please enter a valid security code")]
        public string securityCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required")]
        public string address { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required")]
        public string city { get; set; } = string.Empty;

        [Required(ErrorMessage = "Province is required")]
        public string province { get; set; } = string.Empty;

        [Required(ErrorMessage = "Postal code is required")]
        //https://stackoverflow.com/questions/15774555/efficient-regex-for-canadian-postal-code-function
        [RegularExpression(@"^[ABCEGHJKLMNPRSTVXYabceghjklmnprstvxy][0-9][ABCEGHJKLMNPRSTVWXYZabceghjklmnprstvwxyz] [0-9][ABCEGHJKLMNPRSTVWXYZabceghjklmnprstvwxyz][0-9]$", ErrorMessage = "Please enter a valid postal code")]
        public string postalCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country is required")]
        public string country { get; set; } = string.Empty;
    }
}
