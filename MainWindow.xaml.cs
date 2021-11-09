using System;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Controls.Primitives;

namespace Kalkulačka_v2
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Calc calculation;
        private Dictionary<string, string> history;
        public MainWindow()
        {
            InitializeComponent();
            calculation = new Calc();
            ShowData();
            history = new Dictionary<string, string>();
        }

        private void CloseWindowBttn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MinimizeWindowBttn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ShowCalculation()
        {
            WorkPlaceTB.Text = calculation.GetCalculation();
        }

        private void ShowResult()
        {
            ResultTB.Text = calculation.GetResult();
        }

        private void ShowData()
        {
            ShowCalculation();
            ShowResult();
        }

        private void DeleteAll(object sender, RoutedEventArgs e)
        {
            calculation.SetCalculationToNull();
            ShowData();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            calculation.BackSpace();
            ShowData();
        }

        private void Percent(object sender, RoutedEventArgs e)
        {
            calculation.AddValue("%");
            ShowData();
        }

        private void Divide(object sender, RoutedEventArgs e)
        {
            calculation.AddValue("÷");
            ShowData();
        }

        private void Seven(object sender, RoutedEventArgs e)
        {
            calculation.AddValue('7');
            ShowData();
        }

        private void Eight(object sender, RoutedEventArgs e)
        {
            calculation.AddValue('8');
            ShowData();
        }

        private void Nine(object sender, RoutedEventArgs e)
        {
            calculation.AddValue('9');
            ShowData();
        }

        private void Mulitply(object sender, RoutedEventArgs e)
        {
            calculation.AddValue('*');
            ShowData();
        }

        private void Four(object sender, RoutedEventArgs e)
        {
            calculation.AddValue('4');
            ShowData();
        }

        private void Five(object sender, RoutedEventArgs e)
        {
            calculation.AddValue('5');
            ShowData();
        }

        private void Six(object sender, RoutedEventArgs e)
        {
            calculation.AddValue('6');
            ShowData();
        }

        private void Minus(object sender, RoutedEventArgs e)
        {
            calculation.AddValue('-');
            ShowData();
        }

        private void One(object sender, RoutedEventArgs e)
        {
            calculation.AddValue('1');
            ShowData();
        }

        private void Two(object sender, RoutedEventArgs e)
        {
            calculation.AddValue('2');
            ShowData();
        }

        private void Three(object sender, RoutedEventArgs e)
        {
            calculation.AddValue('3');
            ShowData();
        }

        private void Plus(object sender, RoutedEventArgs e)
        {
            calculation.AddValue('+');
            ShowData();
        }

        private void Zero(object sender, RoutedEventArgs e)
        {
            calculation.AddValue('0');
            ShowData();
        }

        private void TwoZeros(object sender, RoutedEventArgs e)
        {
            calculation.AddValue("00");
            ShowData();
        }

        private void Point(object sender, RoutedEventArgs e)
        {
            calculation.AddValue(".");
            ShowData();
        }

        private void Equals(object sender, RoutedEventArgs e)
        {
            if (calculation.GetCalculation() != "")
            {
                history.Add(calculation.GetCalculation(), calculation.GetResult());
                calculation = new Calc();
                ShowCalculation();
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Keyboard_Pressed(object sender, KeyEventArgs e)
        {

            switch (e.Key)
            {
                case Key.D0:
                case Key.NumPad0:
                    ZeroBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.D1:
                case Key.NumPad1:
                    OneBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.D2:
                case Key.NumPad2:
                    TwoBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.D3:
                case Key.NumPad3:
                    ThreeBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.D4:
                case Key.NumPad4:
                    FourBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.D5:
                case Key.NumPad5:
                    FiveBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.D6:
                case Key.NumPad6:
                    SixBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.D7:
                case Key.NumPad7:
                    SevenBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.D8:
                case Key.NumPad8:
                    EightBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.D9:
                case Key.NumPad9:
                    NineBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.Multiply:
                    MultBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.OemMinus:
                case Key.Subtract:
                    MinusBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.Divide:
                    DivBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.OemQuestion:
                case Key.Add:
                    PlusBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.Enter:
                    EqualsBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.Back:
                    DelBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.Decimal:
                    PointBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.OemPlus:
                    PercBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.Delete:
                    DelAllBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                default:
                    break;
            }  
        }
    }
}
