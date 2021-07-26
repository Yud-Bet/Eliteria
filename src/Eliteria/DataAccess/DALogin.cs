using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Linq;
using Eliteria.DataAccess.Models;

namespace Eliteria.DataAccess
{
    public static class DALogin
    {
        //public static async task<account> execute(string username, string password)
        //{
        //    datatable data = await executequery.executereaderasync("eliteria_login @username , @password", new object[] { username, password });
        //    if (data.rows.count < 1) return null;
        //    models.account account = new models.account()
        //    {
        //        staffid = (int)data.rows[0][0],
        //        email = data.rows[0][6].tostring(),
        //        password = data.rows[0][2].tostring(),
        //        staffname = data.rows[0][3].tostring(),
        //        phonenum = data.rows[0][5].tostring(),
        //        id = data.rows[0][4].tostring(),
        //        address = data.rows[0][7].tostring(),
        //        sex = (bool)data.rows[0][8],
        //        position = (int)data.rows[0][1],
        //        birthdate = (datetime)data.rows[0][9]
        //    };
        //    ienumerable<account> accounts = await modules.loginmodule.login(username, password);
        //    if (accounts.tolist().count <= 0)
        //        return null;
        //    return accounts.first();
        //}
    }
}
