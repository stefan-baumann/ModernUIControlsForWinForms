using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModernUIControlsForWinForms.Controls.Stuff
{
    /// <summary>
    /// Provides settings affecting the drawingquality of a Control
    /// </summary>
    public class DrawingSettings
    {
        public DrawingSettings(SmoothingMode smoothingMode, TextRenderingHint textRenderingHint, PixelOffsetMode pixelOffsetMode, CompositingQuality composingQuality, InterpolationMode interpolationMode)
        {
            this.SmoothingMode = smoothingMode;
            this.TextRenderingHint = textRenderingHint;
            this.PixelOffsetMode = pixelOffsetMode;
            this.CompositingQuality = composingQuality;
            this.InterpolationMode = interpolationMode;
        }

        public SmoothingMode SmoothingMode { get; set; }
        public TextRenderingHint TextRenderingHint { get; set; }
        public PixelOffsetMode PixelOffsetMode { get; set; }
        public CompositingQuality CompositingQuality { get; set; }
        public InterpolationMode InterpolationMode { get; set; }

        public static DrawingSettings LowQuality
        {
            get {
                return new DrawingSettings(SmoothingMode.None, TextRenderingHint.SystemDefault, PixelOffsetMode.HighSpeed, CompositingQuality.HighSpeed, InterpolationMode.Low);
            }
        }

        public static DrawingSettings HighQuality {
            get {
                return new DrawingSettings(SmoothingMode.AntiAlias, TextRenderingHint.SystemDefault, PixelOffsetMode.HighQuality, CompositingQuality.HighQuality, InterpolationMode.HighQualityBicubic);
            }
        }
    }
}
