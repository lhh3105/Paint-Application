using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint_offi.Model
{
    public class MPen : MCurve
    {
        //TODO: cho biết chọn chế độ xóa hay là không
        public int penStyle { get; set; }
        public bool isEraser { get; set; }

        public MPen()
        {
            name = "Pen";
        }

        public MPen(Color color)
        {
            name = "Pen";
            this.color = color;
        }

    }
}
