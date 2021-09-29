using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flags
{
    public partial class TwoFlags : Form
    {
        private bool flag = true; // булевая переменная для смены флагов
        public TwoFlags()
        {
            InitializeComponent();
        }

        // обратите внимание, что когда я рисую флаги, я не вношу определённые координаты точек
        // вместо этого я вношу отношение размера окна к нужной точке
        // таким образом, при изменении размеров окна флаг будет перерисовываться
        // и программа будет работать корректно!!!

        private void DrawTanzania() // рисуем флаг Танзании
        {
            Bitmap bmp = new Bitmap(picture.Width, picture.Height); // создаём необохимые переменные для рисования
            Graphics g = Graphics.FromImage(bmp);
            Brush greenish = new SolidBrush(Color.FromArgb(24, 182, 55)); // создаём кисти нужных нам цветов
            Brush lightblueish = new SolidBrush(Color.FromArgb(0, 164, 222));
            Brush yellowish = new SolidBrush(Color.FromArgb(252, 210, 15));
            g.FillRectangle(greenish, 0, 0, picture.Width, picture.Height); // заполняем поле зелёным
            Point[] lightbluepart = { new Point(picture.Width, picture.Height), new Point(0, picture.Height), new Point(picture.Width, 0) }; // выделяем область для голубой части флага
            g.FillPolygon(lightblueish, lightbluepart); // закрашиваем её
            Point[] yellowpart = { new Point(0, picture.Height * 3 / 4), new Point(0, picture.Height),
                                   new Point(picture.Width * 7 / 30, picture.Height), new Point(picture.Width, picture.Height / 4),
                                   new Point(picture.Width, 0), new Point(picture.Width * 23 / 30, 0) }; // выделяем область для жёлтой части флага
            g.FillPolygon(yellowish, yellowpart); // закрашиваем её
            Point[] blackpart = { new Point(0, picture.Height * 33 / 40), new Point(0, picture.Height),
                                  new Point(picture.Width / 6, picture.Height), new Point(picture.Width, picture.Height * 7 / 40),
                                  new Point(picture.Width, 0), new Point(picture.Width * 5 / 6, 0) }; // выделяем область для чёрной части флага
            g.FillPolygon(Brushes.Black, blackpart); // закрашиваем её
            picture.Image = bmp; // отображаем флаг

        }

        private void DrawSolomonIslands() // рисуем флаг Соломоновых островов
        {
            Bitmap bmp = new Bitmap(picture.Width, picture.Height); // создаём необохимые переменные для рисования
            Graphics g = Graphics.FromImage(bmp);
            Brush greenish = new SolidBrush(Color.FromArgb(27, 91, 48)); // создаём кисти нужных нам цветов
            Brush blueish = new SolidBrush(Color.FromArgb(0, 80, 187));
            Brush yellowish = new SolidBrush(Color.FromArgb(252, 210, 15));
            g.FillRectangle(blueish, 0, 0, picture.Width, picture.Height); // заполняем поле синим
            Point[] greenpart = { new Point(picture.Width, picture.Height), new Point(0, picture.Height), new Point(picture.Width, 0) }; // выделяем область для зелёной части флага
            g.FillPolygon(greenish, greenpart); // закрашиваем её
            Point[] yellowpart = { new Point(0, picture.Height * 19 / 20), new Point(0, picture.Height),
                                   new Point(picture.Width / 20, picture.Height), new Point(picture.Width, picture.Height / 20),
                                   new Point(picture.Width, 0), new Point(picture.Width * 19 / 20, 0) }; // выделяем область для жёлтой части флага
            g.FillPolygon(yellowish, yellowpart); // закрашиваем её
            Point[] starpart = { new Point(picture.Width * 66 / 799, picture.Height * 7 / 399), new Point(picture.Width * 75 / 799, picture.Height * 34 / 399),
                                 new Point(picture.Width * 103 / 799, picture.Height * 34 / 399), new Point(picture.Width * 80 / 799, picture.Height * 51 / 399),
                                 new Point(picture.Width * 89 / 799, picture.Height * 78 / 399), new Point(picture.Width * 66 / 799, picture.Height * 61 / 399),
                                 new Point(picture.Width * 43 / 799, picture.Height * 78 / 399), new Point(picture.Width * 52 / 799, picture.Height * 51 / 399),
                                 new Point(picture.Width * 29 / 799, picture.Height * 34 / 399), new Point(picture.Width * 57 / 799, picture.Height * 34 / 399)}; // рисуем звезду
            g.FillPolygon(Brushes.White, starpart); // закрашиваем её
            g.TranslateTransform(picture.Width * 147 / 799, 0); // четыре раза перемещаем координаты, чтобы создать новые звёзды, и закрашиваем их
            g.FillPolygon(Brushes.White, starpart);
            g.TranslateTransform(0, picture.Height * 147 / 399);
            g.FillPolygon(Brushes.White, starpart);
            g.TranslateTransform(-picture.Width * 147 / 799, 0);
            g.FillPolygon(Brushes.White, starpart);
            g.TranslateTransform(picture.Width * 73 / 799, -picture.Height * 73 / 399);
            g.FillPolygon(Brushes.White, starpart);
            picture.Image = bmp; // отображаем флаг
        }

        private void Check() // выбираем, какой флаг рисовать
        {
            if (flag)
                DrawTanzania();
            else
                DrawSolomonIslands();
        }

        private void TwoFlags_Resize(object sender, EventArgs e) // в случае изменения размеров окна перерисовываем флаг
        {
            Check();
        }

        private void TwoFlags_Load(object sender, EventArgs e) // рисуем флаг при открытии приложения
        {
            Check();
        }

        private void ChangeToolStripMenuItem_Click(object sender, EventArgs e) // кнопка в меню, меняющая флаг
        {
            flag = !flag; // меняем значение булевой переменной на противоположное
            Check(); // рисуем флаг
        }
    }
}
