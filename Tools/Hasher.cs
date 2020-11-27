using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fri2Ends.Identity.DomainClass;

namespace Fri2Ends.Identity.Tools
{

    /// <summary>
    /// You Can Create Hash String by this Class
    /// </summary>
    public static class Hasher
    {
        /// <summary>
        /// Return a Hash String That Create With Current User Information
        /// </summary>
        /// <param name="user">Current User</param>
        /// <param name="password">Current Password</param>
        /// <returns></returns>
        public static async Task<string> GetHashAsync(Users user, string password)
        {
            var parameter = user.PhoneNumber + user.UserName + user.Password + user.PhoneNumber + user.Email + user.ActiveCode;
            return await Task.Run(() =>
            {
                var hashParam = "";
                for (int i = 0; i < parameter.Length; i++)
                {
                    hashParam += parameter[i];
                    for (int j = 0; j < password.Length; j++)
                    {
                        hashParam += password[i].ToString().ToUpper();
                    }
                    hashParam += parameter[i].ToString().ToUpper();
                }

                for (int i = 0; i < hashParam.Length; i++)
                {
                    hashParam += hashParam[i].ToString().ToUpper();
                }
                return hashParam;
            });
        }


        /// <summary>
        /// Return a Hash String That Create With Current User Information
        /// </summary>
        /// <param name="user">Current User</param>
        /// <param name="password">Current Password</param>
        /// <returns></returns>
        public static string GetHash(Users user, string password)
        {
            var parameter = user.PhoneNumber + user.UserName + user.Password + user.PhoneNumber + user.Email + user.ActiveCode;

            var hashParam = "";
            for (int i = 0; i < parameter.Length; i++)
            {
                hashParam += parameter[i];
                for (int j = 0; j < password.Length; j++)
                {
                    hashParam += password[i].ToString().ToUpper();
                }
                hashParam += parameter[i].ToString().ToUpper();
            }

            for (int i = 0; i < hashParam.Length; i++)
            {
                hashParam += hashParam[i].ToString().ToUpper();
            }
            return hashParam;

        }

    }
}
