using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

using Paint_offi.View;
using Paint_offi.Model;
using Paint_offi.Utils;
using Paint_offi.Presenter;
using Paint_offi.Presenter.Alter;
using Paint_offi.Presenter.Updates;
using Paint_offi.Presenter.Draws;


namespace Paint_offi
{
    
    public partial class Form1 : Form, ViewPaint
    {

        private PresenterDraw presenterDraw;

        private PresenterAlter presenterAlter;

        private PresenterUpdate presenterUpdate;

        private Graphics gr;

        public int penStyle = 0;
        
        
        public Form1()
        {
            InitializeComponent();
            // changeRegion();
            initComponents();
            gr = ptbDrawing.CreateGraphics();
        }

        private void changeRegion()
        {
            using (GraphicsPath path = new GraphicsPath())
            {

                path.AddLine(new Point(0, 20), new Point(0, this.Height - 150));

                path.AddLine(new Point(0, this.Height - 150),
                    new Point((this.Width / 2) - 50, this.Height - 150));

                path.AddLine(new Point((this.Width / 2) - 50, this.Height - 150),
                    new Point((this.Width / 2) - 80, this.Height - 110));

                path.AddLine(new Point((this.Width / 2) - 80, this.Height - 110),
                    new Point((this.Width / 2) - 150, this.Height - 90));

                path.AddLine(new Point((this.Width / 2) - 150, this.Height - 90),
                    new Point((this.Width / 2) + 150, this.Height - 90));

                path.AddLine(new Point((this.Width / 2) + 150, this.Height - 90),
                    new Point((this.Width / 2) + 80, this.Height - 110));

                path.AddLine(new Point((this.Width / 2) + 80, this.Height - 110),
                    new Point((this.Width / 2) + 50, this.Height - 150));

                path.AddLine(new Point((this.Width / 2) + 50, this.Height - 150),
                    new Point(this.Width, this.Height - 150));

                path.AddLine(new Point(this.Width, this.Height - 150), new Point(this.Width, 20));

                path.AddLine(new Point(this.Width, 20), new Point(0, 20));

                this.Region = new Region(path);
            }
        }

        private void initComponents()
        {
            presenterDraw = new PresenterDrawImp(this);
            presenterAlter = new PresenterAlterImp(this);
            presenterUpdate = new PresenterUpdateImp(this);
            presenterUpdate.onClickSelectColor(ptbColor.BackColor, gr);
            presenterUpdate.onClickSelectSize(btnLineSize.Value + 1);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnLineSize_Scroll(object sender, EventArgs e)
        {
            presenterUpdate.onClickSelectSize(btnLineSize.Value + 1);
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            presenterDraw.onClickDrawLine();
        }

        private void btnBezier_Click(object sender, EventArgs e)
        {
            presenterDraw.onClickDrawBezier();
        }

        private void btnEllipse_Click(object sender, EventArgs e)
        {
            presenterDraw.onClickDrawEllipse();
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            presenterDraw.onClickDrawRectangle();
        }

        private void btnPolygon_Click(object sender, EventArgs e)
        {
            presenterDraw.onClickDrawPolygon();
        }

        private void btnPen_Click(object sender, EventArgs e)
        {
            presenterDraw.onClickDrawPen();
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            presenterUpdate.onClickSelectFill(btn, gr);
        }

        private void btnEraser_Click(object sender, EventArgs e)
        {
            presenterDraw.onClickDrawEraser();
        }

        private void btnChangeColor_Click(object sender, EventArgs e)
        {
            PictureBox ptb = sender as PictureBox;
            ptbColor.BackColor = ptb.BackColor;
            presenterUpdate.onClickSelectColor(ptb.BackColor, gr);
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {

        }
        public void setDrawingRegionRectangle(Pen p, Rectangle rectangle, Graphics g)
        {
            g.DrawRectangle(p, rectangle);
        }
        public void setCursor(Cursor cursor)
        {
            ptbDrawing.Cursor = cursor;
        }
        public void setColor(Color color)
        {
            ptbColor.BackColor = color;
        }

        public void setColor(Button btn, Color color)
        {
            btn.BackColor = color;
        }
        public void setDrawing(Shape shape, Graphics g)
        {
           shape.drawShape(g);
            
        }
        public void setDrawingCurveSelected(List<Point> points, Brush brush, Graphics g)
        {
            for (int i = 0; i < points.Count; ++i)
            {
                g.FillRectangle(brush, new System.Drawing.Rectangle(points[i].X - 4, points[i].Y - 4, 8, 8));
            }

        }
        public void setDrawingLineSelected(Shape shape, Brush brush, Graphics g)
        {
            g.FillRectangle(brush, new System.Drawing.Rectangle(shape.pointHead.X - 4, shape.pointHead.Y - 4, 8, 8));
            g.FillRectangle(brush, new System.Drawing.Rectangle(shape.pointTail.X - 4, shape.pointTail.Y - 4, 8, 8));
        }

        private void ptbDrawing_MouseClick(object sender, MouseEventArgs e)
        {
            presenterDraw.onClickStopDrawing(e.Button);
        }

        private void ptbDrawing_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            presenterDraw.getDrawing(e.Graphics);
        }

        private void ptbDrawing_MouseDown(object sender, MouseEventArgs e)
        {
            presenterDraw.onClickMouseDown(e.Location);
        }

        private void ptbDrawing_MouseMove(object sender, MouseEventArgs e)
        {
            lbLocation.Text = e.Location.X + ", " + e.Location.Y + "px";
            presenterDraw.onClickMouseMove(e.Location);
        }
        public void refreshDrawing()
        {
            ptbDrawing.Invalidate();
        }

        private void ptbDrawing_MouseUp(object sender, MouseEventArgs e)
        {
            presenterDraw.onClickMouseUp();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            presenterUpdate.onClickSelectMode();
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            presenterAlter.onClickDrawGroup();
        }

        private void btnUnGroup_Click(object sender, EventArgs e)
        {
            presenterAlter.onClickDrawUnGroup();
        }
        public void movingShape(Shape shape, Point distance)
        {
            shape.moveShape(distance);
            refreshDrawing();
        }
        public void movingControlPoint(Shape shape, Point pointCurrent, Point previous, int indexPoint)
        {
            shape.moveControlPoint(pointCurrent, previous, indexPoint);
            refreshDrawing();
        }

        private void ptbEditColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                presenterUpdate.onClickSelectColor(colorDialog.Color, gr);
            }
        }

        private void stripmenu_save_Click(object sender, EventArgs e)
        {
            presenterAlter.onClickSaveImage(ptbDrawing);
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void stripmenu_new_Click(object sender, EventArgs e)
        {
            presenterAlter.onClickNewImage(ptbDrawing);
        }

        private void stripmenu_open_Click(object sender, EventArgs e)
        {
            presenterAlter.onClickOpenImage(ptbDrawing);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ptbDrawing_Click(object sender, EventArgs e)
        {

        }


        private void nétLiềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            penStyle = 0;
        }

        private void nétĐứtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            penStyle = 1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            presenterAlter.onClickDeleteShape();
        }
    }
}
