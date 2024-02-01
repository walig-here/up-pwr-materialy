using System.Drawing;
using System.Text;

namespace kodyEAN13
{
    public partial class Form1 : Form
    { 
        private Ean13 ean13 = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void CreateEan13()
        {
            ean13 = new Ean13();
            ean13.CountryCode = kodKraju.Text;
            ean13.ManufacturerCode = kodProducenta.Text;
            ean13.ProductCode = KodProduktu.Text;
        }

        private void DrawEan13()
        {
            Graphics g = this.picBarcode.CreateGraphics();

            CreateEan13();
            ean13.Scale = (float)Convert.ToDecimal(1.5f);
            ean13.DrawEan13Barcode(g, new System.Drawing.Point(0, 0));
            g.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DrawEan13();
        }
    }

    class Ean13{
        private string Name = "EAN13";

        // This is the nomimal size recommended by the EAN.
        public float Width = 37.29f;
        public float Height = 25.93f;
        public float FontSize = 8.0f;
        public float Scale = 1.0f;

        // Left Hand Digits.
        private string[] _aOddLeft = { "0001101", "0011001", "0010011", "0111101",
                                          "0100011", "0110001", "0101111", "0111011",
                                          "0110111", "0001011" };

        private string[] _aEvenLeft = { "0100111", "0110011", "0011011", "0100001",
                                           "0011101", "0111001", "0000101", "0010001",
                                           "0001001", "0010111" };

        // Right Hand Digits.
        private string[] _aRight = { "1110010", "1100110", "1101100", "1000010",
                                        "1011100", "1001110", "1010000", "1000100",
                                        "1001000", "1110100" };

        private string QuiteZone = "000000000";

        private string LeadTail = "101";

        private string Separator = "01010";

        public string CountryCode;
        public string ManufacturerCode;
        public string ProductCode;
        public string ChecksumDigit;

        public void DrawEan13Barcode(System.Drawing.Graphics g, System.Drawing.Point pt)
        {
            float width = this.Width * this.Scale;
            float height = this.Height * this.Scale;

            //	EAN13 Barcode should be a total of 113 modules wide.
            float lineWidth = width / 113f;

            // Save the GraphicsState.
            System.Drawing.Drawing2D.GraphicsState gs = g.Save();

            // Set the PageUnit to Inch because all of our measurements are in inches.
            g.PageUnit = System.Drawing.GraphicsUnit.Millimeter;

            // Set the PageScale to 1, so a millimeter will represent a true millimeter.
            g.PageScale = 1;

            System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

            float xPosition = 0;

            System.Text.StringBuilder strbEAN13 = new System.Text.StringBuilder();
            System.Text.StringBuilder sbTemp = new System.Text.StringBuilder();

            float xStart = pt.X;
            float yStart = pt.Y;
            float xEnd = 0;

            System.Drawing.Font font = new System.Drawing.Font("Arial", this.FontSize * this.Scale);

            // Calculate the Check Digit.
            this.CalculateChecksumDigit();

            sbTemp.AppendFormat("{0}{1}{2}{3}",
                this.CountryCode,
                this.ManufacturerCode,
                this.ProductCode,
                this.ChecksumDigit);


            string sTemp = sbTemp.ToString();

            string sLeftPattern = "";

            // Convert the left hand numbers.
            sLeftPattern = ConvertLeftPattern(sTemp.Substring(0, 7));

            // Build the UPC Code.
            strbEAN13.AppendFormat("{0}{1}{2}{3}{4}{1}{0}",
                this.QuiteZone, this.LeadTail,
                sLeftPattern,
                this.Separator,
                ConvertToDigitPatterns(sTemp.Substring(7), this._aRight));

            string sTempUPC = strbEAN13.ToString();

            float fTextHeight = g.MeasureString(sTempUPC, font).Height;

            // Draw the barcode lines.
            for (int i = 0; i < strbEAN13.Length; i++)
            {
                if (sTempUPC.Substring(i, 1) == "1")
                {
                    if (xStart == pt.X)
                        xStart = xPosition;

                    // Save room for the UPC number below the bar code.
                    if ((i > 12 && i < 55) || (i > 57 && i < 101))
                        // Draw space for the number
                        g.FillRectangle(brush, xPosition, yStart, lineWidth, height - fTextHeight);
                    else
                        // Draw a full line.
                        g.FillRectangle(brush, xPosition, yStart, lineWidth, height);
                }

                xPosition += lineWidth;
                xEnd = xPosition;
            }

            // Draw the upc numbers below the line.
            xPosition = xStart - g.MeasureString(this.CountryCode.Substring(0, 1), font).Width;
            float yPosition = yStart + (height - fTextHeight);

            // Draw 1st digit of the country code.
            g.DrawString(sTemp.Substring(0, 1), font, brush, new System.Drawing.PointF(xPosition, yPosition));

            xPosition += (g.MeasureString(sTemp.Substring(0, 1), font).Width + 43 * lineWidth) -
                (g.MeasureString(sTemp.Substring(1, 6), font).Width);

            // Draw MFG Number.
            g.DrawString(sTemp.Substring(1, 6), font, brush, new System.Drawing.PointF(xPosition, yPosition));

            xPosition += g.MeasureString(sTemp.Substring(1, 6), font).Width + (11 * lineWidth);

            // Draw Product ID.
            g.DrawString(sTemp.Substring(7), font, brush, new System.Drawing.PointF(xPosition, yPosition));

            // Restore the GraphicsState.
            g.Restore(gs);
        }


