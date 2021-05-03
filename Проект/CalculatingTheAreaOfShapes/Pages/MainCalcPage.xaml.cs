using CalculatingTheAreaOfShapes.AppData;
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
using CalcArea;

namespace CalculatingTheAreaOfShapes.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainCalcPage.xaml
    /// </summary>
    public partial class MainCalcPage : Page
    {
        public MainCalcPage()
        {
            InitializeComponent();
        }

        //Вычисление площади круга
        private void Radius_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Radius.Text == string.Empty)
            {
                Area1.Text = string.Empty;
            }
            else
            {
                try
                {
                    double radiusDouble = Convert.ToDouble(Radius.Text);
                    if (radiusDouble >= 0)
                    {
                        //Вычисление площади с помощью библиотеки CalcArea
                        Area1.Text = CalcArea.CalcArea.CircleArea(radiusDouble).ToString();
                    }
                    else
                    {
                        Area1.Text = "Радиус меньше нуля";
                    }
                }
                catch 
                {
                    Area1.Text = string.Empty;
                }
            }
        }

        private void TriangleSide_TextChanged(object sender, TextChangedEventArgs e)
        {
            TriangelType.Visibility = Visibility.Collapsed;
            if (TriangleSide1.Text == string.Empty || TriangleSide2.Text == string.Empty || TriangleSide3.Text == string.Empty)
            {
                Area2.Text = string.Empty;
            }
            else
            {
                try
                {
                    double triangleSideDouble1 = Convert.ToDouble(TriangleSide1.Text);
                    double triangleSideDouble2 = Convert.ToDouble(TriangleSide2.Text);
                    double triangleSideDouble3 = Convert.ToDouble(TriangleSide3.Text);
                    if (triangleSideDouble1 >= 0 && triangleSideDouble2 >= 0 && triangleSideDouble3 >= 0
                        && (triangleSideDouble1 + triangleSideDouble2 > triangleSideDouble3) 
                        && (triangleSideDouble1 + triangleSideDouble3 > triangleSideDouble2)
                        && (triangleSideDouble3 + triangleSideDouble2 > triangleSideDouble1))
                    {
                        //Вычисление площади с помощью библиотеки CalcArea
                        Area2.Text = CalcArea.CalcArea.TriangleArea(triangleSideDouble1, triangleSideDouble2, triangleSideDouble3).ToString();

                        //Проверка типа треугольника == прямоугольный
                        double hypotenuse;
                        if (triangleSideDouble1 > triangleSideDouble2 && triangleSideDouble1 > triangleSideDouble3)
                        {
                            hypotenuse = triangleSideDouble1;
                            if (Math.Pow(hypotenuse, 2) == (Math.Pow(triangleSideDouble2, 2)) + (Math.Pow(triangleSideDouble3, 2)))
                            {
                                TriangelType.Visibility = Visibility.Visible;
                            }
                        }
                        else if (triangleSideDouble2 > triangleSideDouble1 && triangleSideDouble2 > triangleSideDouble3)
                        {
                            hypotenuse = triangleSideDouble2;
                            if (Math.Pow(hypotenuse, 2) == (Math.Pow(triangleSideDouble1, 2)) + (Math.Pow(triangleSideDouble3, 2)))
                            {
                                TriangelType.Visibility = Visibility.Visible;
                            }

                        }
                        else if (triangleSideDouble3 > triangleSideDouble1 && triangleSideDouble3 > triangleSideDouble2)
                        {
                            hypotenuse = triangleSideDouble3;
                            if (Math.Pow(hypotenuse, 2) == (Math.Pow(triangleSideDouble2, 2)) + (Math.Pow(triangleSideDouble1, 2)))
                            {
                                TriangelType.Visibility = Visibility.Visible;
                            }
                        }
                    }
                    else
                    {
                        Area2.Text = "Такого трекгольника не существует";
                    }
                }
                catch
                {
                    Area2.Text = string.Empty;
                }
            }
        }
    }
}
