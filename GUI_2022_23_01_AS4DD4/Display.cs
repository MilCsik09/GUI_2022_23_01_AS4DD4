﻿using GUI_2022_23_01_AS4DD4.Logic;
using GUI_2022_23_01_AS4DD4.Logic.Interfaces;
using GUI_2022_23_01_AS4DD4.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace GUI_2022_23_01_AS4DD4
{

    public class Display : FrameworkElement
    {
        Size size;
        static Random r = new Random();

        IShooterModel model;
        IShooterControl control;



        public void SetupModel(IShooterModel model)
        {
            this.model = model;
            this.model.Changed += (sender, eventargs) => this.InvalidateVisual();
        }

        public void SetupSizes(Size size)
        {
            this.size = size;
            this.InvalidateVisual();

        }

        public void Resize(Size size)
        {
            this.size = size;
            InvalidateVisual();
        }

        public Brush BackgroundBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine(@"..\..\..\Images", "Background.jpg"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush EnemyBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine(@"..\..\..\Images", "Bandit.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush CrossHairBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine(@"..\..\..\Images", "Crosshair.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush PotionBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine(@"..\..\..\Images", "Potion.png"), UriKind.RelativeOrAbsolute)));
            }
        }

        public Brush SignBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine(@"..\..\..\Images", "Sign.png"), UriKind.RelativeOrAbsolute)));
            }
        }


        public void DrawBackground(DrawingContext dc)
        {
            dc.DrawRectangle(BackgroundBrush, null, new Rect(0, 0, size.Width, size.Height));
        }

        public void DrawSign(DrawingContext dc)
        {
            dc.DrawRectangle(SignBrush, null, new Rect(size.Width / (15/16), size.Height / (7/9), 50, 50  ));
        }

        public void DrawEnemy(DrawingContext dc)        //random position az ablakban, ha legyőztük, akkor eltűnik és kirajzolja a következőt a listából
        {
            //int enemyPositionX = r.Next(0, (int)size.Width);
            //int enemyPositionY = r.Next(0, (int)size.Height);

            Point enemyPosition = new Point(r.Next(0, (int)size.Width), r.Next(0, (int)size.Height));

            dc.DrawRectangle(EnemyBrush, null, new Rect(enemyPosition.X, enemyPosition.Y, size.Width / 16, size.Height / 16));
        }
        //{
        //foreach (var enemy in model)
        //{
        //    dc.DrawRectangle(EnemyBrush, null, new Rect(enemy.Position.X, enemy.Position.Y, enemy.Size.Width, enemy.Size.Height));
        //}
        //}

        public void DrawCrossHair(DrawingContext dc)        //segédmetódus a DrawEnemyhez, playeren belül relatív random pozíció
        {
            //dc.DrawRectangle(CrossHairBrush, null, new Rect(model.Enemy.Position.X + r.Next(0, 100), model.Enemy.Position.Y + r.Next(0, 100), 50, 50));
        }
        //{
        //    dc.DrawRectangle(CrossHairBrush, null, new Rect(player.Position.X + r.Next(-50, 50), player.Position.Y + r.Next(-50, 50), 50, 50));
        //}
        //{
        //    dc.DrawRectangle(CrossHairBrush, null, new Rect(model.Player.Position.X, model.Player.Position.Y, model.Player.Size.Width, model.Player.Size.Height));
        //}
        //{
        //    dc.DrawRectangle(CrossHairBrush, null, new Rect(model.CrossHair.Position.X, model.CrossHair.Position.Y, model.CrossHair.Size.Width, model.CrossHair.Size.Height));
        //}






    //protected override void OnRender(DrawingContext drawingContext)
    //{
    //    base.OnRender(drawingContext);

    //    //if (size.Width > 0 && size.Height > 0)
    //    //{
    //    //    drawingContext.DrawRectangle(BackgroundBrush, null, new Rect(0, 0, size.Width, size.Height));
    //    //}


    //    //Example for testing renderer
    //    //    if (size.Width > 0 && size.Height > 0)
    //    //    {
    //    //        int row = r.Next(10, 30);
    //    //        int column = r.Next(10, 30);

    //        //        double rectWidth = size.Width / column;
    //        //        double rectHeight = size.Height / row;

    //        //        for (int i = 0; i < row; i++)
    //        //        {
    //        //            for (int j = 0; j < column; j++)
    //        //            {
    //        //                drawingContext.DrawRectangle(
    //        //                    new SolidColorBrush(Color.FromRgb((byte)r.Next(0, 255), (byte)r.Next(0, 255), (byte)r.Next(0, 255))),
    //        //                    new Pen(Brushes.Black, 0),
    //        //                    new Rect(j * rectWidth, i * rectHeight, rectWidth, rectHeight));
    //        //            }
    //        //        }

    //        //    }
    //}
}
}
