﻿using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Paint_offi.Model
{
    public class MEllipse : MRectangle
    {
        public MEllipse()
        {
            name = "Ellipse";
        }

        public MEllipse(Color color)
        {
            name = "Ellipse";
            this.color = color;
        }
        protected override System.Drawing.Drawing2D.GraphicsPath graphicsPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();

                if (pointTail.X < pointHead.X && pointTail.Y < pointHead.Y)
                {
                    path.AddEllipse(new Rectangle(pointTail.X,
                   pointTail.Y,
                   pointHead.X - pointTail.X,
                   pointHead.Y - pointTail.Y));
                }
                else if (pointHead.X > pointTail.X && pointHead.Y < pointTail.Y)
                {

                    path.AddEllipse(getRectangle(pointHead, pointTail));
                }
                else if (pointHead.X < pointTail.X && pointHead.Y > pointTail.Y)
                {

                    path.AddEllipse(getRectangle(pointHead, pointTail));
                }
                else
                {
                    path.AddEllipse(new Rectangle(pointHead.X,
                        pointHead.Y,
                        pointTail.X - pointHead.X,
                        pointTail.Y - pointHead.Y));
                }
                return path;
            }
        }
    }
}
