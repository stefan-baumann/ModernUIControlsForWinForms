using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ModernUIControlsForWinForms.Controls.Stuff
{
    public static class ColorHelpers
    {
        public static Color SetHue(this Color color, float hue)
        {
            return ColorFromHSL(hue, color.GetSaturation(), color.GetBrightness());
        }

        public static Color SetSaturation(this Color color, float saturation)
        {
            return ColorFromHSL(color.GetHue(), saturation, color.GetBrightness());
        }

        public static Color SetBrightness(this Color color, float brightness)
        {
            return ColorFromHSL(color.GetHue(), color.GetSaturation(), brightness);
        }

        //Source: http://stackoverflow.com/a/4106615
        public static Color ColorFromHSL(float hue, float saturation, float brightness)
        {
            if (0 == saturation)
            {
                return Color.FromArgb(
                                    Convert.ToInt32(brightness * 255),
                                    Convert.ToInt32(brightness * 255),
                                    Convert.ToInt32(brightness * 255));
            }

            float fMax, fMid, fMin;
            int iSextant, iMax, iMid, iMin;

            if (0.5 < brightness)
            {
                fMax = brightness - (brightness * saturation) + saturation;
                fMin = brightness + (brightness * saturation) - saturation;
            }
            else
            {
                fMax = brightness + (brightness * saturation);
                fMin = brightness - (brightness * saturation);
            }

            iSextant = (int)Math.Floor(hue / 60f);
            if (300f <= hue)
            {
                hue -= 360f;
            }

            hue /= 60f;
            hue -= 2f * (float)Math.Floor(((iSextant + 1f) % 6f) / 2f);
            if (0 == iSextant % 2)
            {
                fMid = (hue * (fMax - fMin)) + fMin;
            }
            else
            {
                fMid = fMin - (hue * (fMax - fMin));
            }

            iMax = Convert.ToInt32(fMax * 255);
            iMid = Convert.ToInt32(fMid * 255);
            iMin = Convert.ToInt32(fMin * 255);

            switch (iSextant)
            {
                case 1:
                    return Color.FromArgb(iMid, iMax, iMin);
                case 2:
                    return Color.FromArgb(iMin, iMax, iMid);
                case 3:
                    return Color.FromArgb(iMin, iMid, iMax);
                case 4:
                    return Color.FromArgb(iMid, iMin, iMax);
                case 5:
                    return Color.FromArgb(iMax, iMin, iMid);
                default:
                    return Color.FromArgb(iMax, iMid, iMin);
            }
        }
    }
}
