using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ModernUIControlsForWinForms.Controls.Stuff
{
    public static class PathHelper
    {
        public static GraphicsPath GenerateStar(PointF middle, int segments, float innerRadius, float outterRadius, float startDeg)
        {
            var Points = new List<PointF>();

            float StartRad = (float)(startDeg * Math.PI / 180);
            float Distance = (float)((360 / (segments * 2)) * Math.PI / 180);
            for (int part = 0; part < segments * 2; part++)
            {
                if (part % 2 == 1)
                {
                    //Add Point on the outter circle
                    float x = (float)(outterRadius * Math.Cos(StartRad + Distance * part)) + middle.X;
                    float y = (float)(outterRadius * Math.Sin(StartRad + Distance * part)) + middle.Y;
                    Points.Add(new PointF(x, y));
                }
                else
                {
                    //Add Point on the inner circle
                    float x = (float)(innerRadius * Math.Cos(StartRad + Distance * part)) + middle.X;
                    float y = (float)(innerRadius * Math.Sin(StartRad + Distance * part)) + middle.Y;
                    Points.Add(new PointF(x, y));
                }
            }

            var Path = new GraphicsPath();
            Path.AddPolygon(Points.ToArray());
            return Path;
        }
    }
}
