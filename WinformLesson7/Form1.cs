using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformLesson7
{
    public partial class Form1 : Form
    {
        Graphics graphics_context;
        Pen outline;
        SolidBrush fill_color;
        public Form1()
        {
            InitializeComponent();
            graphics_context = this.CreateGraphics();
            outline = new Pen(Color.Red, 2);
            fill_color = new SolidBrush(Color.Green);

        }     
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            label1.Text = $"X : {e.X}   Y : {e.Y}";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Button button = new Button();
            button.Size = new Size(50, 50);
            this.Controls.Add(button);
            if(sender is Button bt)
            {
                switch (bt.Text)
                {
                    case "Line":
                        {
                            graphics_context.DrawLine(outline,150,10,250,100);
                            break;
                        }
                    case "Circle":
                        {
                            //graphics_context.DrawEllipse(outline,300, 10, 50, 50);
                            graphics_context.FillEllipse(fill_color, 300, 10, 50, 50);
                            break;
                        }
                    case "Rectangle":
                        {
                            //graphics_context.DrawRectangle(outline, 300, 150, 50, 50);
                            graphics_context.FillRectangle(fill_color, 300, 150, 50, 50);
                            break;
                        }
                    case "Polygon":
                        {
                            Point[] points = new Point[5]
                            {
                                new Point(160,120),
                                new Point(120,180),
                                new Point(190,180),
                                new Point(200,241),
                                new Point(214,180),
                            };
                           // graphics_context.DrawPolygon(outline, points);
                           // graphics_context.FillPolygon(fill_color, points);
                            break;
                        }

                    case "Arc":
                        {
                           
                            Rectangle rectangle = new Rectangle(450, 50, 100, 100);
                           // graphics_context.DrawRectangle(outline,rectangle);
                            graphics_context.DrawArc(outline, rectangle, 45, 180);
                            break;
                        }

                    case "Curve":
                        {
                            Point[] points = new Point[6]
                           {
                                new Point(250,220),
                                new Point(220,280),
                                new Point(290,280),
                                new Point(300,341),
                                new Point(314,280),
                                new Point(250,220),
                           };

                           // graphics_context.DrawCurve(outline, points);
                            graphics_context.FillClosedCurve(fill_color, points);

                            break;
                        }
                    case "Text":
                        {
                            Font font = new Font("Verdana", 20);
                            Point location = new Point(400,200);
                            StringFormat draw_format = new StringFormat();
                            draw_format.FormatFlags = StringFormatFlags.DirectionVertical;

                            graphics_context.DrawString("Hello World", font, fill_color, location,draw_format);

                            break;
                        }
                 

                    default:
                        break;
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
