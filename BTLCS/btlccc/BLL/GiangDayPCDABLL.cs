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
   public class GiangDayPCDABLL
    {
        PCGDDADAL pcgd = new PCGDDADAL();
        public DataTable HienThiDS()
        {
            return pcgd.HienThiDS();
        }
        public DataTable getMamon()
        {
            return pcgd.getMamon();
        }
        public DataTable getMalop()
        {
            return pcgd.getMalop();
        }
        public DataTable getGiaovien()
        {
            return pcgd.getGiaovien();
        }
        public int Phancong(PhanCongGiangDay x)
        {

            return pcgd.Them(x);
        }

    }

}
