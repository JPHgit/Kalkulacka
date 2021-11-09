using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls.Primitives;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Kalkulačka_v2
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlConnection cnn;
        private Calc calculation;
        private string connectionString;

        public MainWindow()
        {
            InitializeComponent();
            calculation = new Calc();
            ShowData();
            connectionString = @"Server=LAPTOP-98H4NLF2\SQLEXPRESS;Database=calc_history;Trusted_Connection=True";
        }

        // zavření programu
        private void CloseWindowBttn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        // minimalizace okna
        private void MinimizeWindowBttn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //zobrazení kalkulace
        private void ShowCalculation()
        {
            WorkPlaceTB.Text = calculation.GetCalculation();
        }

        //zobrazení výsledku
        private void ShowResult()
        {
            ResultTB.Text = calculation.GetResult();
        }

        // zobrazení změn
        private void ShowData()
        {
            ShowCalculation();
            ShowResult();
            UnfocusButton();       }

        private void UnfocusButton()
        {
            DependencyObject scope = FocusManager.GetFocusScope(this);
            FocusManager.SetFocusedElement(scope, null);
            Keyboard.ClearFocus();
            MainWind.Focus();
        }

        // zadávaní znaků do kalkulace a zobrazení změn
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
            // pokud byla provedena nějaká kalkulace uloží ji do historie a spustí novou kalkulaci, nechá zobrazený poslední výsledek
            if (calculation.GetCalculation() != "")
            {
                InsertToDB(calculation.GetCalculation(), Convert.ToDouble(calculation.GetResult()));
                calculation = new Calc();
                ShowCalculation();
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // pokud je ve aplikaci stiknuté levé tlačítko nad kterýkoliv jiným elementem než button spustí funkci pro přesun okna po obrazovce
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Keyboard_Pressed(object sender, KeyEventArgs e)
        {
            // zpracovává input zadaný klávesnicí a spouští klik na jednotlivé tlačítka
            switch (e.Key)
            {
                case Key.NumPad0:
                    ZeroBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.NumPad1:
                    OneBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.NumPad2:
                    TwoBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.NumPad3:
                    ThreeBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.NumPad4:
                    FourBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.NumPad5:
                    FiveBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.NumPad6:
                    SixBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.NumPad7:
                    SevenBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.NumPad8:
                    EightBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.NumPad9:
                    NineBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.Multiply:
                    MultBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.Subtract:
                    MinusBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.Divide:
                    DivBttn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
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

        private void InsertToDB(string calc, double result)
        {
            cnn = new SqlConnection(connectionString);
            using (cnn)
            {
                cnn.Open();

                using (SqlCommand command =
                   new SqlCommand("INSERT INTO History (Calculation, Result) VALUES (@calc, @res)", cnn))
                {
                    
                    command.Parameters.Add(new SqlParameter("calc", calc));
                    command.Parameters.Add(new SqlParameter("res", result));

                    
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    command.Dispose();

                }
                cnn.Close();
            }
        }

        private void ShowHistory(object sender, RoutedEventArgs e)
        {
            try { 
                string history = "";
                cnn = new SqlConnection(connectionString);

                cnn.Open();
            
                using (SqlCommand command =
                    new SqlCommand("SELECT * FROM History ORDER BY CId DESC", cnn))
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read()) history = dataReader.GetValue(1).ToString();
                    command.Dispose();
                }
           
                cnn.Close();

                calculation.SetFromHistory(history);
                ShowData();
            }
            catch { }
        }
    }
}
