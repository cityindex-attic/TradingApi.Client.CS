using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TradingApi.Client.SampleWinFormApp
{
    public class Drawing
    {
        public static bool GradientHeaders(StringAlignment stringAlignment,
                                           System.Windows.Forms.DataGridViewCellPaintingEventArgs e)
        {


            SolidBrush gridBrush;
            Pen gridLinePen;
            StringFormat sf = new StringFormat();
            SolidBrush fillBrush;
            Color c1;
            Color c2;

            c1 = Color.Black;
            //c2 = Color.FromArgb(43, 44, 1);
            c2 = Color.DimGray;

            fillBrush = new SolidBrush(Color.LightGray);
            gridBrush = new SolidBrush(Color.Black);
            gridLinePen = new Pen(gridBrush);

            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush(e.CellBounds,
                                                                                c1,
                                                                                c2,
                                                                                LinearGradientMode.Vertical);

            e.Graphics.FillRectangle(myLinearGradientBrush, e.CellBounds);


            e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
                                e.CellBounds.Top, e.CellBounds.Right - 1,
                                e.CellBounds.Bottom);


            if (e.CellBounds.Left == 0)
            {
                e.Graphics.DrawLine(gridLinePen,
                                    e.CellBounds.Left,
                                    e.CellBounds.Top,
                                    e.CellBounds.Left,
                                    e.CellBounds.Bottom);
            }

            e.Graphics.DrawLine(gridLinePen,
                                e.CellBounds.Left,
                                e.CellBounds.Bottom - 1,
                                e.CellBounds.Right - 1,
                                e.CellBounds.Bottom - 1);


            e.Graphics.DrawLine(gridLinePen,
                                e.CellBounds.Left,
                                e.CellBounds.Top,
                                e.CellBounds.Right - 1,
                                e.CellBounds.Top);


            //Draw the text content of the cell, ignoring alignment.
            if (e.Value != null)
            {
                e.Graphics.DrawString(e.Value.ToString(),
                                      e.CellStyle.Font,
                                      fillBrush,
                                      e.CellBounds,
                                      sf);
            }

            e.Handled = true;



            fillBrush.Dispose();
            gridLinePen.Dispose();
            gridBrush.Dispose();
            myLinearGradientBrush.Dispose();


            return true;

        }



     
    }


     

}
