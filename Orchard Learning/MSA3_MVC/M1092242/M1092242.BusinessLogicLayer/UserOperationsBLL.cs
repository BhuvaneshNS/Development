using M1092242.DataAccessLayer;
using M1092242.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1092242.BusinessLogicLayer
{
    public class UserOperationsBLL
    {
        public static int RegisterUserBLL(User user)
        {
            try
            {
                return UserOperationDAL.RegisterUserDAL(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<ServiceCenter> GetAllServiceCenters()
        {

            try
            {
                return UserOperationDAL.GetAllServiceCenters();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
