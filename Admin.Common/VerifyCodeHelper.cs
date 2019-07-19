using System;
using System.Collections.Generic;
using System.DrawingCore;
using System.DrawingCore.Imaging;
using System.IO;
using System.Text;

namespace Admin.Common
{
    public class VerifyCodeHelper
    {
        /// <summary>
        /// 数字随机数
        /// </summary>
        /// <param name="n">生成长度</param>
        /// <returns></returns>
        public static string RandNumberCode(int n)
        {
            char[] arrChar = new char[]{
                '0','1','2','3','4','5','6','7','8','9',
            };

            StringBuilder num = new StringBuilder();
  
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < n; i++)
            {
                num.Append(arrChar[rnd.Next(0, arrChar.Length)].ToString());
            }
            return num.ToString();
        }
        /// <summary>
        /// 数字+字母随机数
        /// </summary>
        /// <param name="n">生成长度</param>
        /// <returns></returns>
        public static string RandCharCode(int n)
        {
            char[] arrChar = { '2', '3', '4', '5', '6', '8', '9', 'a', 'b', 'd', 'e', 'f', 'h', 'k', 'm', 'n', 'r', 'x', 'y', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'R', 'S', 'T', 'W', 'X', 'Y' };

            StringBuilder num = new StringBuilder();
            
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < n; i++)
            {
                num.Append(arrChar[rnd.Next(0, arrChar.Length)].ToString());
            }
            return num.ToString();
        }
        /// <summary>
        /// 获取Base64的图形验证码
        /// </summary>
        /// <param name="code"></param>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static string GetVerifyCodeBase64String(out string code, int numbers = 4)
        {
            code = RandCharCode(numbers);
            int codeW = (int)code.Length * 18;
            int codeH = 32;
            int fontSize = 16;

            Bitmap Img = null;
            Graphics g = null;
            MemoryStream ms = null;
            Random random = new Random();
            //验证码颜色集合  
            Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };

            //验证码字体集合
            string[] fonts = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };


            //定义图像的大小，生成图像的实例  
            Img = new Bitmap(codeW, 32);

            g = Graphics.FromImage(Img);//从Img对象生成新的Graphics对象    

            g.Clear(Color.White);//背景设为白色  

            //画噪线 
            for (int i = 0; i < 3; i++)
            {
                int x1 = random.Next(codeW);
                int y1 = random.Next(codeH);
                int x2 = random.Next(codeW);
                int y2 = random.Next(codeH);
                Color clr = c[random.Next(c.Length)];
                g.DrawLine(new Pen(clr), x1, y1, x2, y2);
            }

            //在随机位置画背景点  
            //for (int i = 0; i < 100; i++)
            //{
            //    int x = random.Next(Img.Width);
            //    int y = random.Next(Img.Height);
            //    g.DrawRectangle(new Pen(Color.LightGray, 0), x, y, 1, 1);
            //}

            //验证码绘制在g中  
            for (int i = 0; i < code.Length; i++)
            {
                int cindex = random.Next(7);//随机颜色索引值  
                int findex = random.Next(5);//随机字体索引值  
                Font f = new Font(fonts[findex], fontSize, FontStyle.Bold);//字体  
                Brush b = new SolidBrush(c[cindex]);//颜色  
                int ii = 4;
                if ((i + 1) % 2 == 0)//控制验证码不在同一高度  
                {
                    ii = 2;
                }
                g.DrawString(code.Substring(i, 1), f, b, 3 + (i * 12), ii);//绘制一个验证字符  
            }
            ms = new MemoryStream();//生成内存流对象  
            Img.Save(ms, ImageFormat.Jpeg);//将此图像以Png图像文件的格式保存到流中  

            //回收资源  
            g.Dispose();
            Img.Dispose();

            return "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
        }
    }
}
