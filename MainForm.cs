/*
 * Created by SharpDevelop.
 * User: razvan
 * Date: 6/14/2024
 * Time: 12:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace speedometruauto
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public Graphics g;
		public Pen p = new Pen(Color.Black, 5);
		public Pen pc = new Pen(Color.FromArgb(100,10,10,10), 5);
		public Pen pb = new Pen(Color.Red, 2);
		public Pen pr = new Pen(Color.FromArgb(100,255,29,71), 5);
		
		void MainFormLoad(object sender, EventArgs e)
		{
			g = panel1.CreateGraphics();
		}
		
		public void drawCircle(ref Graphics pg, ref Pen pp, float px, float py, float dimx, float dimy)
		{
			pg.DrawEllipse(pp, px, py, dimx, dimy);
		}
		public void drawLine(ref Graphics pg, ref Pen pp, float px1, float py1, float px2, float py2)
		{
			pg.DrawLine(pp, px1, py1, px2, py2);
		}
		public float mid(float a, float b)
		{
			return Math.Abs(b - a);
		}
		public void xdrawthedrowing()
		{
		
			float xs = 130;
			float ys = 130;
			float innerdiffx = 20;
			float innerdiffy = 20;
			float suprax = 10;
			float supray = 10;
			float rxc1 = 100;
			float ryc1 = 100;
			float rxc2 = rxc1 - innerdiffx;
			float ryc2 = ryc1 - innerdiffy;
			
			drawCircle(ref g, ref p, xs + suprax, ys + supray, xs + rxc1, ys + ryc1);
			drawCircle(ref g, ref pb, xs + innerdiffx, ys + innerdiffy, xs + rxc2, ys + ryc2);
			
			float xm = mid(xs + innerdiffx / 2, xs + rxc1);
			float ym = mid(ys + innerdiffx / 2, ys + ryc1);
			float centerpointx = xm + xs / 2;
			float centerpointy = ym + ys / 2;
			float toppointmiddlex = rxc1 + (suprax / 2);
			float toppointmiddley = ys;
			drawLine(ref g, ref pb, centerpointx, centerpointy, xs, ys);
			drawLine(ref g, ref pb, centerpointx, centerpointy, toppointmiddlex, toppointmiddley);
			
			
			float centerpointxexteriorright = centerpointx + rxc1 / 2 + innerdiffx;
			float centerpointyexteriorright = centerpointy;
			
			drawLine(ref g, ref pb, centerpointx, centerpointy, centerpointxexteriorright, centerpointyexteriorright);
			
			float downrightycorner = centerpointyexteriorright + (ryc1 / 2) + innerdiffy;
			float downrightxcorner = centerpointxexteriorright;
			drawLine(ref g, ref pb, centerpointx, centerpointy, downrightxcorner, downrightycorner);
			
			
		
			float toprightxcorner = toppointmiddlex + (rxc1 / 2) + xs;
			drawLine(ref g, ref pb, centerpointx, centerpointy, toprightxcorner, toppointmiddley);
			
			float bottomrigtycorner = downrightycorner;
			drawLine(ref g, ref pb, centerpointx, centerpointy, xs, bottomrigtycorner);
		}
		public void drawthedrowing()
		{
			drawLine(ref g, ref pr, 500, 500, 550, 550);
			drawLine(ref g, ref pc, 250, 250, 501, 501);
		}
		void Button1Click(object sender, EventArgs e)
		{
			xdrawthedrowing();
		}
		public void clerarall()
		{
			//g.Clear(BackColor);
		}
		public float speed=0.1f;
		public void rotateToLeft()
		{
			clerarall();
			
			g.TranslateTransform(700, 700);
			
			g.RotateTransform(0.1f*speed);
			drawthedrowing();
			g.TranslateTransform(-1 * 700, -1 * 700);
			
			g.RotateTransform(0.1f*speed);

			drawthedrowing();
		}
		
		public void rotateToRight()
		{
			
			
			g.TranslateTransform(700, 700);
			
			g.RotateTransform(-0.1f*speed);
			drawthedrowing();
			g.TranslateTransform(-1 * 700, -1 * 700);
			
			g.RotateTransform(-0.1f*speed);

			drawthedrowing();
			
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			if(viteza<end){
				speed+=1;
				viteza++;
			}
			
		}
		void Button3Click(object sender, EventArgs e)
		{
			if(viteza>0){
			speed-=1;
			viteza--;
			}
			
		}
		
		int counterof = 1;
		int start = 0;
		int end = 100*5;
		int viteza = 0;
		int direction = 0;
		void Timer1Tick(object sender, EventArgs e)
		{
			counterof++;
			if(viteza<end && direction==0){rotateToLeft();viteza++;}
			else { direction=1;}
			if(viteza>=start && direction==1){rotateToRight();viteza--;}
			else {direction = 0;}
			if (counterof % 9 == 0) {
				g.Clear(BackColor);
				counterof=0;
			}
			//xdrawthedrowing();
		}
		void Button4Click(object sender, EventArgs e)
		{
			g.Clear(BackColor);
		}
		
		
	}
}
