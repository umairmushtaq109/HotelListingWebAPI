using HotelListing.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.DataAccess.AuthService
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginUserDTO loginUserDTO);
        Task<string> GenerateToken();
    }
}
