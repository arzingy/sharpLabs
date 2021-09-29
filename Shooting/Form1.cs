using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shooting
{
    public partial class shooting_form : Form
    {
        int allshoots = 0; // переменная выстрелов
        int currentshoots = 0; // счётчик сделанных выстрелов
        int goals = 0; // счётчик попаданий
        int best = -1; // переменная рекорда
        bool game_load = true; // переменная, проверяющая, началась ли стрельба
        bool game_play = false; // переменная, проверяющая, закончилась ли стрельба
        bool radxcheck = false; // первая проверяющая переменная
        bool shootycheck = false; // вторая проверяющая переменная
        Bitmap bmp = new Bitmap(678, 602); // переменная для рисования мишени и проверки выстрелов на попадание
        public shooting_form()
        {
            InitializeComponent();
        }

        private void shooting_form_Load(object sender, EventArgs e) // запускаем приложение
        {
            ToolTip radtip = new ToolTip(); // создаём всплывающую подсказку для радиуса
            ToolTip shoottip = new ToolTip(); // создаём всплывающую подсказку для выстрелов
            radtip.SetToolTip(radbox, "Введите целое число от 1 до 168"); // вносим подсказку для радиуса
            shoottip.SetToolTip(shootbox, "Введите целое число от 1 до 999"); // вносим подсказку для выстрелов
            DrawTarget(0); // рисуем мишень
        }

        private void DrawTarget(int rad) // рисуем мишень
        {
            Graphics g = Graphics.FromImage(bmp); // переменная для рисования
            Pen borderpen = new Pen(Brushes.Black, 1.0F); // перо для границ и осей
            Brush controlbrush = new SolidBrush(Color.FromArgb(240, 240, 240)); // кисть цвета фона
            g.FillRectangle(controlbrush, 0, 0, 678, 602); // очищаем поле от старой мишени
            target.Image = bmp; // отображаем чистое поле
            if (rad != 0) // если радиус введён правильно, рисуем новые элементы мишени
            {
                g.TranslateTransform(339, 301 - rad); // переносим координаты в нужную точку
                g.FillPie(Brushes.Red, 0, 0, rad * 2, rad * 2, 180, 180); // закрашиваем область сектора
                g.DrawPie(borderpen, 0, 0, rad * 2, rad * 2, 180, 180); // обводим сектор
                g.TranslateTransform(-rad, rad); // переносим координаты в нужную точку
                g.FillRectangle(Brushes.Red, 0, 0, rad, rad); // закрашиваем область квадрата, совпадающего с первой четвертью круга
                g.DrawLine(borderpen, 0, 0, rad, 0); // прорисовываем границу
                g.TranslateTransform(-rad, 0); // переносим координаты в нужную точку
                g.FillEllipse(controlbrush, 0, 0, rad * 2, rad * 2); // закрашиваем область круга цветом фона
                g.DrawArc(borderpen, 0, 0, rad * 2, rad * 2, 270, 90); // прорисовываем дугу
                g.TranslateTransform(-339 + 2 * rad, -301); // переносим координаты в нужную точку - левый верхний угол
            }
            g.DrawLine(borderpen, 0, 0, 677, 0); // следующие 4 строки рисуем границы поля
            g.DrawLine(borderpen, 677, 0, 677, 601);
            g.DrawLine(borderpen, 677, 601, 0, 601);
            g.DrawLine(borderpen, 0, 601, 0, 0);
            g.DrawLine(borderpen, 339, 0, 339, 602); // рисуем оси
            g.DrawLine(borderpen, 0, 301, 678, 301);
            target.Image = bmp; // отображаем мишень
        }

        private void radbox_TextChanged(object sender, EventArgs e) // происходит, если изменился текст радиуса
        {
            ChangingBox(radbox, radlabel, button); // проверяем введённую информацию про радиус
        }

        private void shootbox_TextChanged(object sender, EventArgs e) // происходит, если изменился текст радиуса
        {
            ChangingBox(shootbox, shootlabel, button); // проверяем введённую информацию про выстрелы
        }

        private void xbox_TextChanged(object sender, EventArgs e) // происходит, если изменился текст X
        {
            ChangingBox(xbox, x, shootbutton); // проверяем введённую информацию про X
        }

        private void ybox_TextChanged(object sender, EventArgs e) // происходит, если изменился текст Y
        {
            ChangingBox(ybox, y, shootbutton); // проверяем введённую информацию про Y
        }

        private void ChangingBox(TextBox box, Label label, Button thebutton) // происходит, если меняется текст бокса
        {
            int max; // переменная для максимально возможного вводимого значения...
            if (box == radbox) // для радиуса
                max = 168;
            else if (box == shootbox) // для выстрелов
                max = 999;
            else if (box == xbox) // для X
                max = 677;
            else // для Y
                max = 601;
            int text; // переменная введённого числа
            string str = box.Text; // переменная текста бокса
            int min = -1; // переменная для минимально возможного вводимого значения
            if (str.Length > 3) // если введено больше 3 символов (т.е. число будет априори большим максимального)...
            {
                WrongBox(box, label, max); // неправильно введённые данные!
                return; // прекращаем работу функции
            }
            try
            {
                text = Convert.ToInt32(str); // проверяем, введено ли число
            }
            catch (FormatException) // если нет...
            {
                text = -1; // делаем число априори неверным
            }
            if (game_load && text == 0) // если в радиус или выстрел введён 0
            {
                min = 0; // меняем минимальную переменную на 0
                if (box == radbox) // если мы работаем с радиусом...
                    DrawTarget(text); // рисуем поле без мишени
            }
            if (text <= min || text > max) // если число не входит в рамки...
                WrongBox(box, label, max); // неправильно введённые данные!
            else // иначе...
            {
                if (box == shootbox) // если мы работаем с выстрелами...
                    allshoots = text; // запоминаем количество выстрелов
                if (box == radbox || box == xbox) // если мы работаем с радиусом или X...
                    radxcheck = true; // меняем первую проверяющую переменную
                else // иначе...
                    shootycheck = true; // меняем вторую проверяющую переменнную
                label.ForeColor = Color.Black; // меняем цвет текста возле бокса на чёрный для наглядности
                EnablingButton(thebutton); // проверяем, можем ли сделать кнопку видимой
                if (box == radbox) // если мы работаем с радиусом...
                    DrawTarget(text); // рисуем мишень
            }
        }

        private void WrongBox(TextBox box, Label label, int max) // происходит, если в бокс введены неверные данные
        {
            Button thebutton = button; // определяем, с какой кнопкой работать
            if (max / 100 == 6) // если мы работаем с X или Y...
                thebutton = shootbutton; // будем работать с кнопкой выстрелов
            if (box == radbox || box == xbox) // если мы работали с радиусом или X...
                radxcheck = false; // меняем первую проверяющую переменную
            else // иначе...
                shootycheck = false; // меняем вторую проверяющую переменнную
            thebutton.Enabled = false; // блокируем доступ к кнопке
            label.ForeColor = Color.Red; // слово возле бокса делаем красным для наглядности
            ToolTip wrongtip = new ToolTip(); // всплывающая подсказка для неправильно введённых данных
            wrongtip.Show("Введите целое число от 1 до " + max + "!", box, 1500); // выводим подсказку для наглядности
        }

        private void EnablingStuff(bool check) // происходит, если нужно работать с боксами X и Y
        {
            xbox.Text = ""; // делаем X бокс пустым
            x.ForeColor = Color.Black; // делаем X текст чёрным
            ybox.Text = ""; // делаем Y бокс пустым
            y.ForeColor = Color.Black; // делаем Y текст чёрным
            radxcheck = false; // меняем первую проверяющую переменную
            shootycheck = false; // меняем вторую проверяющую переменную
            if (check) // если игра закончилась...
            {
                xbox.Enabled = !xbox.Enabled; // закрываем доступ для X бокса
                ybox.Enabled = !ybox.Enabled; // закрываем доступ для Y бокса
            }
            shootbutton.Enabled = false; // делаем кнопку недоступной
        }

        private void EnablingButton(Button button) // проверяем, можем ли мы начать игру
        {
            if (radxcheck && shootycheck) // если обе проверки прошли успешно...
                button.Enabled = true; // даём пользователю возможность нажать на кнопку
            else button.Enabled = false; // иначе делаем кнопку ненажимаемой
        }

        private void button_Click(object sender, EventArgs e) // нажимаем на кнопку начала игры
        {
            if (game_play && !game_load) // если стрельба уже началась, но ещё не закончилась, уточняем, хочет ли пользователь её прекратить
            {
                DialogResult res = MessageBox.Show("Вы уверены, что хотите прекратить стрельбу?\nВсе сделанные выстрелы обнулятся.", "Прекратить стрельбу?", MessageBoxButtons.YesNo, MessageBoxIcon.Information); // выводим окошко с сообщением
                if (res == DialogResult.No) // если пользователь нажал Нет...
                    return; // просто возвращаемся назад
            }
            ButtonClicker(); // действия после нажатия кнопки
        }

        private void ButtonClicker() // действия после нажатия кнопки
        {
            if (game_load) // если мы начинаем стрельбу...
            {
                button.Text = "Изменить хар-ки"; // меняем текст кнопки
                EnablingStuff(true); // делаем X и Y открытыми
                ToolTip xtip = new ToolTip(); // создаём всплывающую подсказку для X
                xtip.SetToolTip(xbox, "Введите целое число от 0 до 677");
                ToolTip ytip = new ToolTip(); // создаём всплывающую подсказку для Y
                ytip.SetToolTip(ybox, "Введите целое число от 0 до 601");
            }
            else // иначе...
            {
                radxcheck = true; // делаем проверки пройденными
                shootycheck = true;
                button.Text = "Начать стрельбу"; // меняем текст кнопки
                currentshoots = 0; // обнуляем счётчик сделанных выстрелов
                goals = 0; // обнуляем счётчик попаданий
                DrawTarget(Convert.ToInt32(radbox.Text)); // рисуем новую мишень, чтобы стереть уже сделанные выстрелы
            }
            game_load = !game_load; // меняем проверку начала стрельбы
            if (game_load == game_play) // если стрельба ещё не закончилась...
                game_play = !game_play; // меняем проверку окончания стрельбы
            radlabel.Visible = !radlabel.Visible; // следующие 12 строк отображаем нужные и скрываем ненужные элементы в верхней части экрана
            shootlabel.Visible = !shootlabel.Visible;
            radbox.Visible = !radbox.Visible;
            shootbox.Visible = !shootbox.Visible;
            x.Visible = !x.Visible;
            xbox.Visible = !xbox.Visible;
            y.Visible = !y.Visible;
            ybox.Visible = !ybox.Visible;
            shootbutton.Visible = !shootbutton.Visible;
            shootslabel.Visible = !shootslabel.Visible;
            misseslabel.Visible = !misseslabel.Visible;
            goalslabel.Visible = !goalslabel.Visible;
            button.TabStop = !button.TabStop; // не даём перейти в кнопку Tabом для красоты
            ChangeShootsText(); // меняем текст выстрелов
        }

        private void ChangeShootsText() // меняем текст выстрелов
        {
            shootslabel.Text = currentshoots + "\nиз " + allshoots; // выводим правильные значения всех выстрелов и сделанных выстрелов
            if (game_play) // если стрельба уже началась...
            {
                goalslabel.Text = goals.ToString(); // меняем значение попаданий
                misseslabel.Text = (currentshoots - goals).ToString(); // меняем значение промахов
            }
        }

        private void target_Click(object sender, EventArgs e) // нажимаем на мишень
        {
            Shooting(true); // стреляем щелчком
        }

        private void shootbutton_Click(object sender, EventArgs e) // нажимаем на кнопку Выстрел
        {
            Shooting(false); // стреляем вводом
        }

        private void Shooting(bool shoot) // стреляем
        {
            if (game_play) // работает, только если началась стрельба
            {
                currentshoots++; // прибавляем счётчик сделанных выстрелов
                int currx, curry; // переменные координат выстрела
                if (shoot) // если стреляли щелчком...
                {
                    currx = PointToClient(MousePosition).X - 3; // находим абсциссу выстрела в поле мишени
                    curry = PointToClient(MousePosition).Y - 56; // находим ординату выстрела в поле мишени
                }
                else // иначе...
                {
                    currx = Convert.ToInt32(xbox.Text); // считываем абсциссу выстрела в поле мишени
                    curry = Convert.ToInt32(ybox.Text); // считываем ординату выстрела в поле мишени
                    EnablingStuff(false); // делаем боксы с коррдинатами пустыми
                }
                Color pixelColor = bmp.GetPixel(currx, curry); // проверяем цвет мишени в месте выстрела
                Graphics g = target.CreateGraphics(); // переменная для рисования
                if (pixelColor == Color.FromArgb(255, 255, 0, 0)) // если цвет мишени - красный, т.е. мы попали в неё...
                {
                    g.FillEllipse(Brushes.Green, currx - 5, curry - 5, 10, 10); // создаём зелёный выстрел 
                    goals++; // прибавляем счётчик попаданий
                }
                else // иначе...
                    g.FillEllipse(Brushes.Orange, currx - 5, curry - 5, 10, 10); // создаём оранжевый выстрел 
                g.DrawEllipse(Pens.Black, currx - 5, curry - 5, 10, 10); // обводим выстрел для наглядности
                ChangeShootsText(); // меняем текст выстрелов
                EndGame(); // проверяем, закончилась ли стрельба
            }
        }

        private void EndGame() // проверяем, закончилась ли стрельба
        {
            if (currentshoots == allshoots) // сработает только, если все выстрелы сделаны
            {
                EnablingStuff(true); // делаем боксы координат недоступными
                int accuracy = Convert.ToInt32(goals * 100 / currentshoots); // вычисляем меткость пользователя
                if (accuracy > best) // если текущая меткость побила рекорд...
                {
                    if (accuracy != 0) // хвалить за 0, по-моему, не стоит...
                        MessageBox.Show("Поздравляем! Вы побили рекорд меткости! Теперь он равен " + (accuracy) + "%", "Новый рекорд!"); // выводим окошко с новым рекордом
                    ToolTip besttip = new ToolTip(); // создаём всплывающую посдказку
                    besttip.SetToolTip(goalslabel, "Рекорд меткости - " + accuracy + "%"); // теперь при наведении на попадания будет показываться новый рекорд
                    best = accuracy; // присваиваем переменной рекорда текущую меткость
                }
                MessageBox.Show("Стрельба окончена. Ваша меткость - " + accuracy + "%"); // выводим окошко с результатом стрельбы
                button.Text = "Новая игра"; // меняем текст кнопки
                game_play = false; // меняем проверку окончания стрельбы
            }
        }
    }
}
