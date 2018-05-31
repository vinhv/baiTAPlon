using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data;
namespace BLL
{
    public class QuanLyCBGVBUL
    {
        QuanLyCBGVDAL cls = new QuanLyCBGVDAL();
        public DataTable HienThiDS()
        {
            return cls.HienThiDS();
        }
    }
}