        public System.Drawing.Bitmap CreateBitmap()
        {
            float tempWidth = (this.Width * this.Scale) * 100;
            float tempHeight = (this.Height * this.Scale) * 100;

            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap((int)tempWidth, (int)tempHeight);

            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);
            this.DrawEan13Barcode(g, new System.Drawing.Point(0, 0));
            g.Dispose();
            return bmp;
        }


        private string ConvertLeftPattern(string sLeft)
        {
            switch (sLeft.Substring(0, 1))
            {
                case "0":
                    return CountryCode0(sLeft.Substring(1));

                case "1":
                    return CountryCode1(sLeft.Substring(1));

                case "2":
                    return CountryCode2(sLeft.Substring(1));

                case "3":
                    return CountryCode3(sLeft.Substring(1));

                case "4":
                    return CountryCode4(sLeft.Substring(1));

                case "5":
                    return CountryCode5(sLeft.Substring(1));

                case "6":
                    return CountryCode6(sLeft.Substring(1));

                case "7":
                    return CountryCode7(sLeft.Substring(1));

                case "8":
                    return CountryCode8(sLeft.Substring(1));

                case "9":
                    return CountryCode9(sLeft.Substring(1));

                default:
                    return "";
            }
        }


        private string CountryCode0(string sLeft)
        {
            // 0 Odd Odd  Odd  Odd  Odd  Odd 
            return ConvertToDigitPatterns(sLeft, this._aOddLeft);
        }


        private string CountryCode1(string sLeft)
        {
            // 1 Odd Odd  Even Odd  Even Even 
            System.Text.StringBuilder sReturn = new StringBuilder();
            // The two lines below could be replaced with this:
            // sReturn.Append( ConvertToDigitPatterns( sLeft.Substring( 0, 2 ), this._aOddLeft ) );
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aOddLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aEvenLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aOddLeft));
            // The two lines below could be replaced with this:
            // sReturn.Append( ConvertToDigitPatterns( sLeft.Substring( 4, 2 ), this._aEvenLeft ) );
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aEvenLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aEvenLeft));
            return sReturn.ToString();
        }


        private string CountryCode2(string sLeft)
        {
            // 2 Odd Odd  Even Even Odd  Even 
            System.Text.StringBuilder sReturn = new StringBuilder();
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aOddLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aEvenLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aEvenLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aOddLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aEvenLeft));
            return sReturn.ToString();
        }


        private string CountryCode3(string sLeft)
        {
            // 3 Odd Odd  Even Even Even Odd 
            System.Text.StringBuilder sReturn = new StringBuilder();
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aOddLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aEvenLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aEvenLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aEvenLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aOddLeft));
            return sReturn.ToString();
        }


        private string CountryCode4(string sLeft)
        {
            // 4 Odd Even Odd  Odd  Even Even 
            System.Text.StringBuilder sReturn = new StringBuilder();
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aEvenLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aOddLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aOddLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aEvenLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aEvenLeft));
            return sReturn.ToString();
        }


        private string CountryCode5(string sLeft)
        {
            // 5 Odd Even Even Odd  Odd  Even 
            System.Text.StringBuilder sReturn = new StringBuilder();
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aEvenLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aEvenLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aOddLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aOddLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aEvenLeft));
            return sReturn.ToString();
        }


        private string CountryCode6(string sLeft)
        {
            // 6 Odd Even Even Even Odd  Odd 
            System.Text.StringBuilder sReturn = new StringBuilder();
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aEvenLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aEvenLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aEvenLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aOddLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aOddLeft));
            return sReturn.ToString();
        }


        private string CountryCode7(string sLeft)
        {
            // 7 Odd Even Odd  Even Odd  Even
            System.Text.StringBuilder sReturn = new StringBuilder();
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aEvenLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aOddLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aEvenLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aOddLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aEvenLeft));
            return sReturn.ToString();
        }


        private string CountryCode8(string sLeft)
        {
            // 8 Odd Even Odd  Even Even Odd 
            System.Text.StringBuilder sReturn = new StringBuilder();
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aEvenLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aOddLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aEvenLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aEvenLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aOddLeft));
            return sReturn.ToString();
        }


        private string CountryCode9(string sLeft)
        {
            // 9 Odd Even Even Odd  Even Odd 
            System.Text.StringBuilder sReturn = new StringBuilder();
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(0, 1), this._aOddLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(1, 1), this._aEvenLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(2, 1), this._aEvenLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(3, 1), this._aOddLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(4, 1), this._aEvenLeft));
            sReturn.Append(ConvertToDigitPatterns(sLeft.Substring(5, 1), this._aOddLeft));
            return sReturn.ToString();
        }


        private string ConvertToDigitPatterns(string inputNumber, string[] patterns)
        {
            System.Text.StringBuilder sbTemp = new StringBuilder();
            int iIndex = 0;
            for (int i = 0; i < inputNumber.Length; i++)
            {
                iIndex = Convert.ToInt32(inputNumber.Substring(i, 1));
                sbTemp.Append(patterns[iIndex]);
            }
            return sbTemp.ToString();
        }


        public void CalculateChecksumDigit()
        {
            string sTemp = this.CountryCode + this.ManufacturerCode + this.ProductCode;
            int iSum = 0;
            int iDigit = 0;

            // Calculate the checksum digit here.
            for (int i = sTemp.Length; i >= 1; i--)
            {
                iDigit = Convert.ToInt32(sTemp.Substring(i - 1, 1));
                if (i % 2 == 0)
                {   // odd
                    iSum += iDigit * 3;
                }
                else
                {   // even
                    iSum += iDigit * 1;
                }
            }

            int iCheckSum = (10 - (iSum % 10)) % 10;
            this.ChecksumDigit = iCheckSum.ToString();

        }
    }
}