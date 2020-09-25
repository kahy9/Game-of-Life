using Game_Of_Life.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;


namespace Game_Of_Life
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DispatcherTimer casovac = new DispatcherTimer();
        Button[,] arr;

        Random rnd = new Random();

        private readonly Game _game;

        public MainWindow()
        {
            InitializeComponent();

            var game = new Game();
            _game = game;

            var vyska = 20;
            var sirka = 20;

            for (int i = 0; i < vyska; i++)
            {
                gameCanvas.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < sirka; i++)
            {
                gameCanvas.RowDefinitions.Add(new RowDefinition());
            }

            arr = new Button[vyska, sirka];

            casovac.Interval = new TimeSpan(0, 0, 0, 0, 200);
            casovac.Tick += Casovac_Tick;
        }

        public void Check()
        {
            _game.Check();

            Redraw();
        }

        public void Redraw()
        {
            var cells = _game.Cells;
            foreach (var cell in cells)
            {
                var btn = arr[(int)cell.Coords.X, (int)cell.Coords.Y];

                btn.Content = cell.Alive ? "O" : " ";
                btn.Background = cell.Alive ? new SolidColorBrush(Color.FromRgb(64, 163, 81)) : new SolidColorBrush(Color.FromRgb(51, 51, 51));

            }
        }

        private void Casovac_Tick(object sender, EventArgs e)
        {
            this.Check();
            return;           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = new Button();
                    var btn = arr[i, j];
                    btn.Content = "X";
                    btn.Click += Btn_Click1;
                    btn.Tag = $"{i}-{j}";
                    btn.SetValue(Grid.RowProperty, i);
                    btn.SetValue(Grid.ColumnProperty, j);
                    gameCanvas.Children.Add(btn);
                    _game.AddCell(new Point(i, j));
                    Redraw();
                }
            }
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            if (!casovac.IsEnabled)
                casovac.Start();
            else casovac.Stop();
            start.Content = casovac.IsEnabled ? "Stop" : "Start";
        }

        private void Btn_Click1(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                var coordsStr = (btn.Tag as string).Split('-');
                var xParse = int.TryParse(coordsStr[0], out var x);
                var yParse = int.TryParse(coordsStr[1], out var y);

                if (!xParse || !yParse)
                    return;

                _game.ToogleCellAlive(new Point(x, y));
                Redraw();
            }
        }

        private void generace_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                var radek = rnd.Next(0, arr.GetLength(0));
                var sloupec = rnd.Next(0, arr.GetLength(1));
                _game.ToogleCellAlive(new Point(radek, sloupec));
            }
            Redraw();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var val = (int)(sender as Slider).Value;
            casovac.Interval = new TimeSpan(0, 0, 0, 0, val);
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Filter = "data files (*.txt) | *.txt";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (System.IO.Stream soub = new System.IO.FileStream(openFileDialog.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    using (System.IO.StreamReader sw = new System.IO.StreamReader(soub, Encoding.Default))
                    {
                        var allLines = File.ReadAllText(openFileDialog.FileName);
                        var deserialized = JsonConvert.DeserializeObject<List<Cell>>(allLines);
                        _game.SetCells(deserialized);
                        Redraw();
                    }
                }
            }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.Filter = "data files (*.txt) | *.txt";

            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (System.IO.Stream soub = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(soub, Encoding.Default))
                    {
                        var serialised = JsonConvert.SerializeObject(_game.Cells);

                        sw.Write(serialised);

                    }
                }
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Environment.Exit(0);
            }
        }
    }   
}
