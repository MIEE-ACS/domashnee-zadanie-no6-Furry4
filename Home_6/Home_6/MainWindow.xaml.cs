using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Home_6
{
    class Human
    {
        public static Random rand = new Random();
        //идентифицируем конструктор класса
        public virtual string sex
        { get; set; }
        public virtual string surname
        { get; set; }
        public virtual string name
        { get; set; }
        public virtual string patronymic
        { get; set; }
        public virtual int age
        { get; set; }
        public virtual int mean
        { get; set; }
        public virtual int rate
        { get; set; }


        //выводим информацию с помощью ToString

        public override string ToString()
        {
            return $": {surname} {name} {patronymic}, Возраст: {age}, Пол: {sex}, Средний доход: {mean}, Средний расход: {rate}";
        }
    }

    //создаем внутренние классы 
    //дошкольник - Preschooler
    //школьник - Schooler
    //студент - Student
    //работающий - Worker

    internal class Preschooler : Human
    {
        int age_preschooler;

        public Preschooler()
        {
            age_preschooler = rand.Next(1, 6);
        }

        public override int age
        {
            get { return age_preschooler; }

            set
            {
                if (value != 0 && value > 0 && value <= 6)
                {
                    age_preschooler = value;
                }
            }
        }
        public override string ToString()
        {
            if (sex == "Мужской")

                return "Дошкольник " + base.ToString();
            else
                return "Дошкольница " + base.ToString();
        }
    }

    internal class Schooler : Human
    {
        int age_Schooler;
        int mean_Schooler;
        int rate_Schooler;

        public Schooler()
        {
            age_Schooler = rand.Next(7, 18);
            mean_Schooler = rand.Next(1000, 10000);
            rate_Schooler = rand.Next(mean_Schooler);
        }

        //Создаем методы для записи и чтения полей данных

        public override int age
        {
            get { return age_Schooler; }

            set
            {
                if (value != 0 && value > 6 && value <= 17)
                {
                    age_Schooler = value;
                }
            }
        }

        public override int mean
        {
            get { return mean_Schooler; }
        }

        public override int rate
        {
            get
            {
                int rate = mean_Schooler - rate_Schooler;
                return rate;
            }
        }

        public override string ToString()
        {
            if (sex == "Мужской")

                return "Школьник " + base.ToString();
            else
                return "Школьница " + base.ToString();
        }
    }

    internal class Student : Human
    {
        int age_student;
        int mean_student;
        int rate_student;

        public Student()
        {
            age_student = rand.Next(17, 25);
            mean_student = rand.Next(10000, 30000);
            rate_student = rand.Next(mean_student);
        }

        //Создаем методы для записа и  чтения полей данных

        public override int age
        {
            get
            {
                return age_student;
            }
            set
            {
                if (value != 0 && value > 17 && value <= 25)
                {
                    age_student = value;
                }
            }
        }
        public override int mean
        {
            get
            {
                return mean_student;
            }
        }
        public override int rate
        {
            get
            {
                int rate = mean_student - rate_student;
                return rate;
            }
        }

        public override string ToString()
        {
            if (sex == "Мужской")

                return "Студент " + base.ToString();
            else
                return "Студентка " + base.ToString();
        }
    }

    internal class Worker : Human
    {
        int age_Worker;
        int mean_Worker;
        int rate_Worker;

        public Worker()
        {
            age_Worker = rand.Next(26, 65);
            mean_Worker = rand.Next(10000, 150000);
            rate_Worker = rand.Next(mean_Worker);
        }

        //Создаем методы для записа и  чтения полей данных

        public override int age
        {
            get
            {
                return age_Worker;
            }
            set
            {
                if (value != 0 && value > 25 && value <= 65)
                {
                    age_Worker = value;
                }
            }
        }
        public override int mean
        {
            get { return mean_Worker; }
        }
        public override int rate
        {
            get
            {
                int rate = mean_Worker - rate_Worker;
                return rate;
            }
        }
        public override string ToString()
        {
            if (sex == "Мужской")

                return "Работающий " + base.ToString();
            else
                return "Работающая " + base.ToString();
        }
    }


    public partial class MainWindow : Window
    {
        List<Human> Human_Group = new List<Human>();

        public MainWindow()
        {
            InitializeComponent();

            Human_Group.Add(new Preschooler() { surname = "Андропов", name = "Андрей", patronymic = "Игоревич", sex = "Мужской" });
            Human_Group.Add(new Schooler() { surname = "Андропов", name = "Сергей", patronymic = "Игоревич", sex = "Мужской" });

            Human_Group.Add(new Worker() { surname = "Вышинская", name = "Анастасия", patronymic = "Витальевна", sex = "Женский" });
            Human_Group.Add(new Student() { surname = "Мазурина", name = "Елена", patronymic = "Анатольевна", sex = "Женский" });

            List(Human_Group);
        }

        void List(List<Human> Human_Group)
        {
            //очищаем поле и заполняем список
            Out.Items.Clear();

            foreach (var human in Human_Group)
            {
                Out.Items.Add(human);
            }
        }

        private void bt_1_Click(object sender, RoutedEventArgs e)
        {
            int check = 1;
            if (tb_surname.Text != "" && tb_age.Text != "" && tb_patronymic.Text != "" && tb_name.Text != "" && cb_sex.Text != "" && cb_Status.Text != "")
            {
                if (int.TryParse(tb_age.Text, out check) == true)
                {
                    if (cb_Status.Text == "Дошкольник" && int.Parse(tb_age.Text) > 0 && int.Parse(tb_age.Text) <= 6)
                    {
                        Human_Group.Add(new Preschooler() { surname = tb_surname.Text, name = tb_name.Text, patronymic = tb_patronymic.Text, sex = cb_sex.Text, age = int.Parse(tb_age.Text) });
                        List(Human_Group);
                    }
                    else if (cb_Status.Text == "Школьник" && int.Parse(tb_age.Text) > 6 && int.Parse(tb_age.Text) <= 17)
                    {
                        Human_Group.Add(new Schooler() { surname = tb_surname.Text, name = tb_name.Text, patronymic = tb_patronymic.Text, sex = cb_sex.Text, age = int.Parse(tb_age.Text) });
                        List(Human_Group);
                    }
                    else if (cb_Status.Text == "Студент" && int.Parse(tb_age.Text) > 17 && int.Parse(tb_age.Text) <= 25)
                    {
                        Human_Group.Add(new Student() { surname = tb_surname.Text, name = tb_name.Text, patronymic = tb_patronymic.Text, sex = cb_sex.Text, age = int.Parse(tb_age.Text) });
                        List(Human_Group);
                    }
                    else if (cb_Status.Text == "Работающий" && int.Parse(tb_age.Text) > 25 && int.Parse(tb_age.Text) <= 65)
                    {
                        Human_Group.Add(new Worker() { surname = tb_surname.Text, name = tb_name.Text, patronymic = tb_patronymic.Text, sex = cb_sex.Text, age = int.Parse(tb_age.Text) });
                        List(Human_Group);
                    }
                    else
                    { MessageBox.Show("Введите корректный возраст в соответствии со статусом!\n\nДошкольник : 0 - 6 лет\nШкольник : 7 - 17 лет\nСтудент : 18 - 25 лет\nРабоающий : 25 - 65 лет"); }
                }
                else
                { MessageBox.Show("Возраст должен быть числом!"); }

                
            }
            else
                MessageBox.Show("Введите все данные");
        }

        private void bt_2_Click(object sender, RoutedEventArgs e)
        {
            Human[] Human_Group_delete = new Human[Out.SelectedItems.Count];
            Out.SelectedItems.CopyTo(Human_Group_delete, 0);

            foreach (var human in Human_Group_delete)
            {
                Out.Items.Remove(human);
                Human_Group.Remove(human);
            }
            List(Human_Group);
        }

    }
}