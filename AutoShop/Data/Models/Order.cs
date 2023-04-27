using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AutoShop.Data.Models;

public class Order
{
    [BindNever]
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter your name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please enter your lastname")]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "Please enter your phone number")]
    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Please enter your address")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Please enter your email")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;

    [BindNever]
    [ScaffoldColumn(false)]
    public DateTime CreatedDate { get; set;}

    public List<OrderDetail> OrderDetails { get; set; }
}