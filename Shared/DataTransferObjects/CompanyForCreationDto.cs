using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record CompanyForCreationDto
    {
        [Required(ErrorMessage = "Company name is a required field")]
        [MaxLength(20, ErrorMessage ="Company name length should be less than 20 characters")]
        public string? Name { get; init; }

        [Required(ErrorMessage = "Company address is a required field")]
        public string? Address { get; init; }

        [Required(ErrorMessage = "Company address is a required field")]
        public string? Country { get; init; }

        IEnumerable<EmployeeForCreationDto> Employees;
    }
}
