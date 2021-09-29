using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pyatnashki_borsukov
{
    public partial class Pyatnashki : Form
    {
        game_mechanics our_game; // создаём игру
        bool timerstart; // булевая переменная для работы таймера
        int movesnum, besttime = int.MaxValue, bestmoves = int.MaxValue; // переменные для подсчёта ходов и рекордов
        ToolTip bestime = new ToolTip(); // всплывающая подсказка о рекорде времени
        ToolTip besmoves = new ToolTip(); // всплывающая подсказка о рекорде ходов
        public Pyatnashki()
        {
            InitializeComponent();
            our_game = new game_mechanics();
            colorDialog.FullOpen = true; // если мы будем менять цвет фона/пятнашек, то мы можем пользоваться всей цветовой палитрой
            fontDialog.ShowColor = true; // если мы будем менять шрифт пятнашек, мы сможем поменять его цвет
        }

        private void Pyatnashki_Load(object sender, EventArgs e) // при запуске программы открываем FAQ-окошко и запускаем новую игру
        {
            restart();
            our_game.game_start();
            refresh();
            showfaq();
        }

        private Button changer(int button_num) // для удобного обращения к кнопкам
        {
            switch (button_num)
            {
                case 0: return button0;
                case 1: return button1;
                case 2: return button2;
                case 3: return button3;
                case 4: return button4;
                case 5: return button5;
                case 6: return button6;
                case 7: return button7;
                case 8: return button8;
                case 9: return button9;
                case 10: return button10;
                case 11: return button11;
                case 12: return button12;
                case 13: return button13;
                case 14: return button14;
                case 15: return button15;
                default: return null;
            }
        }

        private void restart() // будет срабатывать при запуске игры, начале новой игры и повторении игры
        {
            timer_stop(); // останавливаем таймер
            labelmovesnum.Text = "0";  // обнуляем счётчик ходов
            movesnum = 0;
            labelmin.Text = "00"; // обнуляем время
            labelsec.Text = "00";
            RestartToolStripMenuItem.Enabled = false; // не позволяем начать игру заново из меню
        }

        private void refresh() // обновляет значения на пятнашках
        {
            for (int p = 0; p < 16; p++)
            {
                int currentnum = our_game.getnum(p); // определяем текущий номер пятнашки
                changer(p).Text = currentnum.ToString(); // присваиваем пятнашке новую надпись
                changer(p).Visible = (currentnum > 0); // пустая пятнашка не будет отображаться
            }
        }

        private void timer_start() // для запуска таймера
        {
            RestartToolStripMenuItem.Enabled = true; // если таймер запущен, то игра началась. позволяем начать её заново из меню
            timerstart = false; // устанавливаем флажок на false для корректной работы паузы таймера
            timer.Start(); // запускаем таймер
            bestime.SetToolTip(labeltwodots, "Остановить таймер"); // меняем всплывающую подсказку при наведении на :
        }

        private void timer_stop() // для остановки таймера
        {
            timerstart = true; // устанавливаем флажок на true для корректной работы паузы таймера
            timer.Stop(); // останавливаем таймер
            bestime.SetToolTip(labeltwodots, "Запустить таймер"); // меняем всплывающую подсказку при наведении на :
        }

        private void showfaq() // показывает FAQ-окошко
        {
            MessageBox.Show("Добро пожаловать в Пятнашки от Арсения!\n\nЦель игры - собрать костяшки на поле 4x4 в порядке возрастания.\n\nИзвестно, что вариант 15-14 невозможно довести до варианта 14-15, поэтому ваша цель - довести поле до состояния, где хотя бы первые 13 чисел находятся на своих местах, а последняя клетка пустая.\n\nВ меню игры вы можете начать новую игру, начать игру заново или изменить оформление игры.\n\nСверху расположен таймер вашей игры. Если вы хотите остановить его - нажмите на : между минутами и секундами. Он продолжит работать при повторном нажатии на : или нажатии на костяшку.\n\nПосле вашей первой победы в игре появятся ваши рекорды по времени и количеству ходов. Они будут существовать в пределах одного запуска программы. Чтобы узнать свои рекорды, наведите курсором на таймер или количество ходов соответственно.\n\nУдачи!", "FAQ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e) // начало новой игры
        {
            restart();
            our_game.game_start(); // создаём новую последовательность пятнашек
            refresh();
        }

        private void повторитьИгруToolStripMenuItem_Click(object sender, EventArgs e) // начать игру заново
        {
            restart();
            our_game.game_start_again(); // переводим пятнашки в начальные положения
            refresh();
        }

        private void button_Click(object sender, EventArgs e) // срабатывает при нажатии на пятнашку
        {
            if (timerstart) // запускаем таймер если он остановлен
                timer_start();
            int button_num = Convert.ToInt32(((Button)sender).Tag);
            our_game.shift(button_num); // двигаем пятнашки
            refresh();
            if (our_game.changed()) // если произошло движение, добавляем один ход
            {
                movesnum++;
                labelmovesnum.Text = movesnum.ToString();
            }
            if (our_game.checking_stuff()) // если игрок победил
            {
                timer_stop(); // останавливаем таймер
                if (movesnum < bestmoves) // сверяем текущее количество шагов с рекордным
                {
                    if (bestmoves != int.MaxValue) // если мы побили свой рекорд, а не просто победили в первый раз
                        MessageBox.Show("Вы побили свой рекорд по количеству ходов!\n\nИз " + bestmoves + " он превратился в " + movesnum + "!");
                    bestmoves = movesnum; // если установлен новый рекорд, присваиваем текущее значение ходов рекорду
                }
                int currtime = Convert.ToInt32(labelmin.Text) * 60 + Convert.ToInt32(labelsec.Text); // переменная текущего времени для удобства
                if (currtime < besttime) // работает аналогично с рекордом по ходам
                {
                    if (besttime != int.MaxValue)
                        MessageBox.Show("Вы побили свой рекорд по времени!\n\nИз " + besttime / 60 + " мин " + besttime % 60 + " сек он превратился в " + Convert.ToInt32(labelmin.Text) + " мин " + Convert.ToInt32(labelsec.Text) + " сек!");
                    besttime = currtime;
                }
                // выводим поздравительное окошко, а также теперь при наведении на время и ходы нам будут высвечиваться наши рекорды
                DialogResult result = MessageBox.Show("Поздравляем!\n\n\nВы победили за " + labelmin.Text + " мин " + labelsec.Text + " сек, сделав " + movesnum + " ходов!\n\n\nНажмите ОК, чтобы начать эту игру заново.\n\nДля запуска новой игры после нажатия ОК воспользуйтесь меню или сочетанием клавиш Ctrl+N.");
                bestime.SetToolTip(labelmin, "Рекорд: " + (besttime / 60).ToString() + " мин " + (besttime % 60).ToString() + " сек");
                bestime.SetToolTip(labelsec, "Рекорд: " + (besttime / 60).ToString() + " мин " + (besttime % 60).ToString() + " сек");
                besmoves.SetToolTip(labelmoves, "Рекорд: " + (bestmoves.ToString()));
                besmoves.SetToolTip(labelmovesnum, "Рекорд: " + (bestmoves.ToString()));
                if (result == DialogResult.OK) // после нажатия ОК начинаем игру заново
                {
                    restart();
                    our_game.game_start_again();
                    refresh();
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e) // происходит на каждый тик таймера
        {
            int sec = Convert.ToInt32(labelsec.Text); // создаём интовые переменные, равные текущему значению времени
            int min = Convert.ToInt32(labelmin.Text);
            sec++; // добавляем одну секунду
            if (sec==60) // если секунд стало 60, обнуляем значение секунд и прибавляем одну минуту
            {
                labelsec.Text = "00";
                min++;
                if (min < 10) // если секунд меньше десяти, отображаем 0 и затем значение минут
                    labelmin.Text = "0" + Convert.ToString(min);
                else labelmin.Text = Convert.ToString(min);
            }
            else if (sec < 10) // если секунд меньше десяти, отображаем 0 и затем значение секунд
                labelsec.Text = "0" + Convert.ToString(sec);
            else labelsec.Text = Convert.ToString(sec);
        }

        private void labeltwodots_Click(object sender, EventArgs e) // при нажатии на кнопку таймер будет останавливаться или возобновлять работу
        {
            if (timerstart) // если таймер остановлен, то он возобновит работу, и наоборот
                timer_start();
            else timer_stop();
        }

        private void ИграToolStripMenuItem_Click_1(object sender, EventArgs e) // при нажатии на меню (Игра) таймер станет на паузу
        {
            timer_stop();
        }

        private void fAQToolStripMenuItem_Click(object sender, EventArgs e) // сработает при нажатии на кнопку FAQ в меню
        {
            timer_stop(); // останавливаем таймер (вдруг игрок перешёл сюда с помощью горячих клавиш)
            showfaq();
        }

        private void изменитьЦветФонаToolStripMenuItem_Click(object sender, EventArgs e) // изменяет цвет фона
        {
            timer_stop(); // останавливаем таймер (вдруг игрок перешёл сюда с помощью горячих клавиш)
            colorDialog.Color = tableLayoutPanel.BackColor; // текущий цвет фона будет установлен цветом по умолчанию
            if (colorDialog.ShowDialog() == DialogResult.Cancel) // открываем меню
                return;
            tableLayoutPanel.BackColor = colorDialog.Color; // меняем цвет фона
        }

        private void изменитьЦветПятнашекToolStripMenuItem_Click(object sender, EventArgs e) // изменяет цвет пятнашек
        {
            timer_stop(); // останавливаем таймер (вдруг игрок перешёл сюда с помощью горячих клавиш)
            colorDialog.Color = button0.BackColor; // текущий цвет пятнашки будет установлен цветом по умолчанию
            if (colorDialog.ShowDialog() == DialogResult.Cancel) // запускаем меню
                return;
            for (int i = 0; i < 16; i++) // для каждой пятнашки меняем её цвет
                changer(i).BackColor = colorDialog.Color;
        }

        private void изменитьШрифтПятнашекToolStripMenuItem_Click(object sender, EventArgs e) // изменяет шрифт пятнашек
        {
            timer_stop(); // останавливаем таймер (вдруг игрок перешёл сюда с помощью горячих клавиш)
            fontDialog.Font = button0.Font; // текущий шрифт пятнашки будет установлен шрифтом по умолчанию
            fontDialog.Color = button0.ForeColor; // текущий цвет шрифта пятнашки будет установлен цветом шрифта по умолчанию
            if (fontDialog.ShowDialog() == DialogResult.Cancel) // запускаем меню
                return;
            for (int i = 0; i < 16; i++) // меняем шрифт и его цвет у каждой пятнашки
            {
                changer(i).ForeColor = fontDialog.Color;
                changer(i).Font = fontDialog.Font;
            }
        }
    }
}
