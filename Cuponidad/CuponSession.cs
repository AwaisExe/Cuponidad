using Cuponidad.DataAccessLayer.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cuponidad
{
    public class CuponSession
    {
        public static void Login(ISession oSession, User user)
        {
            oSession.SetString("User", JsonConvert.SerializeObject(user));
        }
        public static User GetUser(ISession oSession)
        {
            var user = oSession.GetString("User");
            if (user != null)
            {
                return JsonConvert.DeserializeObject<User>(user);
            }
            else
            {
                return null;
            }
        }
        public static void Stop(ISession oSession)
        {
            oSession.Clear();
        }
        public static Boolean IsUserLogin(ISession oSession)
        {
            if (oSession.GetString("User") != null) return true;
            else return false;
        }
    }
}
